using UnityEngine;
using UnityEngine.SceneManagement﻿;
public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public float restartdelay = 5f;


    Animator anim;
    float restarttimer;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("GameOver");
            restarttimer += Time.deltaTime;
            if (restarttimer >= restartdelay)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
