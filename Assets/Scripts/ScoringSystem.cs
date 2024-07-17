using System;
using TMPro;
using UnityEngine;

public class ScoringSystem : MonoBehaviour
{
    public static bool scored = false;
    public static bool bothScored = false;
    private TextMeshProUGUI player1ScoreText;
    private TextMeshProUGUI player2ScoreText;
    private TextMeshProUGUI drawsText;
    public static bool resetPushed;
    private void Start()
    {
        resetPushed = false;
        player1ScoreText = GameObject.Find("Player1ScoreText").GetComponent<TextMeshProUGUI>();
        player1ScoreText.text = 0.ToString();
        player2ScoreText = GameObject.Find("Player2ScoreText").GetComponent<TextMeshProUGUI>();
        player2ScoreText.text = 0.ToString();
        drawsText = GameObject.Find("DrawsNumber").GetComponent<TextMeshProUGUI>();
        drawsText.text = 0.ToString();
    }
    private void Update()
    {
        if (scored)
        {
            if (SwitchPlayers() == 1)
            {
                if (GridPlacement.winningPlayer == GridPlacement.Player.p1)
                    player1ScoreText.text = (int.Parse(player1ScoreText.text) + 1).ToString();
                else if (GridPlacement.winningPlayer == GridPlacement.Player.p2)
                    player2ScoreText.text = (int.Parse(player2ScoreText.text) + 1).ToString();
            }
            else
            {
                if (GridPlacement.winningPlayer == GridPlacement.Player.p1)
                    player2ScoreText.text = (int.Parse(player2ScoreText.text) + 1).ToString();
                else if (GridPlacement.winningPlayer == GridPlacement.Player.p2)
                    player1ScoreText.text = (int.Parse(player1ScoreText.text) + 1).ToString();
            }
            scored = false;
            StartCoroutine(GridPlacement.ResetGrid());
        }
        else if (bothScored)
        {
            SwitchPlayers();
            drawsText.text = (int.Parse(drawsText.text) + 1).ToString();
            bothScored = false;
            StartCoroutine(GridPlacement.ResetGrid());
        }
    }

    private int SwitchPlayers()
    {
        if (GridPlacement.startingPlayer == GridPlacement.Player.p1)
        {
            GridPlacement.startingPlayer = GridPlacement.Player.p2;
            return 1;
        }
        if (GridPlacement.startingPlayer == GridPlacement.Player.p2)
        {
            GridPlacement.startingPlayer = GridPlacement.Player.p1;
            return 2;
        }
        return 0;
    }
    public void ResetScore()
    {
        resetPushed = true;
        StartCoroutine(GridPlacement.ResetGrid());
        GridPlacement.SecondRestart();
        player1ScoreText.text = 0.ToString();
        player2ScoreText.text = 0.ToString();
        drawsText.text = 0.ToString();
        resetPushed = false;
    }
}
