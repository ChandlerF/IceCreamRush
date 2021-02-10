using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int Score;

    private TextMeshProUGUI TMP;

    private void Start()
    {
        TMP = GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        TMP.text = Score.ToString();
    }
}
