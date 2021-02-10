using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public ParticleSystem Smoke;
    [SerializeField] private GameObject Explosion;
    [SerializeField] private DeathTimer TimerScript;

    [SerializeField] private GameObject TargetManagerObject;

    [SerializeField] private GameObject Trails;

    public SpriteRenderer sr;
    [SerializeField] private GameObject DestroyedVan;

    private PlayerMovement MovementScript;

    [SerializeField] private float SpinOut;

    public bool IsAlive = true;

    public Rigidbody2D rb;

    [SerializeField] private GameObject ScoreParticles;

    [SerializeField] private CameraShake CamShake;

    [SerializeField] GameObject Menu;

    public GameObject SpawnedDestroyedVan;

    public CameraFollow Camera;

    [SerializeField] GameObject Indicator;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        MovementScript = GetComponent<PlayerMovement>();
    }

    
    [System.Obsolete]
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && IsAlive && TimerScript.HasMoved)
        {
            PlayerDeath();
        }

        //if (Input.GetKeyDown(KeyCode.G))
        //{
            rb.angularVelocity = 0f;
        //}


        if (IsAlive)
        {
            //Amount of smoke particles depends on vel
            Smoke.emissionRate = (Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.y) * 1.4f);
        }
        else
        {
            Smoke.gameObject.SetActive(false);
        }

        if(TimerScript.Timer < 0 && IsAlive)
        {
            PlayerDeath();
        }

        if(Input.GetAxis("Vertical") > 0 && IsAlive)     //(Input.GetAxis("Horizontal") != 0 && 
        {
            Trails.SetActive(true);
        }
        else
        {
            Trails.SetActive(false);
        }

        if (!IsAlive && SpawnedDestroyedVan.GetComponent<Rigidbody2D>().velocity == Vector2.zero)
        {
            Menu.GetComponent<MenuManager>().Restart();
        }
    }


    public void PlayerDeath()
    {
        if (IsAlive)
        {
            FindObjectOfType<AudioManager>().Play("Explosion");
            Indicator.SetActive(false);
            sr.enabled = false;
            SpawnedDestroyedVan = Instantiate(DestroyedVan, transform.position, transform.rotation) as GameObject;
            Rigidbody2D DestroyedRB = SpawnedDestroyedVan.GetComponent<Rigidbody2D>();
            DestroyedRB.velocity = rb.velocity;
            Camera.Target = SpawnedDestroyedVan.transform;
            Instantiate(Explosion, transform.position, Quaternion.identity);
            MovementScript.enabled = false;


            rb.drag = 3f;
            rb.angularDrag = 3f;

            int x = Random.Range(0, 2);     //Makes spinout 'random' (So it's not the same every time)
            if (x == 0)
            {
                DestroyedRB.AddTorque(SpinOut);
                rb.AddTorque(SpinOut);
            }
            else
            {
                DestroyedRB.AddTorque(-SpinOut);
                rb.AddTorque(-SpinOut);
            }
            TimerScript.HasMoved = false;
            IsAlive = false;
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsAlive)
        {
            Instantiate(ScoreParticles, transform.position, Quaternion.identity);
            TargetManagerObject.GetComponent<TargetManager>().Score();
            CamShake.Trauma += 0.75f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsAlive)
        {
            FindObjectOfType<AudioManager>().Play("HitWall");
            CamShake.Trauma += 0.5f;
        }
    }
}
