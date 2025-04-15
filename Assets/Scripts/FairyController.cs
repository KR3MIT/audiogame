using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;


public class FairyController : MonoBehaviour
{
    public SplineAnimate splineAnimate;
    public List<SplineContainer> splines;
    public int currentSpline = 0;
    bool hasPlayedOnSpline = false;
    public AK.Wwise.Event fairyFlyAwaySound;
    public AK.Wwise.Event fairyBellSound;
    public AK.Wwise.Event pauseFairyBellSound;
    private bool hasReachedEndOfSplines = false;

    public static FairyController instance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        SplineAnimate splineAnimate = GetComponent<SplineAnimate>();
        splineAnimate.Container = splines[currentSpline];
    }

    // Update is called once per frame
    void Update()
    {
        if (splineAnimate.IsPlaying == false && hasPlayedOnSpline == true && currentSpline != splines.Count - 1)
        {

            StartCoroutine(SwitchSpline());

        }
    }

    IEnumerator SwitchSpline()
    {
        currentSpline++;
        hasPlayedOnSpline = false;
        splineAnimate.Container = splines[currentSpline];
        splineAnimate.Play();
        yield return new WaitForSeconds(0.01f);
        splineAnimate.Pause();
        splineAnimate.Restart(false);
    }

    public IEnumerator Backtrack(int triggerID)
    {
        currentSpline = triggerID;
        hasPlayedOnSpline = false;
        splineAnimate.Container = splines[currentSpline];
        splineAnimate.Play();
        yield return new WaitForSeconds(0.01f);
        splineAnimate.Pause();
        splineAnimate.Restart(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && splineAnimate.IsPlaying != true)
        {   
            Debug.Log("Current spline: " + currentSpline + " spline count:" + splines.Count);

            if (hasReachedEndOfSplines == false)
            {
                pauseFairyBellSound.Post(gameObject);
                fairyFlyAwaySound.Post(gameObject);
            }
            splineAnimate.Play();
            hasPlayedOnSpline = true;
            if (currentSpline == splines.Count - 1)
            {
                hasReachedEndOfSplines = true;
            }

        }

    }


}

