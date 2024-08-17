using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parry : MonoBehaviour
{
    private Boolean isParrying;
    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        isParrying=false;
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("Parry");
        }

    }

    public void ActivateParry()
    {
        isParrying=true;
        Debug.Log("Parry");
    }

    public void DeactivateParry()
    {
        isParrying=false;
        Debug.Log("UnParry");
    }

    //TODO:
    //Detect collision with bullet
    //Verify parry success, if is Parrying and collision has Parriable component
    //Otherwise on hit set in dying state
    //Black and White fade in for 10 secs or so
    //Parry during that time removes dying state
    //Otherwise die and reset
}
