using Unity.VisualScripting;
using UnityEngine;

public class TriggerRockPuzzle : MonoBehaviour
{
[SerializeField] private float currentForce;
[SerializeField] private float forceMultiplier = 1.5f;
[SerializeField] private float newForce;
[SerializeField] private bool setCustomForce = false;
[SerializeField] private float customForce = 20f;


    void Start()
    {
        currentForce = PlayerThrow.force;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            newForce = currentForce * forceMultiplier;

            PlayerThrow.force = newForce;

            if (setCustomForce)
            {
                PlayerThrow.force = customForce;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerThrow.force = currentForce;
        }
    }
}
