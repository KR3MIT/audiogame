using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RockPuzzleManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> childObjects = new List<GameObject>();
public UnityEvent OnVictory;

    void Start()
    {
        // Populate the list with all child objects
        foreach (Transform child in transform)
        {
            childObjects.Add(child.gameObject);
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



}
