using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainScreen, OptionScreen;
    public Button playButton, backButton;
    public Slider slider;
    public FloatSO scoreSO;


    private void Start()
    {
        playButton.Select();
    }
    public void OnButtonPlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnButtonGoMain()
    {
        SceneManager.LoadScene("Start");
    }

    public void OnButtonOption()
    {
        mainScreen.SetActive(false);
        slider.value = scoreSO.Value;
        OptionScreen.SetActive(true);
        backButton.Select();
    }

    public void OnButtonBack()
    {
        mainScreen.SetActive(true);
        OptionScreen.SetActive(false);
        playButton.Select();
    }

    public void OnButtonQuit()
    {
        Application.Quit();
    }
}
