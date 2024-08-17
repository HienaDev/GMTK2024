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
 

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        TriggerNewPhase();
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
        TriggerNewPhase();
    }

}