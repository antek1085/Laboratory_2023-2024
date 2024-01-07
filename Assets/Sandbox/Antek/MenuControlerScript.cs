using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControlerScript : MonoBehaviour
{
    [Header("PlayButton/LoadingScene")]
    [SerializeField] string levelToLoad;//level wich to load
    // [SerializeField] Scene uiLoad;
    [SerializeField] private GameObject loadingScreen; //loading Screen object
    [SerializeField] private Slider slider;
    private float loading;
    [SerializeField] float delay;
    [Header("MenuButtons")]
    [SerializeField] private GameObject menuButtons;
    [SerializeField] private GameObject optionButtons;

    [SerializeField] private Slider musicSlider;
   
        
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        optionButtons.SetActive(false);
        loadingScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(delay);
        if (delay < -1)
        {
            delay = 2;
        }
    }

   public void StartButton()
   {
       loadingScreen.SetActive(true);
       menuButtons.SetActive(false);
       StartCoroutine(LoadSceneAsync());
   }

    IEnumerator LoadSceneAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(levelToLoad);
        asyncLoad.allowSceneActivation = false;
        
        while(!asyncLoad.isDone && delay > 0)
        {
            loading = Mathf.Clamp01(asyncLoad.progress / 0.9f);
            delay -= Time.deltaTime;
            slider.value = 1 - (delay / asyncLoad.progress);
            Debug.Log(-1 - (delay / asyncLoad.progress));
            
            yield return null;
        }
        asyncLoad.allowSceneActivation = delay <= 0;
    }
    
    public void ExitButton()
    {
        Application.Quit();
    }

    public void OptionButton()
    {
        optionButtons.SetActive(true);
        menuButtons.SetActive(false);
    }

    public void BackButton()
    {
        optionButtons.SetActive(false);
        menuButtons.SetActive(true);
    }

    public void MusicValue()
    {
        AudioListener.volume = musicSlider.value;
    }
}
