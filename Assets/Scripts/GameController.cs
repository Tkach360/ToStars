using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject PlayInterface;
    [SerializeField] private GameObject MenuButtons;
    [SerializeField] private GameObject PauseMenu;
    [SerializeField] private PointsController RecordTable;

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
