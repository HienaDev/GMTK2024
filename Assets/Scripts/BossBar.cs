using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BossBar : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private float bossHealth;
    [SerializeField] private float maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        bossHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = Mathf.InverseLerp(0f,maxHealth,bossHealth);
        healthText.text = $"{bossHealth:f0}/{maxHealth}";
    }
}
