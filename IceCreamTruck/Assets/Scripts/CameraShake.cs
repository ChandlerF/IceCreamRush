﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    #region variables
    public bool CamShakeActive = true;
    [Range(0, 1)]
    [SerializeField] float trauma;
    [SerializeField] float traumaMultiplier = 5f;
    [SerializeField] float traumaMagnitude = 0.8f;
    [SerializeField] float traumaRotationMagnitude = 17f;

    float TimeCounter;
    #endregion

    #region Accessors
    public float Trauma
    {
        get
        {
            return trauma;
        }
        set
        {
            trauma = Mathf.Clamp01(value);
        }
    }
    #endregion

    #region Methods
    float GetFloat(float Seed)
    {
        return (Mathf.PerlinNoise(Seed, TimeCounter) - 0.5f) * 2;
    }

    Vector3 GetVector3()
    {
        return new Vector3(
            GetFloat(1),
            GetFloat(10),
            0
            );
    }
    private void Update()
    {
        if (CamShakeActive)
        {
            TimeCounter += Time.deltaTime * Mathf.Pow(trauma, 0.3f) * traumaMultiplier;
            Vector3 NewPos = GetVector3() * traumaMagnitude;
            transform.localPosition = NewPos;
        }
    }
    #endregion
}
