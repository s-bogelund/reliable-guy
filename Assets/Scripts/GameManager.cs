using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int HP = 5;
    public int maxHP = 5;
    public bool isDead = false;
    
    // Other global stats go here...

    #region Singleton
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    #endregion Singleton

    public void substractHP(int damage)
    {
        if (HP > damage)
        {
            HP -= damage;
        }
        else
        {
            HP = 0;
            isDead = true;
        }
    }
}
