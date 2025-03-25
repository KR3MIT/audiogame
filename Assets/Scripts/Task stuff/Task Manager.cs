using System.Collections;
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
        if (currentTask == taskList.Count)
        {
            Debug.Log("EndTask");
            StartCoroutine(EndDialogueDelay());
        }
        else if (currentTask < taskList.Count)
        {
            taskList[currentTask].StartTask(CompleteTask);
        }
    }
    private void CompleteTask()
    {
        currentTask++;
        StartNextTask();
    }

    private IEnumerator EndDialogueDelay()
    {
        var _endDelay = taskList[currentTask].dialogueLength;
        
        //play end dialogue
        Debug.Log("End Dialogue");
        yield return new WaitForSeconds(_endDelay);
        Debug.Log(taskList[currentTask].taskCompleteNarration);
    }
}
