using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    [SerializeField] private int numberOfShots;
    private int shotsFired = 0;

    [SerializeField] private bool stuckToTurret;
    [SerializeField] private GameObject[] shotPrefabs;
    [SerializeField] private float shotSpeed = 10f;
    [SerializeField] private float shootingRate = 0.1f;
    private float justShot;

    [SerializeField] private bool rotatingShot;
    [SerializeField] private float rotationValue = 5f;
    private Vector3 shotRotationIncrement;
    private Vector3 shotRotation;

    // Start is called before the first frame update
    void Start()
    {
        shotRotationIncrement = new Vector3 (0, 0, rotationValue);
        shotRotation = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - justShot > shootingRate && shotsFired < numberOfShots)
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

            Rigidbody2D shotClonrRb = shotClone.GetComponent<Rigidbody2D>();
            
            if(shotClonrRb != null)
                shotClonrRb.velocity = transform.right * shotSpeed;

            shotClone.transform.position = transform.position;

            if (rotatingShot) 
                shotClone.GetComponentInChildren<ShotMother>().gameObject.transform.Rotate(shotRotation);

            shotRotation += shotRotationIncrement;
        }
        
    }
}
