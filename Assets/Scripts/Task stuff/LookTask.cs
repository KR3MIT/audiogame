using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "LookTask", menuName = "Scriptable Objects/LookTask")]
public class LookTask : Task
{
    public float requiredLookAmount;
    private float currentLookAmount;
    
    public override void StartTask(UnityAction onTaskCompleteCallback)
    {
        base.StartTask(onTaskCompleteCallback);
        currentLookAmount = 0;
    }
    
    public void TrackLook(float lookAmount)
    {
        currentLookAmount += Mathf.Abs(lookAmount);
        if (currentLookAmount >= requiredLookAmount)
        {
            CompleteTask();
        }
    }
}