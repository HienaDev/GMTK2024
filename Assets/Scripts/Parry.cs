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
    private float immunityTimer;
    private SpriteRenderer sr;
    
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
                        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                        Debug.Log("Died, Reloading");
                    }
                }
                
            }
        }
    }
}
