using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ManagerScript : MonoBehaviour
{

    private float previousTimeScale;
    public Button btnPause;
    public Sprite imagePause;
    public Sprite imageReStart;
    public GameObject canevasGame;
    public GameObject canevasSide;
    public GameObject canevasBottom;
    public GameObject canevasGameOver;
    public GameObject canevasTimeOver;
    private float timeLeft = 30f;
    private bool timerOn = false;
    public TextMeshProUGUI timerTxt;
    public GameObject pauseCanvas;
    public GameObject gameLogic;


    // Start is called before the first frame update
    void Start()
    {
        timerOn = true;
        pauseCanvas.SetActive(false);
        gameLogic.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (timerOn)
        {
            if(timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                UpdateTimer(timeLeft);
            } else
            {
                Debug.Log("Time is over");
                
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            }
        }
    }

    public void Pause()
    {
        if (Time.timeScale > 0)
        {
            previousTimeScale = Time.timeScale;
            Time.timeScale = 0;
            pauseCanvas.SetActive(true);
            /*btnPause.GetComponent<Image>().sprite = imageReStart;*/
        }
        

    }
    public void Resume()
    {
        Time.timeScale = previousTimeScale;
        pauseCanvas.SetActive(false);
        btnPause.GetComponent<Image>().sprite = imagePause;
    }

    public void Restart()
    {
        /*canevasGame.SetActive(true);
        canevasSide.SetActive(true);
        canevasBottom.SetActive(true);
        canevasGameOver.SetActive(false);*/
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void UpdateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float secondes = Mathf.FloorToInt(currentTime % 60);

        timerTxt.text = string.Format("Time: {0:00} : {1:00}", minutes, secondes);
    }
    public void Logic()
    {
        if (Time.timeScale > 0)
        {
            previousTimeScale = Time.timeScale;
            Time.timeScale = 0;
            gameLogic.SetActive(true);
            /*btnPause.GetComponent<Image>().sprite = imageReStart;*/
        }
        else
        {
            Time.timeScale = previousTimeScale;
            gameLogic.SetActive(false);

        }
    }

}
