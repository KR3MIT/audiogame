using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlateManager : MonoBehaviour
{
    public List<int> CorrectPlate = new List<int>();
    public List<int> CurrentPlate = new List<int>();
    public UnityEvent OnPuzzleComplete;
    
    void Start()
    {

    }
    public void PlateAdd(int plate)
    {
        CurrentPlate.Add(plate);
        PlateCheck();
    }
    private void PlateCheck()
    {
        int currentPlateCount = CurrentPlate.Count;

        for (int i = 0; i < currentPlateCount; i++)
        {
            if (CurrentPlate[i] != CorrectPlate[i])
            {
                CurrentPlate.Clear();
                Debug.Log("Incorrect Plate");
                PlayerBehavior.instance.TakeDamage(5);
                //play zap sound
                return;
            }
        }
        Debug.Log("Correct Plate "+ currentPlateCount);

        if (currentPlateCount == CorrectPlate.Count)
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
            Debug.Log("All Plates Correct");
            OnPuzzleComplete?.Invoke();
        }
    }
}

