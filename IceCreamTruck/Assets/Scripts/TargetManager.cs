using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    public List<Transform> Locations;
    [SerializeField] private GameObject Target;

    [SerializeField] private float ExtraTime;

    [SerializeField] private DeathTimer TimerScript;

    [SerializeField] private int OldLocation = 0;
    [SerializeField] private int NewLocation = 0;

    private void Update()
    {
        if (Input.GetKey(KeyCode.T))
        {
            MoveTarget();
        }
    }
    private void MoveTarget()
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
        TimerScript.Timer += ExtraTime;
    }
}
