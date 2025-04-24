using UnityEngine;
using UnityEngine.Events;

public class AllowRock : MonoBehaviour
{
    public UnityEvent OnEnter;

    private void OnTriggerEnter(Collider other)
    { 
        if (other.TryGetComponent(out PlayerThrow playerthrow))
        {
            playerthrow.enabled = true;
            OnEnter?.Invoke();
            Destroy(gameObject);
        }

    }
 
}
