using UnityEngine.Events;

public class SlowedTimer : BonusTimer
{
    public static UnityAction EndSlowedBonus;

    override public void EndBonus()
    {
        gameObject.SetActive(false);
        _time = 0f;
        EndSlowedBonus?.Invoke();
    }
}