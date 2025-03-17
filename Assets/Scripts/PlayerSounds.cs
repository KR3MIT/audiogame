using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    private PlayerMovement playerMovement;
    public float steprate = 0.2f;
    public float requirement = 0.1f;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        StartCoroutine(Footsteps());
    }
    IEnumerator Footsteps()
    {
        while (true)
        {
            if (playerMovement.speed > requirement)
            {
                Debug.Log("Footstep has been stepped");
                //Play footstep 
            }

            // dogshit, iykyk
            yield return new WaitForSeconds(steprate * (playerMovement.speed/playerMovement.movespeed));
        }
    }

}


