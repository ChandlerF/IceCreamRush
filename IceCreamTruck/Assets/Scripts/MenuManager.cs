using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    [SerializeField] GameObject Player;
    [SerializeField] Transform SpawnPoint;
    private Player PlayerScript;
    [SerializeField] private DeathTimer TimerScript;
    [SerializeField] GameObject Indicator;
    [SerializeField] ScoreManager Score;
    [SerializeField] TargetManager Target;


    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            MainMenu();
        }
    }


    public void Restart()
    {
        TimerScript.HasMoved = false;
        Target.MoveTarget();
        Score.Score = 0;
        TimerScript.Timer = TimerScript.StartTimer;
        Indicator.SetActive(true);
        PlayerScript = Player.GetComponent<Player>();
        Player.transform.position = SpawnPoint.position;
        Player.GetComponent<PlayerMovement>().enabled = true;
        PlayerScript.IsAlive = true;
        PlayerScript.Smoke.gameObject.SetActive(true);
        PlayerScript.rb.drag = 0f;
        PlayerScript.rb.angularDrag = 0.05f;
        PlayerScript.sr.enabled = true;
        PlayerScript.transform.rotation = Quaternion.identity;
        PlayerScript.rb.velocity = Vector3.zero;
        //SceneManager.LoadScene("Level1");
    }

    private void MainMenu()
    {
        Application.Quit();
        //SceneManager.LoadScene("Menu");
    }
}
