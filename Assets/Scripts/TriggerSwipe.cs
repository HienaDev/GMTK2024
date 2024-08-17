using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSwipe : MonoBehaviour
{
    [SerializeField] private GameObject swipeAttack;


    public void SwipeAttack()
    {
        swipeAttack.SetActive(true);
        GetComponentInChildren<SpriteRenderer>().enabled = false;
    }
}
