using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerNames : MonoBehaviour
{
    private string nullString;
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
                if (string.IsNullOrEmpty(PlayerPrefs.GetString("Player1Name")))
                    gameObject.GetComponent<TextMeshProUGUI>().text = "Player 1";
                else gameObject.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetString("Player1Name", "Player 1");
            }
            else if (gameObject.CompareTag("Player2Text"))
            {
                if (string.IsNullOrEmpty(PlayerPrefs.GetString("Player2Name")))
                    gameObject.GetComponent<TextMeshProUGUI>().text = "Player 2";
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
    public void ResetClick()
    {
        PlayerPrefs.SetString("Player1Input", null);
        PlayerPrefs.SetString("Player2Input", null);
        GameObject.FindGameObjectWithTag("Player1Input").GetComponent<TMP_InputField>().text = null;
        GameObject.FindGameObjectWithTag("Player2Input").GetComponent<TMP_InputField>().text = null;
    }
}
