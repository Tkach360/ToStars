using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //[Range(0f, 1f)] // �������� �� 0 �� 1
    private float AlphaLevel = 1f; // ����������� �������� �����-������, ������� ������ ����� ����� ��������, �� ������� ������� ������, ����� ������������ �������
    private Image btImage; // �������� ����� ������ � Image � �� � Button

    [SerializeField] private GameObject buttonStroke;
    [SerializeField] private GameObject buttonText;
    //[SerializeField] public Color hoverColor;
    //[SerializeField] public Color styleColor;
    //private Color styleColor;

    private Color hoverColor;
    private Image btStImage;
    private TextMeshProUGUI btTxt;
    private Color normalColor;

    private void Start()
    {
        btImage = gameObject.GetComponent<Image>();
        btImage.alphaHitTestMinimumThreshold = AlphaLevel; // �������� alphaHitTestMinimumThreshold ��� ��� � �������� �� ��, ����� ����������� ������� ������������ ������ ���� � ����� ��������, ����� ��� ����� ���������� �������.

        btStImage = buttonStroke.GetComponent<Image>();
        btTxt = buttonText.GetComponent<TextMeshProUGUI>();

        //SetStyleColors(Color.white, Color.white);
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
        if(btStImage == null || btTxt == null)
        {
            btStImage = buttonStroke.GetComponent<Image>();
            btTxt = buttonText.GetComponent<TextMeshProUGUI>();
        }
        btStImage.color = styleColor;
        normalColor = styleColor;
        this.hoverColor = hoverColor;
        btTxt.color = hoverColor;
    }
}