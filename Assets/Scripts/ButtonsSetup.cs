using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonsSetup : MonoBehaviour
{
    void Start()
    {
        Button[] buttons = GetComponentsInChildren<Button>();
        foreach (Button button in buttons)
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
    public void ExitClick()
    {
        Application.Quit();
    }
}
