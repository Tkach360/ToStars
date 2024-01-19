using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsBonus : Bonus
{
    override public void AddBonus(GameObject player)
    {
        player.GetComponent<Player>().AddX2Bonus(10);
        Destroy(gameObject);
    }
}
