using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource music;

    void Start()
    {   
        InvokeRepeating("SavePos", 0f, 1f);
        // Проверяем, есть ли сохраненная позиция музыки в PlayerPref
        if (PlayerPrefs.HasKey("MusicPosition"))
        {
            float savedPosition = PlayerPrefs.GetFloat("MusicPosition");
            music.time = savedPosition;
        }

        // Запускаем музыку
        music.Play();
    }


    void SavePos()
    {
        PlayerPrefs.SetFloat("MusicPosition", music.time);
    }
}
