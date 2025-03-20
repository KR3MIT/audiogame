using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    //events
    public static event System.Action FootstepEvent;
    
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
        StartCoroutine(Breathing());
    }

    void Update()
    {
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
    IEnumerator Breathing()
    {
        while (true)
        {
            //play breathing sound
            yield return new WaitForSeconds(breathRate);
            
        }
    }
    IEnumerator Footsteps()
    {
        while (true)
        {
            if (playerMovement.speed > threshold)
            {
                //Debug.Log("Footstep has been stepped");
                FootstepEvent?.Invoke();
            }

            //dogshit, iykyk
           yield return new WaitForSeconds(steprate * (playerMovement.speed / playerMovement.movespeed));
        }
    }

}   



