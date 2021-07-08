using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDestructionZone : MonoBehaviour
{
    public event Action ObstacleDestroyed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Obstacle obstacle) && obstacle.PointsCounted == false)
        {
            Destroy(other.gameObject, 3);
            obstacle.PointsCounted = true;
            ObstacleDestroyed?.Invoke();
        }
    }
}
