﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Slider Slider;

    public void SetMaxHealth(int Health)
    {
        Slider.maxValue = Health;
        Slider.value = Health;
    }

    public void SetHealth(int Health)
    {
        Slider.value = Health;
    }
}