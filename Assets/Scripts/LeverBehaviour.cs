using UnityEngine;
using UnityEngine.Events;

public class LeverBehaviour : MonoBehaviour, Iinteractables
{
    public UnityEvent OnLeverPulled;
  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.root.GetComponent<LeverManager>().OnComplete.AddListener(() => gameObject.SetActive(false));
    }

    public void Interact()
    {
        OnLeverPulled?.Invoke();
        Debug.Log("Lever has been pulled");
    }
}
