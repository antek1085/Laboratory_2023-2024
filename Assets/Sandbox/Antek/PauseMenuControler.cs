using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuControler : MonoBehaviour
{
    bool isPaused;

    Scene thisScene;

    [SerializeField] GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isPaused == false)
        {
            Time.timeScale = 0f;
            canvas.SetActive(true);
            isPaused = true;
            return;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused == true)
        {
            Time.timeScale = 1;
            canvas.SetActive(false);
            isPaused = false;
        }
    }

    public void Resume()
    {
        Time.timeScale = 1;
        canvas.SetActive(false);
        isPaused = false;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        canvas.SetActive(false);
        isPaused = false;
        thisScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(thisScene.name);
    }

    public void Exit()
    {
        Time.timeScale = 1;
        canvas.SetActive(false);
        isPaused = false;
        SceneManager.LoadScene("Antek StartMenu");
    }
}
