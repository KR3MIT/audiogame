using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TaskManager : MonoBehaviour
{
    public UnityEvent tutorialComplete;
    private bool _coroutineRunning;

    public UnityEvent onAnyTaskComplete;
    
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
        StartCoroutine(DialogueDelay());
    }
    void EndTutorial()
    {
        if (currentTask == taskList.Count && !_coroutineRunning)
        {
            tutorialComplete.Invoke();
        }
    }
    private void CompleteTask()
    {
        currentTask++;
        onAnyTaskComplete?.Invoke();
        StartNextTask();
    }
    private IEnumerator DialogueDelay()
    {
        _coroutineRunning = true;
        var _delay = taskList[currentTask].dialogueLength;
        yield return new WaitForSeconds(_delay);
        taskList[currentTask].StartTask(CompleteTask);
        _coroutineRunning = false;
        EndTutorial();
    }
}