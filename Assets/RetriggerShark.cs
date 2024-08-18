using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetriggerShark : MonoBehaviour
{

    private GameObject shark;

    // Start is called before the first frame update
    void Start()
    {
        shark = FindObjectOfType<Shark>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerShark() => shark.GetComponent<Animator>().SetTrigger("BackToIdle");
}
