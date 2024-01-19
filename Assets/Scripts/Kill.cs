using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UIElements;

public class Kill : MonoBehaviour, Killable
{
    public void KillObject()
    {
        GetComponent<GiveBonus>().MakeBonus(gameObject.transform);
        Destroy(gameObject);
    }
}
