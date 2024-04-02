using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text highScoreText;
    private float sceneStartTime;

    void Start()
    {
        scoreText.text = "0";
        sceneStartTime = Time.time;
        highScoreText.text = "high score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    void Update()
    {
        // Обновление текста с текущим временем сцены
        float currentSceneTime = Time.time - sceneStartTime; // Вычисление текущего времени сцены
        scoreText.text = "score: " + currentSceneTime.ToString("F0"); // "F0" форматирует число без десятичных знаков
        if (currentSceneTime > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", (int)currentSceneTime+2); // Записываем целочисленное значение времени
        }
    }
}
