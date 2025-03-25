using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "ContinuousTask", menuName = "Scriptable Objects/ContinuousTask")]
public class ContinuousTask : Task
{
    public float requiredAmount;
    [SerializeField] private float currentAmount;
    
    public override void StartTask(UnityAction onTaskCompleteCallback)
    {
        base.StartTask(onTaskCompleteCallback);
        currentAmount = 0;
    }
    
    public void TrackAmount(float amount)
    {
        currentAmount += Mathf.Abs(amount);
        if (currentAmount >= requiredAmount)
        {
            CompleteTask();
        }
    }
}