using UnityEngine;
using UnityEngine.Events;


public class Player : MonoBehaviour
{
    [SerializeField] public int maxHealth;
    private int _health;
    private int _points;
    private int _givePoints;

    public UnityEvent<int> OnSetMaxHealth; // установка максимального количества жизней
    public static UnityAction<int> OnHealthOver; // когда жизни закончились

    public UnityEvent<int> OnHealthChange; // когда кол-во жизней изменилось (передать новое количество жизней)
    public UnityEvent<int> OnGetPoints; // когда кол-во очков изменилось (передать новое количество очков)

    public UnityEvent<float> OnGetSlowedBonus; // когда получил бонус замедления (передать время замедления) //
    public UnityEvent<float> OnGetX2Bonus; // когда получил бонус х2 (передать время х2) //

    private void OnEnable()
    {
        GameController.OnStartGame += StartGame;

    }

    private void OnDisable()
    {
        GameController.OnStartGame -= StartGame;
    }

    public void StartGame() // установка характеристик при начале игры (после нажатия одной из кнопок начала игры)
    {
        OnSetMaxHealth?.Invoke(maxHealth);
        _health = maxHealth;
        _givePoints = 1;
    }

    public void TakeDamage(int value)
    {
        _health -= value;
        OnHealthChange?.Invoke(_health);

        if (_health <= 0)
        {
            OnHealthOver?.Invoke(_points);
        }
    }

    public void AddPoints(int points) // при получении очков
    {
        _points += points;
        OnGetPoints?.Invoke(_points);
    }

    public void AddSlowedBonus(float time) // при получении бонуса замедления
    {
        GetComponent<PlayerMover>().ChangeSpeed(2); 
        OnGetSlowedBonus?.Invoke(time);
    }

    public void AddX2Bonus(float time)
    {
        _givePoints = 2;
        OnGetX2Bonus?.Invoke(time);
    }

    public void AddHPBonus()
    {
        _health += 20;
        if (_health > maxHealth)
        {
            _health = maxHealth;
        }
        OnHealthChange?.Invoke(_health);

    }
    public void Update()
    {
        AddPoints(_givePoints);
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
