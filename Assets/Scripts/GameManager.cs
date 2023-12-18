using System;
using System.Collections;
using System.Threading;
using Controls;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int HP = 5;
    public int maxHP = 5;
    public GameObject player;
    public bool hasSword = false;
    public bool isFirstRun = true;
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
                player.GetComponent<InputHandler>().enabled = false;
                StartCoroutine(RespawnPlayer() );
                 
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

    private IEnumerator RespawnPlayer()
    {
        yield return new WaitForSeconds(2);
        HP = maxHP;
        player.GetComponent<Animator>().SetTrigger("respawn");
        SceneManager.LoadScene("Town");
        player.GetComponent<Transform>().position = new Vector3(-7, -2, 0);
        player.GetComponent<InputHandler>().enabled = true;
    }
}
