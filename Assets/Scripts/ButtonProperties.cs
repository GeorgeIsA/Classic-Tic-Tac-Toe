using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonProperties : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Text associatedText;
    private Image associatedImage;

    private void Start()
    {
        associatedText = gameObject.GetComponentInChildren<Text>();
        associatedImage = gameObject.GetComponent<Image>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        associatedImage.enabled = true;
        associatedText.color = Color.white;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        associatedImage.enabled = false;
        associatedText.color = Color.black;
    }
}


