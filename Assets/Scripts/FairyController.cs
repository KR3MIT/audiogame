using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Splines;


public class FairyController : MonoBehaviour
{
    public SplineAnimate splineAnimate;
    public List<SplineContainer> splines;
    int currentSpline = 0;
    bool hasPlayedOnSpline = false;
    public AK.Wwise.Event fairyFlyAwaySound;
    public AK.Wwise.Event fairyBellSound;
    public AK.Wwise.Event pauseFairyBellSound;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
        fairyBellSound.Post(gameObject);
        yield return new WaitForSeconds(0.01f);
        splineAnimate.Pause();
        splineAnimate.Restart(false);
    }



    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && splineAnimate.IsPlaying != true)
        {
            pauseFairyBellSound.Post(gameObject);
            fairyFlyAwaySound.Post(gameObject);
            splineAnimate.Play();
            hasPlayedOnSpline = true;

        }

    }


}

