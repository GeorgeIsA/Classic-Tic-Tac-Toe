using TMPro;
using UnityEngine;

public class ScoringSystem : MonoBehaviour
{
    public static bool scored = false;
    public static bool bothScored = false;
    private TextMeshProUGUI player1ScoreText;
    private TextMeshProUGUI player2ScoreText;
    private void Start()
    {
        player1ScoreText = GameObject.Find("PlayerXScoreText").GetComponent<TextMeshProUGUI>();
        player1ScoreText.text = 0.ToString();
        player2ScoreText = GameObject.Find("PlayerOScoreText").GetComponent<TextMeshProUGUI>();
        player2ScoreText.text = 0.ToString();
    }
    private void Update()
    {
        if (scored)
        {
            if (GridPlacement.lastPlayer == 1)
            {
                player1ScoreText.text = (int.Parse(player1ScoreText.text) + 1).ToString();
            }
            else if(GridPlacement.lastPlayer == 2)
            {
                player2ScoreText.text = (int.Parse(player2ScoreText.text) + 1).ToString();
            }
            scored = false;
            StartCoroutine(GridPlacement.ResetGrid());
        }
        if(bothScored)
        {
            player1ScoreText.text = (int.Parse(player1ScoreText.text) + 1).ToString();
            player2ScoreText.text = (int.Parse(player2ScoreText.text) + 1).ToString();
            bothScored = false;
            StartCoroutine(GridPlacement.ResetGrid());
        }
    }
}
