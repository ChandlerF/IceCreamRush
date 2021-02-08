using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    public List<Transform> Locations;
    [SerializeField] private GameObject Target;

    [SerializeField] private float ExtraTime;

    [SerializeField] private DeathTimer TimerScript;

    private int OldLocation = 0;
    private int NewLocation = 0;

    [SerializeField] private ScoreManager ScoreManagerScript;

    private void Start()
    {
        MoveTarget();
    }

    public void MoveTarget()
    {
        NewLocation = Random.Range(0, Locations.Count);

        if (NewLocation == OldLocation)    
        {
            MoveTarget();
        }

        Target.transform.position = Locations[NewLocation].position;
        OldLocation = NewLocation;
    }

    public void Score()
    {
        MoveTarget();
        FindObjectOfType<AudioManager>().Play("Target");
        TimerScript.Timer += ExtraTime;
        ScoreManagerScript.Score += 1;
    }
}
