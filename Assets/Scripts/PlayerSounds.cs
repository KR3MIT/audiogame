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

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        StartCoroutine(Breathing());

        PlayerMovement.OnMove += () =>
        {
            if (footstepCoroutine == null)
            {
                footstepCoroutine = StartCoroutine(Footsteps());
            }
        };
        PlayerMovement.OnStopMove += () =>
        {
            if (footstepCoroutine != null)
            {
                StopCoroutine(footstepCoroutine);
                footstepCoroutine = null;
            }
        };
    }

    void Update()
    {
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

    IEnumerator Footsteps()
    {
        while (true)
        {
            if (PlayerMovement.NormalizedSpeed > threshold)
            {
                //Debug.Log("Footstep has been stepped");
                if (PlayerBehavior.WwiseActive)
                    FootstepEvent?.Invoke();
            }

            float adjustedStepRate = steprate * (1 / Mathf.Max(PlayerMovement.NormalizedSpeed, 0.1f));
            yield return new WaitForSeconds(adjustedStepRate);
        }
    }
}