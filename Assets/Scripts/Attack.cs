using System;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private bool isPlayerAttacking;
    [SerializeField] private bool isPlayerShooting;


    private Animator _animator;
    private AudioSource _audioSource;

    // Sound Effects
    [SerializeField] private AudioClip punchClip;
    [SerializeField] private AudioClip shootClip;

    private void Start()
    {
        DealComponents();
    }

    private void DealComponents()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    // Animator Controller Methods
    public void CloseAttack()
    {
        if (!isPlayerAttacking && !isPlayerShooting)
        {
            isPlayerShooting = false;
            isPlayerAttacking = true;
            _audioSource.clip = punchClip;
            _animator.SetTrigger("Attack");
            _audioSource.Play();
        }
    }

    public void RangeAttack()
    {
        if (!isPlayerShooting && !isPlayerAttacking)
        {
            isPlayerAttacking = false;
            isPlayerShooting = true;
            _animator.SetTrigger("Shoot");
        }
    }

    public bool IsPlayerAttacking()
    {
        return isPlayerAttacking;
    }
    
    public bool IsPlayerShooting()
    {
        return isPlayerShooting;
    }


    // Animator Controller Methods
    private void SetAttackingToFalse()
    {
        isPlayerAttacking = false;
    }

    private void SetShootingToFalse()
    {
        isPlayerShooting = false;
    }

    private void ShootSound()
    {
        _audioSource.clip = shootClip;
        _audioSource.Play();
    }
}