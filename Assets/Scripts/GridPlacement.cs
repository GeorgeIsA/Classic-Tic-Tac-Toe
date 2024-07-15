using System.Collections;
using UnityEngine;
public class GridPlacement : MonoBehaviour
{
    private static bool player1 = true;
    private static bool player2 = false;
    private static bool scoring = false;
    public static int lastPlayer;
    private bool finished;
    private static int[,] grid = new int[4, 4];
    private GameObject tile;
    private void Start()
    {
        GridInit();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !scoring)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.CompareTag("Tile"))
                {
                    tile = hit.collider.gameObject;
                    string gameObjectName = tile.name;
                    int tileValue = int.Parse(gameObjectName);
                    int i = tileValue / 10;
                    int j = tileValue % 10;
                    if (player1 && grid[i, j] == 0)
                    {
                        GridSet(tileValue);
                        Instantiate(Resources.Load("Prefabs/X"), tile.gameObject.transform.position, Quaternion.identity);
                        player1 = !player1;
                        player2 = !player2;
                    }
                    else if (player2 && grid[i, j] == 0)
                    {
                        GridSet(tileValue);
                        Instantiate(Resources.Load("Prefabs/O"), tile.gameObject.transform.position, Quaternion.identity);
                        player1 = !player1;
                        player2 = !player2;
                    }
                    if (!player1)
                        lastPlayer = 1;
                    else
                        lastPlayer = 2;
                    if (CheckWin(lastPlayer) == lastPlayer)
                    {
                        ScoringSystem.scored = true;
                        Debug.Log("Player " + lastPlayer + " wins");
                    }
                    if (IsFinished())
                    {
                        ScoringSystem.bothScored = true;
                        Debug.Log("Draw");
                    }
                }
            }
            else Debug.Log("No tile found");
        }
    }
    private static void GridInit()
    {
        for (int i = 1; i < 4; i++)
            for (int j = 1; j < 4; j++)
                grid[i, j] = 0;
    }
    private void GridSet(int tileValue)
    {
        int i = tileValue / 10;
        int j = tileValue % 10;
        if (player1)
            grid[i, j] = 1;
        else
            grid[i, j] = 2;
    }
    private int CheckWin(int player)
    {
        for (int i = 1; i <= 3; i++)
            for (int j = 1; j <= 3; j++)
                if (HorizontalLine(i, j, player) || VerticalLine(i, j, player) || MainDiagonalLine(i, j, player) || SecondaryDiagonalLine(i, j, player))
                    return player;
        return 0;

    }
    private bool IsFinished()
    {
        finished = true;
        for (int i = 1; i <= 3; i++)
            for (int j = 1; j <= 3; j++)
                if (grid[i, j] == 0)
                    finished = false;
        return finished;
    }
    private bool HorizontalLine(int i, int j, int player)
    {
        if (j == 1)
            return grid[i, j] == grid[i, j + 1] && grid[i, j + 1] == grid[i, j + 2] && grid[i, j] == player;
        else return false;
    }
    private bool VerticalLine(int i, int j, int player)
    {
        if (i == 1)
            return grid[i, j] == grid[i + 1, j] && grid[i + 2, j] == grid[i, j] && grid[i, j] == player;
        else return false;
    }
    private bool MainDiagonalLine(int i, int j, int player)
    {
        if (i == 1 && j == 1)
            return grid[i, j] == grid[i + 1, j + 1] && grid[i + 1, j + 1] == grid[i + 2, j + 2] && grid[i, j] == player;
        else return false;
    }
    private bool SecondaryDiagonalLine(int i, int j, int player)
    {
        if (i == 1 && j == 3)
            return grid[i, j] == grid[i + 1, j - 1] && grid[i + 1, j - 1] == grid[i + 2, j - 2] && grid[i, j] == player;
        else return false;
    }
    public static IEnumerator ResetGrid()
    {
        scoring = true; 
        yield return new WaitForSeconds(2f);
        GridInit();
        player1 = true;
        player2 = false;
        foreach (GameObject X in GameObject.FindGameObjectsWithTag("X"))
            Destroy(X);
        foreach (GameObject O in GameObject.FindGameObjectsWithTag("O"))
            Destroy(O);
        scoring = false;
    }
}
