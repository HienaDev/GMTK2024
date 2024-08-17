using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingShot : MonoBehaviour
{

    [SerializeField] private float sizeIncrement;
    private Vector3 incrementVector;

    // Start is called before the first frame update
    void Start()
    {
        incrementVector = new Vector3(sizeIncrement, sizeIncrement, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.localScale.x < 864)
        {
            transform.localScale += incrementVector * Time.deltaTime;

            sizeIncrement += (sizeIncrement / 5) * Time.deltaTime;
            incrementVector = new Vector3(sizeIncrement, sizeIncrement, 0);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
