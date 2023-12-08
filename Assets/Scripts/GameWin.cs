using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameWin : MonoBehaviour
{
    private PlayerController playerController;
    public GameObject gamewinUI;


    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        int eletero = playerController.itemCount;
        if (eletero == 6)
        {
            gamewinUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void NewGameButton()
    {

        Time.timeScale = 1;
        playerController.itemCount = 0;
        SceneManager.LoadScene("SampleScene");
    }

    public void MenuButton()
    {

        Time.timeScale = 1;
        playerController.itemCount = 0;
        SceneManager.LoadScene("MainMenu");
    }
}
