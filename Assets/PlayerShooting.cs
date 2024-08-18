using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    [SerializeField] private float shootingRate = 0.2f;
    private float justShot;

    [SerializeField] private GameObject shotPrefab;
    [SerializeField] private float shootingSpeed = 200f;

    private bool shooting;

    // Start is called before the first frame update
    void Start()
    {
        shooting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) { shooting = true; }

        if (Time.time - justShot > shootingRate && shooting) //&& not parrying)
        {
            justShot = Time.time;
            GameObject shotClone = Instantiate(shotPrefab);
            shotClone.transform.position = transform.position;
            shotClone.GetComponent<Rigidbody2D>().velocity = transform.up * shootingSpeed;
        }
    }

    public void IncreaseShotSpeed(float multiplier)
    {
        shootingRate /= multiplier;
    }

    public void DecreaseShotSpeed(float multiplier)
    {
        shootingRate *= multiplier;
    }
}
