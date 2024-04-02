using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{   
    private bool gameHasEnded = false;
    [SerializeField] private Text scoreText;
    [SerializeField] private Airplane airplane;
    private Animator anim;


    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void EndGame()
    {   
        if(gameHasEnded)return;

        anim.SetTrigger("EndGame");
        airplane.enabled = false;

        gameHasEnded = true;
    }

    void RestartLevel()
    {   
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
