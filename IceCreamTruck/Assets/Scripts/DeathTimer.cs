using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeathTimer : MonoBehaviour
{
    public float StartTimer;
    public float Timer;

    public bool HasMoved = false;
    private bool HasMovedAtLeastOnce = false;

    [SerializeField] AudioSource Soundtrack1;
    private float StartVolume;
    private bool TimeIsFrozen = false;

    private TextMeshProUGUI Text;
    void Start()
    {
        StartVolume = Soundtrack1.volume;
        Text = GetComponent<TextMeshProUGUI>();
        ResetTimer();   
    }

    
    void Update()
    {
        if (HasMoved == false && Input.GetAxis("Vertical") != 0)
        {
            HasMoved = true;
        }

        if(HasMoved == true && Timer > 0)
        {
            Timer -= Time.deltaTime;
        }
        Text.text = Timer.ToString("F0");

        if (!HasMovedAtLeastOnce && HasMoved)
        {
            Soundtrack1.Play();
            HasMovedAtLeastOnce = true;
        }

        if (Time.timeScale == 0f && !TimeIsFrozen)
        {
            Soundtrack1.volume *= 0.35f;
            TimeIsFrozen = true;
        }
        else if (Time.timeScale == 1f)
        {
            Soundtrack1.volume = StartVolume;
            TimeIsFrozen = false;
        }
    }

    public void ResetTimer()
    {
        Timer = StartTimer;
    }
}
