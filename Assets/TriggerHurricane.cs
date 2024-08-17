using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHurricane : MonoBehaviour
{
    [SerializeField] private GameObject swipeAttack;


    public void SwipeAttack()
    {
        swipeAttack.SetActive(true);
        GetComponent<SpriteRenderer>().enabled = false;
    }
}
