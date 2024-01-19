using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBonus : Bonus
{
    override public void AddBonus(GameObject player)
    {
        player.GetComponent<Player>().AddSlowedBonus(1);
        Destroy(gameObject);
    }
}
