using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonsSetup : MonoBehaviour
{
    void Start()
    {
        Button[] buttons = GetComponentsInChildren<Button>();
        foreach (Button button in buttons)
            if (!button.gameObject.GetComponent<Image>().isActiveAndEnabled)
                button.gameObject.AddComponent<ButtonProperties>();
    }
    public void PlayClick()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void OptionsClick()
    {
        SceneManager.LoadScene("OptionsScene");
    }
    public void BackClick()
    {
        SceneManager.LoadScene("MenuScene");
    }
    public void ExitClick()
    {
        Application.Quit();
    }
}
