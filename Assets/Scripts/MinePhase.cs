using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinePhase : MonoBehaviour
{
    [SerializeField] private float phaseDuration = 30;

    

    [SerializeField] private GameObject minePrefab;
    [SerializeField] private float spawnRate;
    private float justSpawned;
    [SerializeField] private Vector2 area = new Vector2(200, 110);


    private float startedPhase;

    private bool phaseEnded = false;

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
            GameObject mineClone = Instantiate(minePrefab);
            mineClone.transform.position = new Vector2(Random.Range(-area.x, area.x), Random.Range(-area.y, area.y));


        }
        else if (Time.time - startedPhase >= phaseDuration)
        {
            PhaseManager.Instance.PhaseEnded();
            phaseEnded = true;
        }
    }
}
