using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bearscript : MonoBehaviour
{
    float startTime;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        if (Time.time - startTime >= 5.0f)
        {
            Destroy(gameObject); // Destroy the Spawner
        }
    }
    void  OnTriggerEnter(Collider other) 
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

        if(playerHealth == null ) {return ;}

        playerHealth.Crash();
        
    }

    void OnBecameInvisible() 
    {
        Destroy(gameObject);
    }
}
