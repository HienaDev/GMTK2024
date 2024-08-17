using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PPCtrl : MonoBehaviour
{
    
    Volume              volume;
    Vignette            vt;
    ColorAdjustments    ca;
    Parry               parry;
    float iSpeed = 0.0f;
    float iSpeed2 = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        volume = GetComponent<Volume>();
        volume.profile.TryGet(out vt);//0-0.8
        volume.profile.TryGet(out ca);//0--100

        parry=FindObjectOfType<Parry>();

        Debug.Log(parry);
    }

    // Update is called once per frame
    void Update()
    {   
        if(parry.GetIsDying())
        {
            vt.intensity.value = Mathf.SmoothDamp(vt.intensity.value, 0.8f, ref iSpeed, 5f);
            ca.saturation.value = Mathf.SmoothDamp(ca.saturation.value, -100f, ref iSpeed2, 5f);
        }
        else
        {
            vt.intensity.value = 0;
            ca.saturation.value = 0;
        }
    }


}
