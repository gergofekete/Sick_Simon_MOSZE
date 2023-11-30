using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuPresenter : MonoBehaviour
{
    private void Awake()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        // "Start Game" gomb kezelése
        var startButton = root.Q<Button>("startbtn");
        if (startButton != null)
        {
            startButton.clicked += OnStartGameButtonClicked;
        }

        // "Logout" gomb kezelése
        var logoutButton = root.Q<Button>("logoutbtn");
        if (logoutButton != null)
        {
            logoutButton.clicked += OnLogoutButtonClicked;
        }

        // További gombok és események kezelése szükség szerint
    }

    private void OnStartGameButtonClicked()
    {
        // A "GameScene" jelenet betöltése
        SceneManager.LoadScene("SampleScene");
    }

    private void OnLogoutButtonClicked()
    {
        // Kilépés a játékból
        UnityEngine.Application.Quit();

        // Ha az Editorban teszteled, akkor ezt a sort is add hozzá
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
