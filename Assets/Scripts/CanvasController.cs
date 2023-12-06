using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CanvasConntroller : MonoBehaviour
{
    [SerializeField] private VisualStyle st;

    [SerializeField] private VisualStyle[] ArrayStyles;

    [SerializeField] private GameObject Background1;
    [SerializeField] private GameObject Background2;
    [SerializeField] private GameObject Background3;

    [SerializeField] private GameObject MenuButtons;
    private Transform menuButtons;
    [SerializeField] private GameObject OptionsMenu;
    private Transform optionsMenu;
    [SerializeField] private GameObject LevelSelectionMenu;
    private Transform levelSelectionMenu;

    private void Awake()
    {
        StartCoroutine(WaitForAllObjects());
    }

    IEnumerator WaitForAllObjects()
    {
        yield return new WaitUntil(() => AllObjectsLoaded());
        SetStyle(ArrayStyles[PlayerPrefs.GetInt("VisualStyleNumber")]);
    }

    private bool AllObjectsLoaded()
    {

        GameObject[] sceneObjects = FindObjectsOfType<GameObject>();
        foreach (GameObject obj in sceneObjects)
        {
            if (!obj.activeSelf)
            {
                return false;
            }
        }
        return true;
    }

    private void Start()
    {
        OptionsMenu.SetActive(false);
        LevelSelectionMenu.SetActive(false);

        menuButtons = MenuButtons.transform;
        optionsMenu = OptionsMenu.transform;
        levelSelectionMenu = LevelSelectionMenu.transform;
    }

    public void SetStyle(VisualStyle style)
    {
        st = style;

        for(int i = 0; i < ArrayStyles.Length; i++)
        {
            if (ArrayStyles[i] == style)
            {
                PlayerPrefs.SetInt("VisualStyleNumber", i);
                break;
            }
        }

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
            Debug.Log(i);
            buttons[i].SetStyleColors(style.styleColor, style.hoverColor);
        }

        //устанавливаем View для MenuButtons
        menuButtons.Find("View").gameObject.GetComponent<Image>().sprite = style.buttonsView;

        // устанавливаем Icon
        Transform icon = menuButtons.Find("Icon").transform;
        icon.Find("IconView").gameObject.GetComponent<Image>().color = style.styleColor;
        icon.Find("IconWords").gameObject.GetComponent<Image>().color = style.hoverColor;

        // устанавливаем Stroke для OptionsMenu
        optionsMenu.Find("Stroke").gameObject.GetComponent<Image>().color = style.styleColor;

        // устанавливаем Stroke для LevelSelectionMenu
        levelSelectionMenu.Find("Stroke").gameObject.GetComponent<Image>().color = style.styleColor;

        //Debug.Log("selected style");
    }

}
