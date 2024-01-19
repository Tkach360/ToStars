using UnityEngine.Events;

public class SlowedTimer : BonusTimer
{
    public static UnityAction EndSlowedBonus;
    override public void EndBonus()
    {
        EndSlowedBonus?.Invoke();
    }
}