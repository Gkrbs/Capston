using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public GameObject hudContainer, gameOverPanel;
    public Text timeCounter, countdownText;
    public bool gamePlaying { get; private set; }
    public int countdownTime;


    private float startTime, elapsedTime;
    TimeSpan timePlaying;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        gameOverPanel.SetActive(false);
        timeCounter.text = "60";
        gamePlaying = false;
        StartCoroutine(CountdownToStart());
    }

    private void BeginGame()
    {
        gamePlaying = true;
        startTime = Time.time;
    }

    private void Update()
    {
        if (gamePlaying)
        {
            
            elapsedTime = Time.time - startTime;
            elapsedTime -= 120;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            if (elapsedTime >= -61)
            {
                EndGame();
            }
            string timePlayingStr = timePlaying.ToString("ss");
            timeCounter.text = timePlayingStr;
            
        }
    }

    private void EndGame()
    {
        gamePlaying = false;
        Invoke("ShowGameOverScreen", 1.25f);
    }

    private void ShowGameOverScreen()
    {
        gameOverPanel.SetActive(true);
        gameOverPanel.transform.Find("BackButton").GetComponent<Button>().Select();
    }

    IEnumerator CountdownToStart()
    {
        while (countdownTime > 0)
        {
            countdownText.text = countdownTime.ToString();
            yield return new WaitForSeconds(1f);
            countdownTime--;
        }

        BeginGame();
        countdownText.text = "FIGHT";

        yield return new WaitForSeconds(1f);

        countdownText.gameObject.SetActive(false);
    }

    public void OnButtonGoMain()
    {
        SceneManager.LoadScene("Start");
    }
}
