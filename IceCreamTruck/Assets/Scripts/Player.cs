using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private ParticleSystem Smoke;
    [SerializeField] private GameObject Explosion;
    [SerializeField] private DeathTimer TimerScript;

    [SerializeField] private GameObject TargetManagerObject;

    [SerializeField] private GameObject Trails;

    private SpriteRenderer sr;
    [SerializeField] private Sprite DestroyedVan;

    private PlayerMovement MovementScript;

    [SerializeField] private float SpinOut;

    private bool IsAlive = true;

    private Rigidbody2D rb;

    [SerializeField] private GameObject ScoreParticles;

    [SerializeField] private CameraShake CamShake;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        MovementScript = GetComponent<PlayerMovement>();
    }

    
    [System.Obsolete]
    void Update()
    {
        //Amount of smoke particles depends on vel
        Smoke.emissionRate = (Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.y) * 1.4f);  

        if(TimerScript.Timer < 0 && IsAlive)
        {
            PlayerDeath();
        }

        if(Input.GetAxis("Vertical") > 0)     //(Input.GetAxis("Horizontal") != 0 && 
        {
            Trails.SetActive(true);
        }
        else
        {
            Trails.SetActive(false);
        }
    }


    public void PlayerDeath()
    {
        sr.sprite = DestroyedVan;
        Instantiate(Explosion, transform.position, Quaternion.identity);
        MovementScript.enabled = false;
        rb.angularDrag = 0.8f;

        int x = Random.Range(0, 2);     //Makes spinout 'random' (So it's not the same every time)
        if (x == 0)
        {
            rb.AddTorque(SpinOut);
        }
        else
        {
            rb.AddTorque(-SpinOut);
        }

        rb.drag = 1;
        Trails.SetActive(false);
        IsAlive = false;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(ScoreParticles, transform.position, Quaternion.identity);
        TargetManagerObject.GetComponent<TargetManager>().Score();
        CamShake.Trauma += 0.6f;
    }
}
