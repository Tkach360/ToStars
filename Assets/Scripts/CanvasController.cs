using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasConntroller : MonoBehaviour
{
    [SerializeField] private VisualStyle StartStyle;

    [SerializeField] private GameObject Background1;
    [SerializeField] private GameObject Background2;
    [SerializeField] private GameObject Background3;

    [SerializeField] private GameObject MenuButtons;
    private Transform menuButtons;
    [SerializeField] private GameObject OptionsMenu;
    private Transform optionsMenu;
    [SerializeField] private GameObject LevelSelectionMenu;
    private Transform levelSelectionMenu;

    public event Action<VisualStyle> OnFinishedStart;

    private void OnEnable()
    {
        OnFinishedStart += SetStyle;
    }

    private void OnDisable()
    {
        OnFinishedStart -= SetStyle;
    }

    private void Start()
    {
        OptionsMenu.SetActive(false);
        LevelSelectionMenu.SetActive(false);

        menuButtons = MenuButtons.transform;
        optionsMenu = OptionsMenu.transform;
        levelSelectionMenu = LevelSelectionMenu.transform;

        OnFinishedStart.Invoke(StartStyle);
    }

    public void SetStyle(VisualStyle style)
    {
        // устанавливаем Background
        Background1.GetComponent<Image>().material = style.background1;
        Background2.GetComponent<Image>().material = style.background2;
        Background3.GetComponent<Image>().material = style.background3;

        // устанавливаем все button
        ButtonController[] buttons = FindObjectsOfType<ButtonController>(true);

        Debug.Log(buttons.Length);

        for (int i= 0;i < buttons.Length;i++)
        {
            Debug.Log(buttons[i].name);
            buttons[i].styleColor = style.styleColor;
            buttons[i].hoverColor = style.hoverColor;
        }

        // устанавливаем View для MenuButtons
        menuButtons.Find("View").gameObject.GetComponent<Image>().sprite = style.buttonsView;

        // устанавливаем Icon
        Transform icon = menuButtons.Find("Icon").transform;
        icon.Find("IconView").gameObject.GetComponent<Image>().color = style.styleColor;
        icon.Find("IconWords").gameObject.GetComponent<Image>().color = style.hoverColor;

        // устанавливаем Stroke для OptionsMenu
        optionsMenu.Find("Stroke").gameObject.GetComponent<Image>().color = style.styleColor;

        // устанавливаем Stroke для LevelSelectionMenu
        levelSelectionMenu.Find("Stroke").gameObject.GetComponent<Image>().color = style.styleColor;

        Debug.Log("selected style");
    }

}
