using UnityEngine.Events;
using UnityEngine;

public class TaskSubscriber : MonoBehaviour
{
    private TaskManager taskManager;
    [SerializeField] private Task taskToSubscribe;

    public UnityEvent test;

    private void Awake()
    {
        taskManager = GetComponent<TaskManager>();
    }

    public void Initialize()
    {
        UnityEvent taskEvent = taskManager.GetTaskEvent(taskToSubscribe);
        if (taskEvent != null)
        {
            taskEvent.AddListener(OnTaskCompleted);
        }
    }

    private void OnTaskCompleted()
    {
        Debug.Log($"Task {taskToSubscribe.name} completed!");
        test?.Invoke();
    }
}
