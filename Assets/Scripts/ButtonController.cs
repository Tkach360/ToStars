using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Range(0f, 1f)] // ползунок от 0 до 1
    public float AlphaLevel = 1f; // минимальное значение альфа-канала, которое должна иметь часть текстуры, на которую наведен курсор, чтобы обрабатывать нажатия
    private Image bt; // работать нужно именно с Image а не с Button

    [SerializeField] private GameObject buttonStroke;
    private Image btStImage;
    private Color hoverColor;
    private Color normalColor;

    private void Start()
    {
        bt = gameObject.GetComponent<Image>();
        bt.alphaHitTestMinimumThreshold = AlphaLevel; // параметр alphaHitTestMinimumThreshold как раз и отвечает за то, какой минимальный уровень прозрачности должен быть у части текстуры, чтобы она могла обработать нажатие.

        btStImage = buttonStroke.GetComponentInChildren<Image>();
        normalColor = btStImage.color;
        hoverColor = new Color(normalColor.r, normalColor.g + 0.7f, normalColor.b);
    }



    public void OnPointerEnter(PointerEventData eventData)
    {
        btStImage.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        btStImage.color = normalColor;
    }

    public void SetNormalColor()
    {
        btStImage.color = normalColor;
    }
}