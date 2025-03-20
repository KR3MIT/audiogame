using UnityEngine;

public class NarrativeManager : MonoBehaviour
{
    public enum TaskType
    {
        None,
        MoveAround,
        ThrowRock,
        Farewell,
    }
    public TaskType currentTask;
    void Start()
    {
        SetTask(TaskType.None);
    }
    public void SetTask(TaskType task)
    {
        currentTask = task;
        switch (task)
        {
            case TaskType.MoveAround:
                MoveAround();
                Debug.Log("Move around the area to get a feel for the environment");
                break;
            case TaskType.ThrowRock:
                Debug.Log("Throw a rock");
                break;
            case TaskType.Farewell:
                Debug.Log("GO on");
                break;
            case TaskType.None:
                Debug.Log("No task assigned.");
                break;
        }
    }

    private void MoveAround()
    {
        //play sound
        //if (condition met)
        //{
        //    SetTask(TaskType.ThrowRock);
        //}
    }
}
