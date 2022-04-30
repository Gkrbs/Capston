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

    public GameObject OptionScreen;
    public Button quitButton, backButton;

    public float optionTime = 0, backTime = 0, inerval = 0;

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
        if (Input.GetKey(KeyCode.Escape))
        {
            OnButtonOption();
        }

        if (gamePlaying)
        {

            elapsedTime = Time.time - startTime;
            elapsedTime -= 120 + inerval;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            if (elapsedTime >= -61)
            {
                EndGame();
            }
            string timePlayingStr = timePlaying.ToString("ss");
            timeCounter.text = timePlayingStr;

        }
    }

    private void Win()
    {

    }
    private void Defeat()
    {

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

    public void OnButtonOption()
    {
        optionTime = Time.time;
        gamePlaying = false;
        OptionScreen.SetActive(true);
        backButton.Select();
    }

    public void OnButtonBack()
    {
        backTime = Time.time;
        gamePlaying = true;
        OptionScreen.SetActive(false);
        inerval = backTime - optionTime;
    }

    public void OnButtonQuit()
    {
        gamePlaying = false;
        SceneManager.LoadScene("Start");
    }

}
