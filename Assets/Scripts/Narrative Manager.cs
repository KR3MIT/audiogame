using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class NarrativeManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerInput input;
    public enum TaskType
    {
        None,
        LookAround,
        MoveAround,
        ThrowRock,
        Farewell,
    }
    public TaskType currentTask;

    void Start()
    {
        player = Camera.main.transform.root.gameObject;

        if (player.TryGetComponent(out playerMovement)) {}
        else
        {
            Debug.LogError("No playerMovement comp found");
            return;
        }

        if (player.TryGetComponent(out input)){}
        else
        {
            Debug.LogError("No playerInput comp found");
            return;
        }
        
        SetTask(TaskType.None);
    }

    void Update()
    {
        switch (currentTask)
        {
            case TaskType.LookAround:
                LookAround();
                break;
            case TaskType.MoveAround:
                MoveAround();
                break;
            case TaskType.ThrowRock:
                ThrowRock();
                break;
            case TaskType.Farewell:
                break;
            case TaskType.None:
                break;
        }
    }
    public void SetTask(TaskType task)
    {
        currentTask = task;
    }
    private void LookAround()
    {
        Vector2 look = input.actions["Look"].ReadValue<Vector2>();
        
        //insert dialogue
        
        if (look.magnitude > 0.5f)
        {
            //insert dialogue
            SetTask(TaskType.MoveAround);
        }
    }
    private void MoveAround()
    {
        Vector2 move = input.actions["Move"].ReadValue<Vector2>();
        
        //insert dialogue
        
        if (move.magnitude > 0.5f)
        {
            //insert dialogue
            SetTask(TaskType.ThrowRock);
        }
    }
    private void ThrowRock()
    {
        //insert dialogue
        
        if (input.actions["Attack"].triggered)
        {
            //insert dialogue
            SetTask(TaskType.Farewell);
        }
    }
    private void Farewell()
    {
        //insert dialogue
    }
}