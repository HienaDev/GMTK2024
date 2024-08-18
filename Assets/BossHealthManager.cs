using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossHealthManager : MonoBehaviour
{
    private float bossHealth = 500;
    private float maxHealth;
    static public float BossHealth { get; private set; }
    private Rigidbody2D rb;

    private bool halfHealth = false;

    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Awake()
    {
        maxHealth = bossHealth;
        BossHealth = bossHealth;

        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        BossHealth = bossHealth;

        if(Input.GetKeyDown(KeyCode.Alpha9)) { Trigger2ndPhase(); }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PufferShot>() != null)
        {
            bossHealth -= 1;

            StartCoroutine(DamageBoss());

            if(bossHealth < maxHealth / 2 && !halfHealth)
            {
                PhaseManager.Instance.Trigger2ndPhase();
                Trigger2ndPhase();
            }

            if(bossHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void Trigger2ndPhase()
    {
        bossHealth = 240;
        GetComponent<Animator>().SetTrigger("2ndPhase");
        halfHealth = true;
        PhaseManager.Instance.Trigger2ndPhase();
    }

    IEnumerator DamageBoss()
    {
        sr.color = new Color32(255, 109, 109, 255);

        yield return 0;

        yield return 0;

        yield return 0;

        yield return 0;

        yield return 0;

        yield return 0;

        sr.color = Color.white;
    }
}
