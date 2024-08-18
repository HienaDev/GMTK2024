using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseManager : MonoBehaviour
{

    public static PhaseManager Instance {get; private set;}

    [HideInInspector] public bool phaseHappening = false;

    [SerializeField] private bool randomPhase = false;
    private int numberOfPhase = 0;
    [SerializeField] private GameObject[] phases1;
    [SerializeField] private GameObject[] phases2;
    private bool phase1 = true;

    [SerializeField] private float timeBetweenPhases = 3f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

        }

    }

    private void Start()
    {
        PhaseEnded();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerNewPhase()
    {
        if (!phaseHappening)
        {

            if(randomPhase)
            {
                Instantiate(phases1[Random.Range(0, phases1.Length)], transform);
            }
            else
            {
                if(phase1)
                {
                    Instantiate(phases1[numberOfPhase], transform);
                    numberOfPhase++;
                    if (numberOfPhase == phases1.Length)
                        numberOfPhase = 0;
                }
                else if (!phase1)
                {
                    Instantiate(phases2[numberOfPhase], transform);
                    numberOfPhase++;
                    if (numberOfPhase == phases2.Length)
                        numberOfPhase = 0;
                }

            }
            
            phaseHappening = true;
        }
    }

    public void Trigger2ndPhase()
    {
        phase1 = false;
        numberOfPhase = 0;

        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        PhaseEnded();
    }

    public void PhaseEnded()
    {
        phaseHappening = false;
        Debug.Log("trigger new phase");
        StartCoroutine(CooldownTimer());
    }

    IEnumerator CooldownTimer()
    {
        yield return new WaitForSeconds(timeBetweenPhases);

        TriggerNewPhase();
    }

}
