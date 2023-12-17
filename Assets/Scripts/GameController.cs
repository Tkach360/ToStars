using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject PlayInterface;
    [SerializeField] private GameObject MenuButtons;
    [SerializeField] private GameObject PauseMenu;
    [SerializeField] private TableController RecordTable;

    public UnityEvent StartGame;


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
        Debug.Log("exit"); ////////////////


        Application.Quit();
    }

    public void RunEasyMode()
    {
        Debug.Log("Run EasyMode"); /////////////


        RunGame();
        RecordTable.SetTablePoints(PlayerPrefs.GetInt("EasyModeRecord"));
    }

    public void RunHardMode()
    {
        Debug.Log("Run HardMode"); /////////


        RunGame();
        RecordTable.SetTablePoints(PlayerPrefs.GetInt("HardModeRecord"));
    }

    private void RunGame()
    {
        // тут всё, что происходит при начале игры вне зависимости от режима

        PlayInterface.SetActive(true);
        MenuButtons.SetActive(false);

        StartGame?.Invoke();
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
