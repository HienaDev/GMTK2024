using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleShotExplosion : MonoBehaviour
{

    [SerializeField] private GameObject shot;
    [SerializeField] private int numberOfShots;
    [SerializeField] private float shotSpeed = 100;

    [SerializeField, Range(0, 100)] private int chanceOfParryable;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberOfShots; i++)
        {
            GameObject shotClone = Instantiate(shot);
            shotClone.transform.position = transform.position;
            shotClone.transform.localEulerAngles = new Vector3(0, 0, (float)i / (float)numberOfShots * 360f);
            shotClone.GetComponent<Rigidbody2D>().velocity = shotClone.transform.up * shotSpeed;

            if (Random.Range(0, 100) < chanceOfParryable)
                shotClone.AddComponent<Parryable>();

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
