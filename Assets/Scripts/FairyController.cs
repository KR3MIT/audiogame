using NUnit.Framework;
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
            splineAnimate.Pause();
            
            splineAnimate.Container = splines[currentSpline];
            
        }
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

