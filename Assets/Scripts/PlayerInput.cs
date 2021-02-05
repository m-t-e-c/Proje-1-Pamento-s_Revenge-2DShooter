using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Movement _movement;
    private Attack _attack;

    private void Start()
    {
        DealComponents();
    }

    private void DealComponents()
    {
        _movement = GetComponent<Movement>();
        _attack = GetComponent<Attack>();
    }

    private void Update()
    {
        _movement.Animations();
        _movement.Flip();

        if (Input.GetMouseButtonDown(1))
        {
            _attack.CloseAttack();
        }
        else if (Input.GetMouseButtonDown(0))
        {
            _attack.RangeAttack();
        }
    }

    private void FixedUpdate()
    {
        if (_attack.IsPlayerAttacking() || _attack.IsPlayerShooting())
        {
            _movement.StopPlayer();
            return;
        }

        _movement.Move();
    }
}