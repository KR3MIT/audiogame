using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Task", menuName = "Scriptable Objects/Task")]
public class Task : ScriptableObject
{
    public bool isCompleted;
    //AudioClip audioClip;
    public string text;
    public float narrationDuration;
    public float nextTaskDelay;

    public UnityEvent TaskCompleted;
    
    public void Activate()
    {
        TaskCompleted?.AddListener(CompleteTask);
    }
    public void CompleteTask()
    {
        isCompleted = true;
    }
}
