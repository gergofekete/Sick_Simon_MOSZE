using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.UI; // UI elemek kezel�s�hez

public class MainMenuPresenter : MonoBehaviour
{

    private void Awake()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        // "Start Game" gomb kezel�se
        var startButton = root.Q<UnityEngine.UIElements.Button>("startbtn");
        if (startButton != null)
        {
            startButton.clicked += OnStartGameButtonClicked;
        }

        // "Logout" gomb kezel�se
        var logoutButton = root.Q<UnityEngine.UIElements.Button>("logoutbtn");
        if (logoutButton != null)
        {
            logoutButton.clicked += OnLogoutButtonClicked;
        }

        // "Info" gomb kezel�se
        var infoButton = root.Q<UnityEngine.UIElements.Button>("infobtn");
        if (infoButton != null)
        {
            infoButton.clicked += OnInfoButtonClicked;
        }
    }

    private void OnStartGameButtonClicked()
    {
        SceneManager.LoadScene("SampleScene");
    }

    private void OnInfoButtonClicked()
    {
        ShowInfoImage(); // Megh�vja a ShowInfoImage met�dust
    }

    private void OnLogoutButtonClicked()
    {
        Application.Quit();
    }

    public void ShowInfoImage()
    {
        SceneManager.LoadScene("InfoScene");
    }
}