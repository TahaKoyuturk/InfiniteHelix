using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PM : MonoBehaviour
{
    //[SerializeField] public GameObject PauseMenuPanel;
    //public Image pause;
    //public Image resume;
    //private void Start()
    //{

    //}
    //public void Pause()
    //{

    //    pause.enabled = true;
    //    resume.enabled = false;

    //    Time.timeScale = 0f;

    //}
    //public void Resume()
    //{
    //    pause.enabled = false;
    //    resume.enabled = true;
    //    Time.timeScale = 1f;
    //}
    public GameObject pauseMenuScreen;
    public void PauseGame()
    {
        pauseMenuScreen.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ResumeGame()
    {
        pauseMenuScreen.SetActive(false);
        Time.timeScale = 1f;
    }
}
