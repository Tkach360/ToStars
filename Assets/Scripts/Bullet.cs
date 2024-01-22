using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField] protected float speed;
    [SerializeField] protected float lifetime;
    [SerializeField] protected float distance;
    [SerializeField] protected LayerMask whatIsSolid;
}
