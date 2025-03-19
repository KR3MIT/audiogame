using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    private PlayerMovement playerMovement;
    public float steprate = 0.2f;
    public float requirement = 0.1f;
    [Header("Breathing")]
    public float breathDelay = 5;
    public float breathRate = 1;
    [Header("Falling")]
    public float time;
    [Tooltip("The time is contained in this floaaat")]
    
    private void Start()
    {

        playerMovement = GetComponent<PlayerMovement>();
        StartCoroutine(Footsteps());
    }

    void Update()
    {
        #region Breathing
        time += Time.deltaTime;
        if (breathDelay < time)
        {
            StartCoroutine(Breath());
            time = 0;
        }
        #endregion
        #region Falling
        if (transform.position.y <= -5)
        {
            // play fall sound
            Debug.Log("A fall was fallen");
        }
        #endregion
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



