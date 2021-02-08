
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{

    private GameObject Target;


    private void Update()
    {

        if (Target == null) //Looks for Target if it's null
        {
            Target = GameObject.FindGameObjectWithTag("Target");
        }


        Vector3 vectorToTarget = Target.transform.position - transform.position;  //Rotates-Moves Indicator
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}