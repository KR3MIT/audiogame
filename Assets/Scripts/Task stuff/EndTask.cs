using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "EndTask", menuName = "Scriptable Objects/EndTask")]
public class EndTask : Task
{
    // insert end of conversation dialogue variable
    public override void StartTask(UnityAction onTaskCompleteCallback)
    {
        base.StartTask(onTaskCompleteCallback);
        CompleteTask();
    }
}