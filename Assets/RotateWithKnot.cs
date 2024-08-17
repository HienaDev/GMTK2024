using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class RotateWithKnot : MonoBehaviour
{

    private SplineAnimate spline;

    // Start is called before the first frame update
    void Start()
    {
        spline = GetComponent<SplineAnimate>();    
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(spline.Container);
    }
}
