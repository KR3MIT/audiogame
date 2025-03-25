using UnityEngine;

public class TriggerRockPuzzle : MonoBehaviour
{
[SerializeField] private float currentForce;
[SerializeField] private float forceMultiplier = 1.5f;
[SerializeField] private bool setCustomForce = false;
[SerializeField] private float customForce = 20f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            currentForce = other.GetComponent<PlayerThrow>().force;
            if (setCustomForce)
            {
                other.GetComponent<PlayerThrow>().force = customForce;
            }
            else
            {
                other.GetComponent<PlayerThrow>().force = currentForce * forceMultiplier;
            }
            
        }
       
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerThrow>().force = currentForce;
        }
        
    }

}
