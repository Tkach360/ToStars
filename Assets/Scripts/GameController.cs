using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject PlayInterface;
    [SerializeField] private GameObject MenuButtons;
    [SerializeField] private GameObject GameOverMenu;
    [SerializeField] private TableController RecordTable;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject Spawner;


    private GameMode _nowGameMode; // текущий режим игры

    public static UnityAction OnStartGame; // при старте игры


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
        Application.Quit();
    }

    public void RunEasyMode()
    {
        RunGame();
        _nowGameMode = new GameMode("EasyMode");
        RecordTable.SetTablePoints(PlayerPrefs.GetInt(_nowGameMode.recordName));
    }

    public void RunHardMode()
    {
        RunGame();
        _nowGameMode = new GameMode("HardMode");
        RecordTable.SetTablePoints(PlayerPrefs.GetInt(_nowGameMode.recordName));
    }

    private void RunGame()
    {
        // тут всё, что происходит при начале игры вне зависимости от режима

        PlayInterface.SetActive(true);
        MenuButtons.SetActive(false);
        Player.SetActive(true);
        Spawner.SetActive(true);
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

    public void SetPause(bool mode) // установка паузы
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

    public void ResetRecords()
    {
        PlayerPrefs.SetInt("EasyModeRecord", 0);
        PlayerPrefs.SetInt("HardModeRecord", 0);
    }
}
