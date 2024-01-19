using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBonus : Bonus
{
    override public void AddBonus(GameObject player)
    {
        player.GetComponent<Player>().AddHPBonus();
        Destroy(gameObject);
    }
}
