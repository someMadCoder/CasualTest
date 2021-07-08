using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Swipe : MonoBehaviour//можно было сделать через паттерн, но будет перегружено
{
    public enum State
    {
        startCollectingData,
        collectingData,
        endCollectingData,
        idle
    }

    [SerializeField] private float _sensetivity = 10;
    [SerializeField] private float _maxSpeed = 35;

    private State _currentState = State.idle;
    public State CurrentState => _currentState;

    private float _startTime;
    private float _lifetime;
    private float _speed;

    private bool _canBeStoppedFromOutside = true;

    private readonly List<Vector2> _shape = new List<Vector2>();

    public float Speed { 
        get 
        {
            return Mathf.Clamp(_speed, 0, _maxSpeed);
        } 
    }

    public Vector2 EndPoint
    {
        get
        {
            if (_shape.Count > 0)
                return _shape.Last();
            else
                return Vector2.zero;
        }
    }

    public event Action OnStop;

    public void StartSwipe()
    {
        _currentState = State.startCollectingData;
    }

    private void Update()
    {
        Vector2 mousePosition = Input.mousePosition;

        if (Input.GetMouseButtonUp(0))
            Stop();

        switch (_currentState) {
            case State.startCollectingData:
                _startTime = Time.time;
                _shape.Clear();
                AddShapePoint(mousePosition);
                _currentState = State.collectingData;
                _canBeStoppedFromOutside = true;
                Debug.Log("Started");
                break;
            case State.collectingData:
                StartCoroutine(AddingShapePoints());
                if ((mousePosition - _shape.Last()).magnitude > _sensetivity)
                {
                    AddShapePoint(mousePosition);
                }
                break;
            case State.endCollectingData:
                Debug.Log("stop");
                StopAllCoroutines();
                AddShapePoint(mousePosition);
                _lifetime = Time.time - _startTime;
                _speed = Length() / _lifetime;
                _currentState = State.idle;
                break;
            case State.idle:
                break;
        }
    }

    private void AddShapePoint(Vector2 point)
    {
        _shape.Add(point);
        if (_shape.Count > 100)
        {
            _shape.RemoveAt(0);
            Debug.Log("removing first point in list");
            _startTime = Time.time;
        }
    }

    private IEnumerator AddingShapePoints()
    {
        yield return new WaitForSeconds(3);
        AddShapePoint(Input.mousePosition);

        StartCoroutine(AddingShapePoints());
    }

    private float Length()
    {
        float pathLength = 0;

        for (int i = 0; i < _shape.Count - 1; i++)
        {
            pathLength += Vector2.Distance(_shape[i], _shape[i + 1]);
            Debug.DrawLine(_shape[i], _shape[i + 1], Color.red, 5);
            //Debug.Log("shape count:"+_shape.Count);
        }
        //Debug.Log("pathLength:" + pathLength);
        return pathLength;
    }

    public void TryStop()
    {
        if (_canBeStoppedFromOutside)
        {
            _canBeStoppedFromOutside = false;
            Stop();
            Debug.Log("Stopped from outside");
        }
    }
    private void Stop()
    {
        _currentState = State.endCollectingData;
        OnStop?.Invoke();
    }

    public Vector2 Direction
    {
        get
        {
            if (_shape.Count >= 2)
            {
                int lastIndex = _shape.Count - 1;
                return (_shape[lastIndex] - _shape[lastIndex - 1]).normalized;
            }
            else
            {
                return Vector2.zero; 
            }
        }
    }

}
