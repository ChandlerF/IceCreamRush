using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggles : MonoBehaviour
{
    [SerializeField] CameraShake CamShake;
    [SerializeField] AudioSource Soundtrack1;
    [SerializeField] CameraFollow CamFollow;



    public void CameraShake(bool boolean)
    {
        CamShake.CamShakeActive = boolean;
    }

    public void Music(bool boolean)
    {
        if (boolean)
        {
            Soundtrack1.Play();
        }
        else
        {
            Soundtrack1.Stop();
        }
    }


    public void CamZoom(bool boolean)
    {
        CamFollow.CameraZoom = boolean;
    }
}
