using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BossBar : MonoBehaviour
{
    [SerializeField] private Image Healthbar;
    [SerializeField] private TextMeshProUGUI Healthtext;
    [SerializeField] private float BossHealth;
    [SerializeField] private float MaxHealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Healthbar.fillAmount = Mathf.InverseLerp(0f,MaxHealth,BossHealth);
        Healthtext.text = $"{BossHealth:f0}/{MaxHealth}";
    }
}
