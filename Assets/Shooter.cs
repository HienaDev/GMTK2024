using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class Shooter : MonoBehaviour
{

    [SerializeField] private int numberOfShots;
    private int shotsFired = 0;

    [SerializeField, Range(0, 100)] private int chanceOfParryable;

    [SerializeField] private bool stuckToTurret;
    [SerializeField] private GameObject[] shotPrefabs;
    [SerializeField] private float shotSpeed = 10f;
    [SerializeField] private bool randomRate = false;
    [SerializeField] private float shootingRate = 0.1f;
    private float defaultShootingRate;
    private float justShot;

    [SerializeField] private bool rotatingShot;
    [SerializeField] private float rotationValue = 5f;
    private Vector3 shotRotationIncrement;
    private Vector3 shotRotation;

    private bool doneShooting = false;

    [SerializeField] private UnityEvent doAfterShooting;

    // Start is called before the first frame update
    void Start()
    {
        shotRotationIncrement = new Vector3 (0, 0, rotationValue);
        shotRotation = Vector3.zero;

        defaultShootingRate = shootingRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - justShot > shootingRate && !doneShooting)
        {


            shotsFired++;

            justShot = Time.time;
            GameObject shotClone = null;

            if(stuckToTurret)
            {
                shotClone = Instantiate(shotPrefabs[Random.Range(0, shotPrefabs.Length)], transform);
            }
            else
            {
                shotClone = Instantiate(shotPrefabs[Random.Range(0, shotPrefabs.Length)]);
            }



            if (Random.Range(0, 100) < chanceOfParryable)
                shotClone.AddComponent<Parryable>();

            Rigidbody2D shotCloneRb = shotClone.GetComponent<Rigidbody2D>();
            
            if(shotCloneRb != null)
                shotCloneRb.velocity = transform.up * shotSpeed;

            shotClone.transform.position = transform.position;

            if (rotatingShot) 
                shotClone.GetComponentInChildren<ShotMother>().gameObject.transform.Rotate(shotRotation);

            shotRotation += shotRotationIncrement;

            shootingRate = Random.Range(defaultShootingRate - defaultShootingRate / 5, defaultShootingRate + defaultShootingRate / 5);


            if (shotsFired >= numberOfShots)
            {
                doneShooting = true;
                doAfterShooting.Invoke();
            }
        }
        
    }
}
