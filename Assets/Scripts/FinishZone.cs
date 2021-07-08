using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishZone : MonoBehaviour
{

    public event Action PlayerWon;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player))
        {
            StartCoroutine(DelayWon());
        }
    }

    private IEnumerator DelayWon()
    {
        yield return new WaitForSeconds(1);
        PlayerWon?.Invoke();
    }

}
