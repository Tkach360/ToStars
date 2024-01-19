using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject _playInterface;
    [SerializeField] private GameObject _menuButtons;
    [SerializeField] private GameObject _gameOverMenu;
    [SerializeField] private TableController _recordTable;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _spawner;


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
        Player.OnHealthOver += GameOver;
    }

    private void OnDisable()
    {
        Player.OnHealthOver -= GameOver;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void RunEasyMode()
    {
        RunGame();
        _nowGameMode = new GameMode("EasyMode");
        _recordTable.SetTablePoints(PlayerPrefs.GetInt(_nowGameMode.recordName));
    }

    public void RunHardMode()
    {
        RunGame();
        _nowGameMode = new GameMode("HardMode");
        _recordTable.SetTablePoints(PlayerPrefs.GetInt(_nowGameMode.recordName));
    }

    private void RunGame()
    {
        // тут всё, что происходит при начале игры вне зависимости от режима

        _playInterface.SetActive(true);
        _menuButtons.SetActive(false);
        _player.SetActive(true);
        _spawner.SetActive(true);
        OnStartGame?.Invoke();
    }

    public void GameOver(int points)
    {
        string recordName = _nowGameMode.name + "Record";
        if (points > PlayerPrefs.GetInt(recordName))
            PlayerPrefs.SetInt(recordName, points);

        //тут может быть анимация и прочая логика GameOver

        SetPause(true);
        _gameOverMenu.SetActive(true);
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

    public void ClearScene()
    {
        DelGameObjectOfTag("Enemy");
        DelGameObjectOfTag("Bullet");
        DelGameObjectOfTag("Bonus");
        DelGameObjectOfTag("Isometric");
        DelGameObjectOfTag("Vertical");

        _spawner.SetActive(false);
        _player.SetActive(false);
    }

    private void DelGameObjectOfTag(string tag)
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject obj in objects) Destroy(obj);
    }

    public void ResetRecords()
    {
        PlayerPrefs.SetInt("EasyModeRecord", 0);
        PlayerPrefs.SetInt("HardModeRecord", 0);
    }
}
