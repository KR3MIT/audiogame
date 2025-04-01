using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;


public class FairyController : MonoBehaviour
{
    public SplineAnimate splineAnimate;
    public List<SplineContainer> splines;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SplineAnimate splineAnimate = GetComponent<SplineAnimate>();
       
        splineAnimate.Container = splines[1];
        splineAnimate.Play();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

