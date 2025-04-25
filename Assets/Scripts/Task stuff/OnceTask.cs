using UnityEngine;
using UnityEngine.Events;

using System.Collections.Generic;
public class OnceTask : MonoBehaviour
{
    [SerializeField] private Task onceTask;
    private Dictionary<Task, UnityEvent> taskEventRelays = new Dictionary<Task, UnityEvent>();
    private void CompleteTask()
    {
        Debug.Log("wall hit task completed");
        onceTask.isActiveTask = false;
    }

    void Start()
    {
        UnityEvent relayEvent = new UnityEvent();
        taskEventRelays[onceTask] = relayEvent;
        
        onceTask.taskCompletedEvent.AddListener(() => relayEvent.Invoke());
        
        onceTask.isActiveTask = true;
    }
}
