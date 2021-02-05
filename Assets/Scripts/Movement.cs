using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float walkSpeed;

    private Rigidbody2D rb;
    private Animator _animator;
    private AudioSource _audioSource;
    private SpriteRenderer _spriteRenderer;

    private float xAxis;
    private float stepSoundWaitTime = 0;

    // Sound Clips
    [Header("Sound Effects")] [SerializeField]
    private AudioClip footStep;


    private void Start()
    {
        DealComponents();
    }

    private void Update()
    {
        stepSoundWaitTime += Time.deltaTime;
    }

    private void DealComponents()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    public void Move()
    {
        xAxis = Input.GetAxis("Horizontal") * Time.deltaTime * walkSpeed;
        Vector2 newVelocity = new Vector2(xAxis, rb.velocity.y);
        rb.velocity = newVelocity;
    }

    public void StopPlayer()
    {
        rb.velocity = Vector2.zero;
    }

    public void Animations()
    {
        _animator.SetBool("isWalking", IsPlayerMoving());
    }

    public void Flip()
    {
        if (rb.velocity.x > 0.01f)
        {
            _spriteRenderer.flipX = false;
        }
        else if (rb.velocity.x < -0.01f)
        {
            _spriteRenderer.flipX = true;
        }
    }

    public bool IsPlayerMoving()
    {
        if (xAxis != 0)
        {
            return true;
        }

        return false;
    }


    // Animator Controller Methods
    private void StepSound()
    {
        _audioSource.clip = footStep;
        _audioSource.Play();
    }
}