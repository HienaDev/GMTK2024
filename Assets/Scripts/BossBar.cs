using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BossBar : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private TextMeshProUGUI healthText;
    private float maxHealth;
    private float bossHealth;
    private GameObject bossObject;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = BossHealthManager.BossHealth;
    }

    // Update is called once per frame
    void Update()
    {
        bossHealth = BossHealthManager.BossHealth;
        healthBar.fillAmount = Mathf.InverseLerp(0f,maxHealth,bossHealth);
        healthText.text = $"{bossHealth:f0}/{maxHealth}";
    }
}
