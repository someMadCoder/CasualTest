using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    private Rigidbody _rb;
    private bool _gameOver = false;
    [SerializeField] private Transform _forcePoint;
    [SerializeField] private float _accelerationSpeed = 10;
    [SerializeField] private float _maxSpeed = 30;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if(_gameOver != true && _rb.velocity.z < _maxSpeed)
            //_rb.velocity = transform.forward * 10; //если нужна постоянная скорость
            _rb.AddForceAtPosition(Vector3.forward * _accelerationSpeed, _forcePoint.position, ForceMode.Force); //если нужно ускорение в начале
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent(out Obstacle _))
        {
            _gameOver = true;
            _rb.constraints = RigidbodyConstraints.None;
        }
    }
}
