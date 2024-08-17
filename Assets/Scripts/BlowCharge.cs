using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlowCharge : MonoBehaviour
{
    [SerializeField] private KeyCode blowKey;
    [SerializeField] private Image blowCircle;
    [SerializeField] private float blowTime = 5f;
    private bool canBlow = true;
    private float blowTimer = 0;
    private float btSeconds;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(blowKey))
        {
            canBlow = false;
        }

        if (!canBlow)
        {
            blowTimer += Time.deltaTime;
            btSeconds = blowTimer % 60F;
            blowCircle.fillAmount = Mathf.InverseLerp(0f,blowTime,btSeconds);

            if (btSeconds >= blowTime) canBlow = true;
        }
        else
        {
            blowTimer = 0;
        }
    }
}
