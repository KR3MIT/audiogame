using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "EndTask", menuName = "Scriptable Objects/EndTask")]
public class EndTask : Task
{
    //insert dialogue here
    public override void StartTask(UnityAction onTaskCompleteCallback)
    {
        base.StartTask(onTaskCompleteCallback);
        CompleteTask();
    }
}