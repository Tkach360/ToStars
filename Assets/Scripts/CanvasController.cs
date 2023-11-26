using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    private void OnEnable()
    { 
        SceneManager.sceneLoaded += SetStartStyle;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= SetStartStyle;
    }

    private void Start()
    {
        OptionsMenu.SetActive(false);
        LevelSelectionMenu.SetActive(false);

        menuButtons = MenuButtons.transform;
        optionsMenu = OptionsMenu.transform;
        levelSelectionMenu = LevelSelectionMenu.transform;
    }

    private void SetStartStyle(Scene scene, LoadSceneMode mode)
    {
        if (scene.isLoaded && menuButtons != null)
            SetStyle(StartStyle);
        else
            Debug.Log("unity разработан дебилами");
    }

    public void SetStyle(VisualStyle style)
    {
        // устанавливаем Background
        BackgroundController bg1 = Background1.GetComponent<BackgroundController>();
        BackgroundController bg2 = Background2.GetComponent<BackgroundController>();
        BackgroundController bg3 = Background3.GetComponent<BackgroundController>();

        bg1.SetBackground(style.background1, style.speedForBackground1);
        bg2.SetBackground(style.background2, style.speedForBackground2);
        bg3.SetBackground(style.background3, style.speedForBackground3);


        // устанавливаем все button
        ButtonController[] buttons = FindObjectsOfType<ButtonController>(true);

        for (int i= 0;i < buttons.Length;i++)
        {
            //Debug.Log(buttons[i].name);
            /*buttons[i].styleColor = style.styleColor;
            buttons[i].hoverColor = style.hoverColor;*/
            buttons[i].SetStyleColors(style.styleColor, style.hoverColor);
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
