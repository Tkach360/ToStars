using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveBonus : MonoBehaviour
{
    [SerializeField] private GameObject[] bonuses;
    public void MakeBonus(Transform parent_transform)
    {
        System.Random rnd = new System.Random();
        int type = rnd.Next(0, bonuses.Length);
        GameObject bonus_type = bonuses[type];
        int number = rnd.Next(0, 4);
        if (number == 0)
        {
            GameObject bonus_obj = Instantiate(bonus_type);
            bonus_obj.transform.position = parent_transform.position;
        }
        
    }
}
