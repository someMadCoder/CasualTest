using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishZone : MonoBehaviour
{

    public event Action PlayerWon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
