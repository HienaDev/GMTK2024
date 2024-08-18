using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    private float rotatedValue = 0;
    private bool rotate = false;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        if (rotatedValue < 230)
        {
            Debug.Log("rotation");
            rotatedValue += rotationSpeed * Time.deltaTime;

            transform.Rotate(new Vector3(0f, 0f, -rotationSpeed * Time.deltaTime));

        }
        else if (!rotate)
        {
            gameObject.transform.parent.gameObject.SetActive(false);
            Debug.Log("swipe triggered new phase");
            PhaseManager.Instance.PhaseEnded();
            rotate = true;
        }
    }



    
}
