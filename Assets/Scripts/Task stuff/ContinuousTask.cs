using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "ContinuousTask", menuName = "Scriptable Objects/ContinuousTask")]
public class ContinuousTask : Task
{
    public float requiredAmount;
    [SerializeField] private float currentAmount;
    
    // runs when the task is started
    public override void StartTask(UnityAction onTaskCompleteCallback)
    {
        base.StartTask(onTaskCompleteCallback);
        currentAmount = 0;
    }
    public void TrackAmount(float amount)
    {
        if (!isActiveTask)
        {
            return;
        }
        
        // this function is called to track the amount of progress made towards the task
        currentAmount += Mathf.Abs(amount);
        if (currentAmount >= requiredAmount)
        {
            CompleteTask();
        }
    }
}