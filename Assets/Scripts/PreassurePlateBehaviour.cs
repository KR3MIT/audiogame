using NUnit.Framework;
using System;
using Unity.VisualScripting;
using UnityEngine;

public class PreassurePlateBehaviour : MonoBehaviour
    
{
    public int plateNumber;
    // Start is called once before the first execution of Update after the MonoBehaviour is 
    public BoxCollider bc;
    void Start()
    {
        bc = GetComponent<BoxCollider>();

    }
    // enum that gives each plate a number value to identify it
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "PlayerCollision")
        {
            transform.root.GetComponent<PlateManager>().PlateAdd(plateNumber);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PlayerCollision")
        {
            transform.root.GetComponent<PlateManager>().PlateAdd(plateNumber);
        }
    }
   
}
