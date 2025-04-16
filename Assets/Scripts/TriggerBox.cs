using UnityEngine;

public class TriggerBox : MonoBehaviour
{
    public Task task;
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerBehavior behaviour))
        {
            if (task != null)
            {
                task?.CompleteTask();
            }
        }
    }
}
