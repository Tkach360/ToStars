using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    [SerializeField] protected GameObject bullet;
    [SerializeField] protected Transform shotPoint;
    protected float timeBtwShots;
    [SerializeField] protected float startTimeBtwShots;
}
