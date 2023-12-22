using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public int maxHealth;
    private int _health;
    private int _points;

    public UnityEvent<int> OnSetMaxHealth; // установка максимального количества жизней
    public static UnityAction<int> OnHealthOver; // когда жизни закончились

    public UnityEvent<int> OnHealthChange; // когда кол-во жизней изменилось (передать новое количество жизней)
    public UnityEvent<int> OnGetPoints; // когда кол-во очков изменилось (передать новое количество очков)

    public UnityEvent<int> OnGetSlowedBonus; // когда получил бонус замедления (передать время замедления)
    public UnityEvent<int> OnGetX2Bonus; // когда получил бонус х2 (передать время х2)

    // бонусы сделаны так: PlayerController получает бонус, реализует его (делает замедление и т.д.)
    // а за временем действия следит таймер, у таймера есть событие UnityEvent OnBonusOver которое срабатывает
    // когда время закончилось, PlayerController должен отреагировать выключением конкретного бонуса

    public void StartGame() // установка характеристик при начале игры (после нажатия одной из кнопок начала игры)
    {
        OnSetMaxHealth?.Invoke(maxHealth);
        _health = maxHealth;
    }

    public void TakeDamage(int value)
    {
        _health -= value;
        OnHealthChange?.Invoke(_health);

        if(_health <= 0)
        {
            OnHealthOver?.Invoke(_points);
        }
    }

    public void AddPoints(int points) // при получении очков
    {
        _points += points;
        OnGetPoints?.Invoke(_points);
    }

    public void AddSlowedBonus(int time) // при получении бонуса замедления
    {
        // нужна логика замедления

        OnGetSlowedBonus?.Invoke(time);
    }

    public void AddX2Bonus(int time)
    {
        // нужна логика удвоения очков

        OnGetX2Bonus?.Invoke(time);
    }
}
