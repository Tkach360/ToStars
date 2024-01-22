using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _tapForce;
    [SerializeField] private float _speed;
    private float _speedInSlow;
    private float _speedOutSlow;
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _speedInSlow = _speed / 2f;
        _speedOutSlow = _speed;
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
    public void ChangeSpeed(bool mode)
    {
        if (mode) _speed = _speedInSlow;
        else _speed = _speedOutSlow;
    }
    public void SetSpeed(float speed)
    {
        _speed = speed;
    }
}
