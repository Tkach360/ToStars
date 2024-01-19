using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    public GameObject bullet;
    public Transform shotPoint;
    protected float timeBtwShots;
    public float startTimeBtwShots;
}
