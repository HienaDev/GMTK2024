using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    private float rotatedValue = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rotatedValue < 200)
        {
            rotatedValue += rotationSpeed * Time.deltaTime;

            transform.Rotate(new Vector3(0f, 0f, -rotationSpeed * Time.deltaTime));
        }
    }
}
