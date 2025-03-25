using System;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    [SerializeField] private List<Task> taskList;

    [SerializeField] private int currentTask = 0;

    public void Start()
    {
        StartNextTask();
    }

    private void StartNextTask()
    {
        if (currentTask < taskList.Count)
        {
            taskList[currentTask].StartTask(CompleteTask);
        }
    }
    
    private void CompleteTask()
    {
        currentTask++;
        StartNextTask();
    }

}
