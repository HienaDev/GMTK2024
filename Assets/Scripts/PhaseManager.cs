using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseManager : MonoBehaviour
{

    public static PhaseManager Instance {get; private set;}

    [HideInInspector] public bool phaseHappening = false;

    [SerializeField] private bool randomPhase = false;
    private int numberOfPhase = 0;
    [SerializeField] private GameObject[] phases;

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
                Instantiate(phases[Random.Range(0, phases.Length)]);
            }
            else
            {
                Instantiate(phases[numberOfPhase]);
                numberOfPhase++;
                if(numberOfPhase == phases.Length)
                    numberOfPhase = 0;
            }
            
            phaseHappening = true;
        }
    }

    public void PhaseEnded()
    {
        phaseHappening = false;
        
        StartCoroutine(CooldownTimer());
    }

    IEnumerator CooldownTimer()
    {
        yield return new WaitForSeconds(timeBetweenPhases);

        TriggerNewPhase();
    }

}
