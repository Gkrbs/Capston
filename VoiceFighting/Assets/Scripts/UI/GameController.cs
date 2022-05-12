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
    public GameObject win, defeat, draw;

    public Text timeCounter, countdownText;

    public GameObject OptionScreen;
    public Button quitButton, backButton;

    public float optionTime = 0, backTime = 0, inerval = 0;

    public bool gamePlaying { get; private set; }
    public int countdownTime;

    private float startTime, elapsedTime;
    TimeSpan timePlaying;


    public Image playerHealthBarIMAG, enemyHealthBarIMAG;
    public static bool isGameOver;

    private CharacterAnimation player_Anim;
    private CharacterAnimation enemy_Anim;

    public Slider slider;
    public FloatSO scoreSO;

    [Space]
    [Range(0, 100f)]
    public float playerHealth = 100f;
    [Range(0, 100f)]
    public float enemyHealth = 100f;
    float playerHealthValue;
    float enemyHealthValue;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        player_Anim = GameObject.Find("Player").GetComponent<CharacterAnimation>();
        enemy_Anim = GameObject.Find("Player").GetComponent<CharacterAnimation>();

        gameOverPanel.SetActive(false);
        timeCounter.text = "60";
        gamePlaying = false;
        isGameOver = false;
        StartCoroutine(CountdownToStart());
    }

    private void Update()
    {
        playerHealthValue = playerHealth * .01f;
        playerHealthBarIMAG.fillAmount = playerHealthValue;

        enemyHealthValue = enemyHealth * .01f;
        enemyHealthBarIMAG.fillAmount = enemyHealthValue;
        
        if(playerHealth <= 0f)
        {
            playerHealth = 0f;
            player_Anim.Death(true);
            FindObjectOfType<AudioManager>().Play("playerDeath");
        }
        if (enemyHealth <= 0f)
        {
            enemyHealth = 0f;
            enemy_Anim.Death(true);
            FindObjectOfType<AudioManager>().Play("playerDeath");
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            OnButtonOption();
        }
        
        if (gamePlaying)
        {
            if (playerHealth == 0 || enemyHealth == 0)
            {
                EndGame();
            }
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

    private void BeginGame()
    {
        gamePlaying = true;
        startTime = Time.time;
    }

    private void EndGame()
    {
        if (playerHealth == enemyHealth)
        {
            Draw();
        }
        else if (playerHealth < enemyHealth)
        {
            Defeat();
        }
        else if(enemyHealth < playerHealth)
        {
            Win();
        }
        ShowGameOverScreen();
    }

    private void Win()
    {
        win.SetActive(true);
        defeat.SetActive(false);
        draw.SetActive(false);
    }

    private void Defeat()
    {
        win.SetActive(false);
        defeat.SetActive(true);
        draw.SetActive(false);
    }

    private void Draw()
    {
        win.SetActive(false);
        defeat.SetActive(false);
        draw.SetActive(true);
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

        slider.value = scoreSO.Value;

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
