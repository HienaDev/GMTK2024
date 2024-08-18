using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSwimmingAround : MonoBehaviour
{
    [SerializeField] private Animator animatorAround;
    [SerializeField] private ShootTowardsPlayer shooting;

    public void TriggerSwim()
    {
        animatorAround.enabled = true;
        shooting.enabled = true;
    }
}
