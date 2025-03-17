using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    private PlayerMovement playerMovement;
    public float steprate = 0.2f;
    public float requirement = 0.1f;

    public float breathDelay = 5;
    public float breathRate = 1;
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
            StartCoroutine(Breath());
            time = 0;
        }


        if (transform.position.y <= -5)
        {
            // play fall sound
            Debug.Log("A fall was fallen");
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

    IEnumerator Breath()
    {
        //play breathing 
        Debug.Log("A breath was breathed");
        yield return new WaitForSeconds(breathRate);
    }
    
   
}   



