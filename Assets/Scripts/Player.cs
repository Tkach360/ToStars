using System.Collections;
using UnityEngine;
using UnityEngine.Events;


public class Player : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private float _timePointsDelay = 1f;
    [SerializeField] private int _pointsAtTime = 1;
    private int _health;
    private int _points;

    public UnityEvent<int> OnSetMaxHealth; // установка максимального количества жизней
    public static UnityAction<int> OnHealthOver; // когда жизни закончились

    public UnityEvent<int> OnHealthChange; // когда кол-во жизней изменилось (передать новое количество жизней)
    public UnityEvent<int> OnGetPoints; // когда кол-во очков изменилось (передать новое количество очков)

    public UnityEvent<float> OnGetSlowedBonus; // когда получил бонус замедления (передать время замедления) //
    public UnityEvent<float> OnGetX2Bonus; // когда получил бонус х2 (передать время х2) //

    private void OnEnable()
    {
        GameController.OnStartGame += StartGame;
        X2Timer.EndX2Bonus += RemovePointsBonus;
        SlowedTimer.EndSlowedBonus += RemoveSlowedBonus;
    }

    private void OnDisable()
    {
        GameController.OnStartGame -= StartGame;
        X2Timer.EndX2Bonus -= RemovePointsBonus;
        SlowedTimer.EndSlowedBonus -= RemoveSlowedBonus;
    }

    public void StartGame() // установка характеристик при начале игры (после нажатия одной из кнопок начала игры)
    {
        OnSetMaxHealth?.Invoke(maxHealth);
        _health = maxHealth;
        _points = 0;
        StartCoroutine(IncreaseCounter());
    }

    private IEnumerator IncreaseCounter()
    {
        while (true)
        {
            yield return new WaitForSeconds(_timePointsDelay);
            AddPoints(_pointsAtTime);
        }
    }

    public void TakeDamage(int value)
    {
        _health -= value;
        OnHealthChange?.Invoke(_health);

        if (_health <= 0)
        {
            OnHealthOver?.Invoke(_points);
            StopCoroutine(IncreaseCounter());
        }
    }

    public void AddPoints(int points) // при получении очков
    {
        _points += points;
        OnGetPoints?.Invoke(_points);
    }

    public void AddSlowedBonus(float time) // при получении бонуса замедления
    {
        GetComponent<PlayerMover>().ChangeSpeed(true); 
        OnGetSlowedBonus?.Invoke(time);
    }

    public void RemoveSlowedBonus() => GetComponent<PlayerMover>().ChangeSpeed(false);

    public void AddX2Bonus(float time)
    {
        _pointsAtTime = 2;
        OnGetX2Bonus?.Invoke(time);
    }

    public void RemovePointsBonus() => _pointsAtTime = 1;

    public void AddHPBonus()
    {
        _health += 20;
        if (_health > maxHealth)
        {
            _health = maxHealth;
        }
        OnHealthChange?.Invoke(_health);

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bonus"))
        {
            other.gameObject.GetComponent<Bonus>().AddBonus(gameObject);
        }
        else
        {
            TakeDamage(20);
            Destroy(other.gameObject);
        }
    }
}
