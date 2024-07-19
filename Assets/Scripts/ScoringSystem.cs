using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour
{
    public static bool scored = false;
    public static bool bothScored = false;
    private TextMeshProUGUI player1ScoreText;
    private TextMeshProUGUI player2ScoreText;
    private TextMeshProUGUI drawsText;
    public static bool resetPushed;
    private static bool player1Turn;

    private Image X1;
    private Image X2;
    private Image O1;
    private Image O2;
    private void Start()
    {
        X1 = GameObject.Find("X1").GetComponent<Image>();
        X2 = GameObject.Find("X2").GetComponent<Image>();
        O1 = GameObject.Find("O1").GetComponent<Image>();
        O2 = GameObject.Find("O2").GetComponent<Image>();
        player1Turn = true;
        SetTurn();
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
            SetTurn();
        }
        else if (bothScored)
        {
            SwitchPlayers();
            drawsText.text = (int.Parse(drawsText.text) + 1).ToString();
            bothScored = false;
            StartCoroutine(GridPlacement.ResetGrid());
            SetTurn();
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
        player1Turn = true;
        SetTurn();
        resetPushed = true;
        StartCoroutine(GridPlacement.ResetGrid());
        GridPlacement.SecondRestart();
        player1ScoreText.text = 0.ToString();
        player2ScoreText.text = 0.ToString();
        drawsText.text = 0.ToString();
        resetPushed = false;
    }
    private void SetTurn()
    {
        if (player1Turn)
        {
            X1.enabled = true;
            X2.enabled = false;
            O1.enabled = false;
            O2.enabled = true;
            player1Turn = false;
        }
        else
        {
            X1.enabled = false;
            X2.enabled = true;
            O1.enabled = true;
            O2.enabled = false;
            player1Turn = true;
        }
    }
}
