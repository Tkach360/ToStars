using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _tapForce;
    [SerializeField] private float _speed;
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _rigidbody2D.velocity = new Vector2(_speed, _tapForce);
        }
        else
        {
            _rigidbody2D.velocity = new Vector2(_speed, -_tapForce);
        }
    }
    public void ChangeSpeed(float times)
    {
        _speed = _speed / times;
    }
}
