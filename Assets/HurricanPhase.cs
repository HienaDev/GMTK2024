using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurricanPhase : MonoBehaviour
{
    [SerializeField] private float phaseDuration = 30;



    [SerializeField] private GameObject hurricanePrefab;
    [SerializeField] private float spawnRate;
    private float justSpawned;
    [SerializeField] private Vector2 area = new Vector2(200, 110);


    private float startedPhase;

    // Start is called before the first frame update
    void Start()
    {
        startedPhase = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - justSpawned > spawnRate && Time.time - startedPhase < phaseDuration)
        {

            justSpawned = Time.time;
            GameObject hurricaneClone = Instantiate(hurricanePrefab);
            hurricaneClone.transform.position = new Vector2(Random.Range(-area.x, area.x), Random.Range(-area.y, area.y));


        }
        else if (Time.time - startedPhase >= phaseDuration)
        {
            PhaseManager.Instance.PhaseEnded();
        }
    }
}
