using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.UI; // UI elemek kezeléséhez

public class MainMenuPresenter : MonoBehaviour
{

    private void Awake()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        // "Start Game" gomb kezelése
        var startButton = root.Q<UnityEngine.UIElements.Button>("startbtn");
        if (startButton != null)
        {
            startButton.clicked += OnStartGameButtonClicked;
        }

        // "Logout" gomb kezelése
        var logoutButton = root.Q<UnityEngine.UIElements.Button>("logoutbtn");
        if (logoutButton != null)
        {
            logoutButton.clicked += OnLogoutButtonClicked;
        }

        // "Info" gomb kezelése
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
        ShowInfoImage(); // Meghívja a ShowInfoImage metódust
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