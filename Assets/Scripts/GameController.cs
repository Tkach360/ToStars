using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject PlayInterface;
    [SerializeField] private GameObject MenuButtons;
    [SerializeField] private GameObject PauseMenu;
    [SerializeField] private PointsController RecordTable;
    [SerializeField] private PointsController PointsTable;


    private void Start()
    {
        if (!PlayerPrefs.HasKey("EasyModeRecord"))
        {
            PlayerPrefs.SetInt("EasyModeRecord", 0);
        }
        if (!PlayerPrefs.HasKey("HardModeRecord"))
        {
            PlayerPrefs.SetInt("HardModeRecord", 0);
        }
    }
    public void Exit()
    {
        Debug.Log("exit");
        Application.Quit();
    }

    public void RunEasyMode()
    {
        Debug.Log("Run EasyMode");
        RunGame();
        RecordTable.SetPoints(PlayerPrefs.GetInt("EasyModeRecord"));
    }

    public void RunHardMode()
    {
        Debug.Log("Run HardMode");
        RunGame();
        RecordTable.SetPoints(PlayerPrefs.GetInt("HardModeRecord"));
    }

    private void RunGame()
    {
        PlayInterface.SetActive(true);
        MenuButtons.SetActive(false);
        PointsTable.SetPoints(0);
    }

    public void SetPause()
    {
        if (!PauseMenu.activeSelf)
        {
            Time.timeScale = 0.0f;
            PauseMenu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1.0f;
            PauseMenu.SetActive(false);
        }
    }

    public void FinishGameWithoutSaving()
    {
        PlayInterface.SetActive(false);
        SetPause();
        PauseMenu.SetActive(false);
        MenuButtons.SetActive(true);

    }
}
