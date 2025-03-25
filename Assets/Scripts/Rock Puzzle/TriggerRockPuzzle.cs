using UnityEngine;

public class TriggerRockPuzzle : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //other.GetComponent<PlayerThrow>().TriggerRock();
        }
       
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //other.GetComponent<PlayerThrow>().UnTriggerRock();
        }
        
    }

}
