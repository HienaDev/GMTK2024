using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.Events;

public class ShootTowardsPlayer : MonoBehaviour
{

    [SerializeField] private int numberOfShots;
    private int shotsFired = 0;

    [SerializeField, Range(0, 100)] private int chanceOfParryable;

    [SerializeField] private GameObject[] shotPrefabs;
    [SerializeField] private float shotSpeed = 10f;
    [SerializeField] private float shootingRate = 0.1f;
    private float justShot;

    private Movement player;

    private bool doneShooting = false;

    [SerializeField] private UnityEvent doAfterShooting;

    [SerializeField] private bool intervaleBetweenShots = false;
    [SerializeField] private int numberOfShotsBetweenInterval;
    [SerializeField] private int shotInterval;
    private bool interval;
    private int intervalShot = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Movement>();
        interval = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - justShot > shootingRate && !doneShooting)
        {

            if(!interval)
            {
                shotsFired++;
                

                
                GameObject shotClone = null;


                shotClone = Instantiate(shotPrefabs[Random.Range(0, shotPrefabs.Length)]);

                if (Random.Range(0, 100) < chanceOfParryable)
                    shotClone.AddComponent<Parryable>();

                Rigidbody2D shotCloneRb = shotClone.GetComponent<Rigidbody2D>();

                if (shotCloneRb != null)
                    shotCloneRb.velocity = (player.transform.position - transform.position).normalized * shotSpeed;


                shotClone.transform.position = transform.position;

                if (shotsFired >= numberOfShots)
                {
                    doneShooting = true;
                    doAfterShooting.Invoke();
                }
            }

            intervalShot++;
            justShot = Time.time;

            Debug.Log(interval);
            //Debug.Log(intervalShot);

            if (intervalShot >= numberOfShotsBetweenInterval && !interval)
            {
                Debug.Log("interval = true");
                interval = true;
                intervalShot = 0;   
            }
            else if(intervalShot >= shotInterval && interval)
            {
                Debug.Log("interval = false");
                interval = false; 
                intervalShot = 0;
            }
                
        }

    }
}
