using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameOver : MonoBehaviour
{
    private PlayerController playerController;
    public GameObject gamelostUI;


    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        int eletero = playerController.eletero;
        if (eletero == 0)
        {
            gamelostUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void RestartButton()
    {

        Time.timeScale = 1;
        playerController.eletero = 4;
        SceneManager.LoadScene("SampleScene");
    }

    public void DeadMenubtn()
    {

        Time.timeScale = 1;
        playerController.eletero = 4;
        SceneManager.LoadScene("MainMenu");
    }
}
