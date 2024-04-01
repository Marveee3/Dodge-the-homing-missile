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
    private float sceneStartTime; // Время начала сцены

    void Start()
    {
        anim = GetComponent<Animator>();
        scoreText.text = "0";
        sceneStartTime = Time.time; // Инициализация времени начала сцены
    }

    void Update()
    {
        // Обновление текста с текущим временем сцены
        float currentSceneTime = Time.time - sceneStartTime; // Вычисление текущего времени сцены
        scoreText.text = "time: " + currentSceneTime.ToString("F0"); // "F0" форматирует число без десятичных знаков
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
