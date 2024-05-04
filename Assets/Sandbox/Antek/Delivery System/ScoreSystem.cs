using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private SOFloat numberOfPoints;

    [SerializeField] private TextMeshProUGUI textNumberOfPoints;

    [SerializeField] private float numberToWin;

    [SerializeField] private RoundTimer timeLeft;

    [Header("End of level")]
    [SerializeField] private TextMeshProUGUI resetText;
    [SerializeField] private string scene;
    [SerializeField] private TextMeshProUGUI endText;
    private Scene thisScene;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        endText.enabled = false;
        //numberOfPoints.Value = 0;
        resetText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        textNumberOfPoints.text = numberOfPoints.Value.ToString() + "/4";

    //     if (timeLeft.totalTime < 0)
    //     {
    //         if (numberOfPoints.Value > numberToWin)
    //         { 
    //             endText.enabled = true;
    //             endText.text = "You Win";
    //         }
    //         else
    //         {
    //             endText.enabled = true;
    //             endText.text = "You lose";
    //         }
    //         Time.timeScale = 0;
    //         resetText.enabled = true;
    //         if (Input.GetKeyDown(KeyCode.R))
    //         {
    //             SceneManager.LoadScene(scene);
    //         }
    //     }
    //     else if (numberOfPoints.Value == numberToWin)
    //     {
    //         endText.enabled = true;
    //         endText.text = "You Win";
    //         Time.timeScale = 0;
    //         resetText.enabled = true;
    //         if (Input.GetKeyDown(KeyCode.R))
    //         {
    //             SceneManager.LoadScene(scene);
    //         }
    //     }
     }
}
