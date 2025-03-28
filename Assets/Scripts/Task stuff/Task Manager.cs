using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    [SerializeField] private bool onStart = false;
    [SerializeField] private List<Task> taskList;
    [SerializeField] private int currentTask = 0;
    public void Start()
    {
        if (onStart)
            StartNextTask();
    }
    private void StartNextTask()
    {
        if (currentTask == 0)
        {
            StartCoroutine(DialogueDelay());
        }
        if (currentTask == taskList.Count)
        {
            StartCoroutine(DialogueDelay());
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
    private IEnumerator DialogueDelay()
    {
        var _delay = taskList[currentTask].dialogueLength;
        //insert end dialogue here
        yield return new WaitForSeconds(_delay);
        CompleteTask();
    }
}