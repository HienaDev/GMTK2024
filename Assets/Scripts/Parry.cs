using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Parry : MonoBehaviour
{
    private Boolean isParrying;
    private Boolean isDying;
    private Boolean isImmune;
    private Animator animator;
    [SerializeField]
    private GameObject gameOver;

    [SerializeField]
    private float immunityTimer;
    private SpriteRenderer sr;

    //bleedout timer
    [SerializeField]
    private float bleedoutTime = 8.0f;
    private float elapsedTime = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        isParrying=false;
        animator = gameObject.GetComponent<Animator>();
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("Parry");
        }

        if(isDying)
        {
            elapsedTime += Time.deltaTime;
            if(elapsedTime >= bleedoutTime)
            {
                DeathLoop();
                isDying=false;
            }
        }

    }

    public Boolean GetIsDying()
    {
        return isDying;
    }

    public void ActivateParry()
    {
        isParrying=true;
        Debug.Log("Parry");
    }

    public void DeactivateParry()
    {
        isParrying=false;
        animator.ResetTrigger("Parry");
        Debug.Log("UnParry");
    }

    public void ActivateImmunity()
    {
        isImmune=true;
        sr.color = Color.red;
        StartCoroutine(Immunity());
    }

    public void DeactivateImmunity()
    {
        isImmune=false;
        sr.color = Color.white;
    }

    private IEnumerator Immunity()
    {
        yield return new WaitForSeconds(immunityTimer);
        DeactivateImmunity();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.GetComponent<Shot>())
        {
            if(col.gameObject.GetComponent<Parryable>() && isParrying)
            {
                Debug.Log("Parried");
                if(isDying)
                    isDying=false;
                    elapsedTime=0.0f;
                    Debug.Log("is Not Dying");
            }
            else
            {
                if(!isImmune)
                {
                    Debug.Log("Hit");
                    if(!isDying)
                    {
                        isDying=true;
                        ActivateImmunity();
                        Debug.Log("isDying");
                    }else
                    {
                        //TODO:Proper Death handling
                        DeathLoop();
                        Debug.Log("Died, Reloading");
                    }
                }
                
            }
        }
    }

    private void DeathLoop()
    {
        gameOver.SetActive(true);
        PhaseManager pm = FindFirstObjectByType<PhaseManager>();
        pm.enabled = false;
        Movement mv = FindFirstObjectByType<Movement>();
        mv.StopMvmt();
        mv.enabled = false;
        
    }
}
