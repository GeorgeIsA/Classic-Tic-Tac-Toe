using System;
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
        //Debug.Log("Current starting player: " + GridPlacement.startingPlayer);
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
            player1ScoreText.text = (int.Parse(player1ScoreText.text) + 1).ToString();
            player2ScoreText.text = (int.Parse(player2ScoreText.text) + 1).ToString();
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
            Debug.Log("Switching players");
            GridPlacement.startingPlayer = GridPlacement.Player.p1;
            return 2;
        }
        return 0;
    }
}
