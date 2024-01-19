using UnityEngine.Events;

public class X2Timer : BonusTimer
{
    public static UnityAction EndX2Bonus;
    override public void EndBonus()
    {
        EndX2Bonus?.Invoke();
    }
}