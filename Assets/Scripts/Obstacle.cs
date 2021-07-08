using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Obstacle : MonoBehaviour
{
    private bool _pointsCounted;

    public bool PointsCounted { get => _pointsCounted; set => _pointsCounted = value; }
    //чтобы использовать такой вариант свайпа нужно раскомментировать код и выключить Obstacle brush у камеры на сцене
    #region take and pull
    ////[SerializeField] private Transform debugSphere;
    //private Vector3 startPosition;
    //private float distanseToCamera;
    //private Rigidbody rb;
    //private bool _canBeMoved = true;

    //void Start()
    //{
    //    rb = GetComponent<Rigidbody>();
    //    startPosition = transform.position;
    //}
    //private void OnMouseDrag()
    //{
    //    if (_canBeMoved)
    //    {
    //        Vector2 mousePosition = Input.mousePosition;
    //        distanseToCamera = (startPosition - Camera.main.transform.position).magnitude;

    //        Vector3 direction = (Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, distanseToCamera)) - transform.position);
    //        //debugSphere.position = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, distanseToCamera));

    //        rb.velocity = direction * 10;

    //    }
    //}
    //private void OnMouseUp()
    //{
    //    _canBeMoved = false;
    //}

    //private void OnCollisionStay(Collision collision)
    //{
    //    if (collision.transform.CompareTag("Road") & !_canBeMoved)
    //        _canBeMoved = true;
    //}
    #endregion


}
