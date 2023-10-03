using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator _animator;
    public float Health
    {
        set
        {
            health = value;
            if (health <= 0)
            {
                Defeated();
            }
        }
        get
        {
            return health;
        }
    }

    private float health;

    public void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Defeated()
    {
        _animator.SetTrigger("Defeated");
    }
    
    public void RemoveEnemy()
    {
        Destroy(gameObject);
    }
}