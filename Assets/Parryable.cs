using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parryable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(GetComponent<SpriteRenderer>().color);
        GetComponent<SpriteRenderer>().color = new Color32(255, 7, 137, 100);
        Debug.Log(GetComponent<SpriteRenderer>().color);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
