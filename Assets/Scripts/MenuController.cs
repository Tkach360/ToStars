using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Canvas Canvas;
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private GameObject runLevelPrefab;
    [SerializeField] private GameObject underMenuPrefab;
    public void Exit()
    {
        Debug.Log("exit");
        Application.Quit();
    }

    public void RunLevel()
    {
        Debug.Log("Run Level");
    }

    private void SetStyle(IStyleStrategy style)
    {
        SetBackground("Background1", style.getMaterialForBackground1(), style.getSpeedForBackground1());
        SetBackground("Background2", style.getMaterialForBackground2(), style.getSpeedForBackground2());
        SetBackground("Background3", style.getMaterialForBackground3(), style.getSpeedForBackground3());

        Canvas.transform.Find("MenuButtons").Find("View").GetComponent<Image>().sprite = style.getButtonsView();

        Transform icon = Canvas.transform.Find("MenuButtons").Find("Icon");
        icon.Find("IconView").GetComponent<Image>().color = style.getStyleColor();
        icon.Find("IconWords").GetComponent<Image>().color = style.getHoverColor();

        Transform buttonTransform = buttonPrefab.transform;
        buttonTransform.Find("buttonStroke").GetComponent<Image>().color = style.getStyleColor();
        buttonTransform.Find("Text").GetComponent<TextMeshPro>().color = style.getHoverColor();

        runLevelPrefab.transform.Find("buttonStroke").GetComponent<Image>().color = style.getStyleColor();

        underMenuPrefab.transform.Find("Stroke").GetComponent<Image>().color = style.getStyleColor();

    }

    private void SetBackground(string BackgroundName, Material material, float speed)
    {
        Transform bg = Canvas.transform.Find(BackgroundName);
        bg.gameObject.GetComponent<Image>().material = material;
        bg.GetComponent<BackgroundScript>().speed = speed;
    }
}
