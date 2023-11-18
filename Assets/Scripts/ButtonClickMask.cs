using UnityEngine;
using UnityEngine.UI;

public class ButtonClickMask : MonoBehaviour
{
    [Range(0f, 1f)] // ползунок от 0 до 1
    public float AlphaLevel = 1f; // минимальное значение альфа-канала, которое должна иметь часть текстуры, на которую наведен курсор, чтобы обрабатывать нажатия
    private Image bt; // работать нужно именно с Image а не с Button

    void Start()
    {
        bt = gameObject.GetComponent<Image>();
        bt.alphaHitTestMinimumThreshold = AlphaLevel; // параметр alphaHitTestMinimumThreshold как раз и отвечает за то, какой минимальный уровень прозрачности должен быть у части текстуры, чтобы она могла обработать нажатие.
    }
}