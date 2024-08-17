using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishShot : MonoBehaviour
{

    [SerializeField] private GameObject fishShot;
    private Vector2 shotSpeed;

    public void ActivateShot()
    {
        fishShot.SetActive(true);
        fishShot.GetComponent<Rigidbody2D>().velocity = shotSpeed;
    }

    public void SetShotSpeed(Vector2 speed) => shotSpeed = speed;
}
