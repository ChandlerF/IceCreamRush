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

    private TextMeshProUGUI Text;
    void Start()
    {
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
            FindObjectOfType<AudioManager>().Play("Soundtrack1");
            HasMovedAtLeastOnce = true;
        }
    }

    public void ResetTimer()
    {
        Timer = StartTimer;
    }
}
