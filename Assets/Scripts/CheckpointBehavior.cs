using System;
using UnityEngine;

public class CheckpointBehavior : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerBehavior behaviour))
        {
            behaviour.SetCheckpoint(transform.position);
            Destroy(gameObject);
        }
    }
}
