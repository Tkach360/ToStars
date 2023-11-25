using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Range(0f, 1f)] // ползунок от 0 до 1
    public float AlphaLevel = 1f; // минимальное значение альфа-канала, которое должна иметь часть текстуры, на которую наведен курсор, чтобы обрабатывать нажатия
    private Image btImage; // работать нужно именно с Image а не с Button

    [SerializeField] private GameObject buttonStroke;
    [SerializeField] public Color hoverColor;
    [SerializeField] public Color styleColor;

    private Image btStImage;
    private Color normalColor;

    private void Awake()
    {
        btImage = gameObject.GetComponent<Image>();
        btImage.alphaHitTestMinimumThreshold = AlphaLevel; // параметр alphaHitTestMinimumThreshold как раз и отвечает за то, какой минимальный уровень прозрачности должен быть у части текстуры, чтобы она могла обработать нажатие.

        btStImage = buttonStroke.GetComponent<Image>();
        btStImage.color = styleColor;
        normalColor = styleColor;

        Debug.Log(gameObject.name + " Awake");
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

    public void SetStyleColors(Color styleColor, Color hoverColor)
    {
        btStImage.color = styleColor;
        normalColor = styleColor;
        this.hoverColor = hoverColor;
    }
}