using UnityEngine;

public class TriggerBox : MonoBehaviour
{
    public Task task;
    void OnTriggerEnter(Collider other)
    {
        if (task != null)
        {
            task?.CompleteTask();
        }
    }
}
