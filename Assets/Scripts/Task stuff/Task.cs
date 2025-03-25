using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Task", menuName = "Scriptable Objects/Task")]
public class Task : ScriptableObject
{
    public string name;

    public string taskStartNarration;
    public string taskCompleteNarration;

    public float dialogueLength;
    
    public UnityEvent onTaskStart;
    public UnityAction onTaskComplete;
    
    public virtual void StartTask(UnityAction onTaskCompleteCallback)
    {
        Debug.Log(taskStartNarration);
        
        onTaskStart?.Invoke();
        onTaskComplete = onTaskCompleteCallback;
    }

    public void CompleteTask()
    {
        if (onTaskComplete == null)
        {
            return;
        }
        
        onTaskComplete?.Invoke();
        onTaskComplete = null;
        
        Debug.Log(taskCompleteNarration);
    }
}
