using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Slider Slider;
    [SerializeField] DeathTimer DTimer;
    [SerializeField] Gradient Gradient;
    [SerializeField] Image Fill;

    void Start()
    {
        DTimer.Timer = DTimer.StartTimer;
        SetMaxHealth(DTimer.StartTimer);
    }


    void Update()
    {
        SetHealth(DTimer.Timer);
    }

    public void SetMaxHealth(float Health)
    {
        Slider.maxValue = Health;
        Slider.value = Health;

        Fill.color = Gradient.Evaluate(1f);
    }

    public void SetHealth(float Health)
    {
        Slider.value = Health;

        Fill.color = Gradient.Evaluate(Slider.normalizedValue);
    }
}
