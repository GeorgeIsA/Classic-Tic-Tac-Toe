using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerNames : MonoBehaviour
{
    public void NameSet()
    {
        if (gameObject.CompareTag("Player1Input"))
            PlayerPrefs.SetString("Player1Name", gameObject.GetComponent<TMP_InputField>().text);
        else if (gameObject.CompareTag("Player2Input"))
            PlayerPrefs.SetString("Player2Name", gameObject.GetComponent<TMP_InputField>().text);
    }
    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "GameScene")
        {

            if (gameObject.CompareTag("Player1Text"))
            {
                if (string.IsNullOrWhiteSpace(gameObject.GetComponent<TextMeshProUGUI>().text))
                    gameObject.GetComponent<TextMeshProUGUI>().text = "Player 1";
                else gameObject.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetString("Player1Name", "Player 1");
            }
            else if (gameObject.CompareTag("Player2Text"))
            {
                if (string.IsNullOrWhiteSpace(gameObject.GetComponent<TextMeshProUGUI>().text))
                {
                    Debug.Log("Player 2");

                    gameObject.GetComponent<TextMeshProUGUI>().text = "Player 2";
                }
                else gameObject.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetString("Player2Name", "Player 2");
            }
        }
        else if (SceneManager.GetActiveScene().name == "OptionsScene")
        {
            if (gameObject.CompareTag("Player1Input"))
                gameObject.GetComponent<TMP_InputField>().text = PlayerPrefs.GetString("Player1Name", "Player 1");
            else if (gameObject.CompareTag("Player2Input"))
                gameObject.GetComponent<TMP_InputField>().text = PlayerPrefs.GetString("Player2Name", "Player 1");
        }

    }
}
