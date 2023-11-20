using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int HP = 5;
    public int maxHP = 5;
    public GameObject player;

    public bool IsDead
    {
        get => _isDead;
        set
        {
            if (value)
            {
                _isDead = true;
                // Get the players animator and set the dead trigger
                player.GetComponent<Animator>().SetTrigger("dead");
            }
            else
            {
                _isDead = false;
            }
        }
    }
    
    private bool _isDead;
    
    // Other global stats go here...
    
    private static GameManager _instance;
    
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
                if (_instance == null)
                {
                    GameObject go = new GameObject();
                    go.name = "GameManager";
                    _instance = go.AddComponent<GameManager>();
                    DontDestroyOnLoad(go);
                }
            }

            return _instance;
        }
    }
    
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        } 
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void substractHP(int damage)
    {
        if (HP > damage)
        {
            HP -= damage;
        }
        else
        {
            HP = 0;
            IsDead = true;
        }
    }
}
