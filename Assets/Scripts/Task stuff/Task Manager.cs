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

    private Dictionary<Task, UnityEvent> taskEventRelays = new Dictionary<Task, UnityEvent>();
    public void Start()
    {
        foreach (var task in taskList)
        {
            UnityEvent relayEvent = new UnityEvent();
            taskEventRelays[task] = relayEvent;

            // Subscribe to the task's taskCompletedEvent
            task.taskCompletedEvent.AddListener(() => relayEvent.Invoke());
        }

        if (onStart)
            StartNextTask();



        foreach(var subscriber in GetComponents<TaskSubscriber>())
        {
            subscriber.Initialize();
        }
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

    public UnityEvent GetTaskEvent(Task task)
    {
        if (taskEventRelays.TryGetValue(task, out var relayEvent))
        {
            return relayEvent;
        }

        Debug.LogWarning($"Task {task.name} does not exist in the task list.");
        return null;
    }
}