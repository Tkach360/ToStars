using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class X2Timer : BonusTimer
{
    public static UnityAction EndX2Bonus;
    override public void EndBonus()
    {
        gameObject.SetActive(false);
        _time = 0f;
        EndX2Bonus?.Invoke();
    }
}