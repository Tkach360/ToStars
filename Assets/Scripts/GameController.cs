using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject PlayInterface;
    [SerializeField] private GameObject MenuButtons;
    [SerializeField] private GameObject GameOverMenu;
    [SerializeField] private TableController RecordTable;

    private GameMode _nowGameMode;

    public UnityEvent OnStartGame;


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

    private void OnEnable()
    {
        PlayerController.OnHealthOver += GameOver;
    }

    private void OnDisable()
    {
        PlayerController.OnHealthOver -= GameOver;
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
        _nowGameMode = new GameMode("EasyMode");
    }

    public void RunHardMode()
    {
        Debug.Log("Run HardMode"); /////////


        RunGame();
        RecordTable.SetTablePoints(PlayerPrefs.GetInt("HardModeRecord"));
        _nowGameMode = new GameMode("EasyMode");
    }

    private void RunGame()
    {
        // тут всё, что происходит при начале игры вне зависимости от режима

        PlayInterface.SetActive(true);
        MenuButtons.SetActive(false);

        OnStartGame?.Invoke();
    }

    public void GameOver(int points)
    {
        string recordName = _nowGameMode.name + "Record";
        if (points > PlayerPrefs.GetInt(recordName))
            PlayerPrefs.SetInt(recordName, points);

        //тут может быть анимация и прочая логика GameOver

        SetPause(true);
        GameOverMenu.SetActive(true);
    }

    public void SetPause(bool mode)
    {
        if (mode)
        {
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }
}
