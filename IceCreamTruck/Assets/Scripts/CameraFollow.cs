using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private Transform Target;

    [SerializeField] private Vector3 Offset;

    [SerializeField] private float Smoothness;

    [SerializeField] private float MinCameraSize;

    [SerializeField] private float MaxCameraSize;

    [SerializeField] private float Multiplier;

    [SerializeField] private GameObject Player;
    private Rigidbody2D PlayerRB;
    private PlayerMovement PlayerScript;

    private Camera Camera;

    private void Start()
    {
        PlayerRB = Player.GetComponent<Rigidbody2D>();
        PlayerScript = Player.GetComponent<PlayerMovement>();

        Camera = GetComponent<Camera>();
    }


    private void Update()
    {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.5)
        {
            if (Camera.orthographicSize > MinCameraSize)     //If cam is zoomed out
            {
                Camera.orthographicSize -= Multiplier * 1.2f;      //Zoom In
            }
        } else if ((Mathf.Abs(PlayerRB.velocity.x) + Mathf.Abs(PlayerRB.velocity.y)) < PlayerScript.MaxSpeed * 0.5)    //Car is slow <or> If vel isn't maxed 
        {
            if (Camera.orthographicSize > MinCameraSize)     //If cam is zoomed out
            {
                Camera.orthographicSize -= Multiplier;      //Zoom In
            }            
        }
        else if ((Mathf.Abs(PlayerRB.velocity.x) + Mathf.Abs(PlayerRB.velocity.y)) > PlayerScript.MaxSpeed * 0.8)
        {
            if (Camera.orthographicSize < MaxCameraSize)        //If Cam is zoomed in
            {
                Camera.orthographicSize += Multiplier * .6f;      //Zoom out
            }
        }
        //Camera.orthographicSize = ((Mathf.Abs(PlayerRB.velocity.x) + Mathf.Abs(PlayerRB.velocity.y)) *.9f) + MinCameraSize;
    }


    void FixedUpdate()
    {
        Vector3 DelayedPos = Vector3.Lerp(transform.position, Target.position, Smoothness);

        transform.position = DelayedPos + Offset;
    }
}
