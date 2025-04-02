using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;


public class FairyController : MonoBehaviour
{
    public SplineAnimate splineAnimate;
    public List<SplineContainer> splines;
    int currentSpline = 0;
    bool hasPlayedOnSpline = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SplineAnimate splineAnimate = GetComponent<SplineAnimate>();
        splineAnimate.Container = splines[currentSpline];
    }

    // Update is called once per frame
    void Update()
    {
        if (splineAnimate.IsPlaying == false && hasPlayedOnSpline == true)
        {
            //splineAnimate.Restart(false);
            //splineAnimate.Container = splines[currentSpline];
            //hasPlayedOnSpline = false;
            StartCoroutine(SwitchSpline());
            //splineAnimate.Pause();

        }
    }

    IEnumerator SwitchSpline()
    {
        hasPlayedOnSpline = false;
        splineAnimate.Restart(false);
        splineAnimate.Container = splines[currentSpline];
        splineAnimate.Play();
        yield return new WaitForSeconds(0.01f);
        //splineAnimate.Pause();
        splineAnimate.Restart(false);
    }



    void OnTriggerEnter(Collider other)
    {
        Debug.Log(splineAnimate.IsPlaying);
        if (other.gameObject.tag == "Player" && splineAnimate.IsPlaying != true)
        { 
            splineAnimate.Play();
            currentSpline++;
            hasPlayedOnSpline = true;
            Debug.Log("Triggered");

        }

    }


}

