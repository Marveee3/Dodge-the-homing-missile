using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        Time.timeScale = 0;
        gameObject.SetActive(true);
        anim.SetTrigger("Intro");
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
