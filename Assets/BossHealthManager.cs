using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossHealthManager : MonoBehaviour
{
    private float bossHealth = 500;
    static public float BossHealth { get; private set; }
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Awake()
    {
        BossHealth = bossHealth;
    }

    // Update is called once per frame
    void Update()
    {
        BossHealth = bossHealth;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PufferShot>() != null)
        {
            bossHealth -= 5;
        }
    }

}
