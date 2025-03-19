using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private CharacterController controller;
    public float steprate = 0.2f;
    public float threshold = 0.1f;
    [Header("Breathing")]
    public float breathDelay = 5;
    public float breathRate = 1;
    [Header("Falling")]
    public float time;
    [Tooltip("The time is contained in this floaaat")]
    
    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        controller = GetComponent<CharacterController>();
        StartCoroutine(Footsteps());

    }

    void Update()
    {
        
        #region Breathing
        time += Time.deltaTime;
        if (breathDelay < time)
        {
            /// play breathing sound
            time = 0;
        }
        #endregion
        #region Falling
        if (controller.velocity.y < -1)
        {
            // play fall sound
            Debug.Log("A light fall was fallen");
        }
        else if (controller.velocity.y < -9)
        {
            // play heavy fall sound
            Debug.Log("A heavy fall was fallen");
        }
        #endregion
    }

    IEnumerator Footsteps()
    {
        while (true)
        {
            if (playerMovement.speed > threshold)
            {
                Debug.Log("Footstep has been stepped");
                //Play footstep
            }

            //dogshit, iykyk
           yield return new WaitForSeconds(steprate * (playerMovement.speed / playerMovement.movespeed));
        }
    }

}   



