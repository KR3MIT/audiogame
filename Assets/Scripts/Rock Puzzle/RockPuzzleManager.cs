using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RockPuzzleManager : MonoBehaviour
{
    [Header("List of Destroyable Objects")]
    [SerializeField] private List<GameObject> childObjects = new List<GameObject>();

    [Header("Rock Throw Settings")]
    [SerializeField] private float currentForce;
    [SerializeField] private float forceMultiplier = 2f;
    [SerializeField] private float newForce;
    [SerializeField] private bool setCustomForce = false;
    [SerializeField] private float customForce = 20f;

public UnityEvent OnVictory;

    void Start()
    {
        // Record the current force value
        currentForce = PlayerThrow.force;
        // Populate the list with all child objects
        foreach (Transform child in transform)
        {
            childObjects.Add(child.gameObject);
            child.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        // Check if all child objects are destroyed
        bool allDestroyed = true;

        foreach (GameObject obj in childObjects)
        {
            if (obj != null)
            {
                allDestroyed = false;
                break;
            }
        }

        if (allDestroyed)
        {
            OnVictory?.Invoke();
            Debug.Log("All the spheres are destroyed!");
        }
    }

public void StartPuzzle()
    {
        foreach (GameObject obj in childObjects)
        {
            obj.SetActive(true);
        }
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartPuzzle();
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
