using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Task", menuName = "Scriptable Objects/Task")]
public class Task : ScriptableObject
{ 
    public string taskStartNarration;
    public string taskCompleteNarration;
    public float dialogueLength;
    
    public UnityEvent onTaskStart;
    public UnityAction onTaskComplete;
    public UnityEvent taskCompletedEvent;

    public bool isActiveTask;
    public bool shouldMoveFairyOnComplete;

    public bool both;
    public int taskToRepeat;
    
    public AK.Wwise.Event taskSound;
    public AK.Wwise.Event endTaskSound;
    public virtual void StartTask(UnityAction onTaskCompleteCallback)
    {
        StartDialogue();
        isActiveTask = true;
        onTaskStart?.Invoke();
        onTaskComplete = onTaskCompleteCallback;
    }
    
    public void StartDialogue()
    {
        PlayTaskSound();
    }

    public void EndDialogue()
    {
        PlayEndTaskSound();
    }
    
    public void CompleteTask()
    {
        if (!isActiveTask) { return; }
        isActiveTask = false;
        
        EndDialogue();
        if (onTaskComplete == null)
        {
            return;
        }
        onTaskComplete?.Invoke();
        taskCompletedEvent?.Invoke();
        if (shouldMoveFairyOnComplete) { FairyController.instance.TutorialSwitchSpline(); }
        onTaskComplete = null;
    }

    public void PlayTaskSound()
    {
        if(taskSound == null) { return; }
        taskSound.Post(FairyController.instance.gameObject);
    }
    public void PlayEndTaskSound()
    {
        if(taskSound == null) { return; }
        endTaskSound.Post(FairyController.instance.gameObject);
    }
}
