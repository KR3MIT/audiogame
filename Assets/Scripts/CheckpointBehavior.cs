using System;
using UnityEngine;

public class CheckpointBehavior : MonoBehaviour
{
    public Task task;
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerBehavior behaviour))
        {
            behaviour.SetCheckpoint(transform.position);

            if (task != null)
            {
                task?.CompleteTask();
            }
            
            Destroy(gameObject);
        }
    }
}
