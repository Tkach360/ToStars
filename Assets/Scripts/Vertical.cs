using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vertical : MonoBehaviour
{
    [SerializeField] private int speed;
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        speed *= -1;
    }
}
