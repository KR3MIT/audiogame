using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    //events
    public static event System.Action FootstepEvent;

    private CharacterController controller;
    public float steprate = 0.2f;
    public float threshold = 0.1f;
    [Header("Breathing")] public float breathDelay = 5;
    public float breathRate = 1;
    [Header("Falling")] public float time;

    [Tooltip("The time is contained in this floaaat")]
    private Coroutine footstepCoroutine;

    private float lastFootstepTime;
    private bool isMoving;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        StartCoroutine(Breathing());

        PlayerMovement.OnMove += () => { isMoving = true; };
        PlayerMovement.OnStopMove += () => { isMoving = false; };
    }

    void Update()
    {
        float speedFactor = Mathf.Lerp(2.0f, 1.0f, PlayerMovement.NormalizedSpeed);
        float adjustedStepRate = steprate * speedFactor;
        
        if (isMoving & Time.time - lastFootstepTime > adjustedStepRate)
        {
            if (PlayerBehavior.WwiseActive)
            {
                FootstepEvent?.Invoke();
                lastFootstepTime = Time.time;
            }
        }


        #region Falling

        if (controller.velocity.y < -1)
        {
            // play fall sound
            //Debug.Log("A light fall was fallen");
        }
        else if (controller.velocity.y < -9)
        {
            // play heavy fall sound
            //Debug.Log("A heavy fall was fallen");
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

}