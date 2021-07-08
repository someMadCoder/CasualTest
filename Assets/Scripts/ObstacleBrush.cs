using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
[RequireComponent(typeof(Swipe))]

public class ObstacleBrush : MonoBehaviour
{
    private Camera _camera;
    [SerializeField] private float _swipeForce=10;
    private Swipe _swipe;
    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();
        _swipe = GetComponent<Swipe>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            _swipe.StartSwipe();
        }
        if (Input.GetMouseButton(0) && Physics.Raycast(ray, out RaycastHit hit, 1000) && hit.transform.TryGetComponent(out Obstacle _))
        {
            SwipeStopped();
        }
    }

    private void SwipeStopped()
    {

        Ray ray = _camera.ScreenPointToRay(_swipe.EndPoint);
        Debug.DrawRay(ray.origin, ray.direction * 1000, Color.green, 0.5f);

        if (Physics.Raycast(ray, out RaycastHit hit, 1000) && hit.transform.TryGetComponent(out Obstacle _))
        {
            Debug.Log("pushing the obstacle");
            if (hit.transform.TryGetComponent(out Rigidbody obstacleRb))
            {
                obstacleRb.AddForceAtPosition(_swipe.Direction * _swipe.Speed, hit.point);
            }

        }
    }
}
