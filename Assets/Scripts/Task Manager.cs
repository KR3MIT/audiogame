using UnityEngine;

public class TaskManager : MonoBehaviour
{
    [SerializeField] private Task[] taskList;

    [SerializeField] private int currentTask = 0;
    
    public void NextTask()
    {
        currentTask++;
        taskList[currentTask].Activate();
        
        
        
    }
    
}
