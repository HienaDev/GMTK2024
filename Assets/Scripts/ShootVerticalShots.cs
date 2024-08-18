using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShootVerticalShots : MonoBehaviour
{

    [SerializeField] private int numberOfShots;
    private int shotsFired = 0;

    [SerializeField, Range(0, 100)] private int chanceOfParryable;

    [SerializeField] private GameObject[] shotPrefabs;
    [SerializeField] private float shotSpeed = 10f;
    [SerializeField] private float shootingRate = 0.1f;
    private float justShot;

    private bool doneShooting = false;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - justShot > shootingRate && !doneShooting)
        {


            shotsFired++;

            justShot = Time.time;
            GameObject shotClone = null;

            float randomX = Random.Range(-110, 110);

            shotClone = Instantiate(shotPrefabs[Random.Range(0, shotPrefabs.Length)]);




            if (Random.Range(0, 100) < chanceOfParryable)
                shotClone.AddComponent<Parryable>();

            FishShot shotCloneRb = shotClone.GetComponentInChildren<FishShot>();

            if (shotCloneRb != null)
                shotCloneRb.SetShotSpeed( transform.up * -shotSpeed);

            shotClone.transform.position = new Vector2(randomX, shotClone.transform.position.y);

            if (shotsFired >= numberOfShots && !doneShooting)
            {
                doneShooting = true;
                Debug.Log("vertical shots triggered new phase");
                //PhaseManager.Instance.PhaseEnded();
            }
        }

    }
}
