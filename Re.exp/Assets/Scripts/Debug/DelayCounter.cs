using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayCounter : MonoBehaviour
{
    
    private float delay = 0f;
    private float lastHit = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        delay = Time.time - lastHit;
        lastHit = Time.time;
        Debug.Log(delay);
    }
}
