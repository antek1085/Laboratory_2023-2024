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

    [SerializeField] private TextMeshProUGUI resetText;

    private Scene thisScene;

    [SerializeField] private string scene;
    // Start is called before the first frame update
    void Start()
    {
        resetText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        textNumberOfPoints.text = numberOfPoints.Value.ToString();

        if (numberOfPoints.Value > numberToWin)
        {
            Debug.Log("Win");
        }
        else if (timeLeft.totalTime < 0)
        {
            Time.timeScale = 0;
            resetText.enabled = true;
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(scene);
            }
            Debug.Log("Lose");
        }
    }
}
