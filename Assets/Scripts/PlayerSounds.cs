using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    private PlayerMovement playerMovement;
    public float steprate = 0.2f;
    public float requirement = 0.1f;

    public float breathDelay = 5;
    public float time;
    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        StartCoroutine(Footsteps());
     
    }

    void Update()
    {
        // Oskar made this, dont hate him for it, he tried his best. 
        time += Time.deltaTime;
        
        if (breathDelay < time)
        {
            //play breath sound
            Debug.Log("breaaath");
            time = 0;
        }

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

            //dogshit, iykyk
           yield return new WaitForSeconds(steprate * (playerMovement.speed / playerMovement.movespeed));
        }
    }

    //IEnumerable Breath()
    //{
    //    //play breathing sound
    //    Debug.Log("a breath was breathed")
    //      yield return new WaitForSeconds(steprate * (playerMovement.speed / playerMovement.movespeed));
    //}
    // maybe make breath connected to speed?
}   



