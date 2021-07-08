using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public event Action PlayerLost;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.TryGetComponent(out Obstacle _))
        {
            StartCoroutine(DelayLost());
        }
    }

    private IEnumerator DelayLost()
    {
        yield return new WaitForSeconds(1);
        PlayerLost?.Invoke();
    }

}
