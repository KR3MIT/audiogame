using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
public class TaskManager : MonoBehaviour
{
    public UnityEvent tutorialComplete;
    private bool _coroutineRunning;
    
    [SerializeField] private bool onStart = false;
    [SerializeField] private List<Task> taskList;
    [SerializeField] private int currentTask = 0;
    
    public float timeTillRepeatDialogue = 2f;
    private bool canRepeat = false;
    public PlayerInput playerInput;
    private Coroutine delayRepeatCoroutine;
    
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

        #if UNITY_EDITOR
            playerInput.actions["RepeatDialogue"].performed += ctx => RepeatDialogue();
        #endif

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
        if (currentTask == taskList.Count)
        {
            return;
        }
        
        currentTask++;
        StartNextTask();
    }
    private IEnumerator DialogueDelay()
    {
        if (delayRepeatCoroutine != null)
        {
            StopCoroutine(delayRepeatCoroutine);
            delayRepeatCoroutine = null;
        }
        
        delayRepeatCoroutine = StartCoroutine(RepeatDelay());
        
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
    
    void RepeatDialogue()
    {
        /*if (canRepeat)
        {
            taskList[currentTask].StartDialogue();
            Debug.Log("lmao sound repeated!");
            if(currentTask != 0 && taskList[currentTask].taskSound == null)
            {
                taskList[currentTask - 1].EndDialogue();
                Debug.Log("lmao sound -1");
                
                if (taskList[currentTask - 1].endTaskSound == null)
                {
                    taskList[currentTask - 2].EndDialogue();
                        Debug.Log("lmao sound -2");
                }
            }
        }*/
    }

    private IEnumerator RepeatDelay()
    {
        canRepeat = false;
        yield return new WaitForSeconds(timeTillRepeatDialogue);
        
        if (taskList[currentTask].both)
        {
            taskList[taskList[currentTask].taskToRepeat].StartDialogue();
        }
        else
        {
            taskList[taskList[currentTask].taskToRepeat].StartDialogue();
            taskList[taskList[currentTask].taskToRepeat].EndDialogue();
        }
        
        canRepeat = true;
        delayRepeatCoroutine = StartCoroutine(RepeatDelay());
    }
}