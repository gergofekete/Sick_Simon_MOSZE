using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuPresenter : MonoBehaviour
{
    private void Awake()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        // "Start Game" gomb kezel�se
        var startButton = root.Q<Button>("startbtn");
        if (startButton != null)
        {
            startButton.clicked += OnStartGameButtonClicked;
        }

        // "Logout" gomb kezel�se
        var logoutButton = root.Q<Button>("logoutbtn");
        if (logoutButton != null)
        {
            logoutButton.clicked += OnLogoutButtonClicked;
        }

        // Tov�bbi gombok �s esem�nyek kezel�se sz�ks�g szerint
    }

    private void OnStartGameButtonClicked()
    {
        // A "GameScene" jelenet bet�lt�se
        SceneManager.LoadScene("SampleScene");
    }

    private void OnLogoutButtonClicked()
    {
        // Kil�p�s a j�t�kb�l
        UnityEngine.Application.Quit();

        // Ha az Editorban teszteled, akkor ezt a sort is add hozz�
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
