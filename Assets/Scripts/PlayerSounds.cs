using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private float steprate = 0.1f;
    private float requirement = 0.1f;
   
    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        StartCoroutine(Footsteps());
    }
    IEnumerator Footsteps()
    {
        while (playerMovement.speed > requirement)
        {
            Debug.Log("Footstep has been stepped");
            //Play footstep sound
            yield return new WaitForSeconds(steprate);
        }
    }

}

    
