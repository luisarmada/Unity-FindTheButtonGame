using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{

    public Button PlayButton, SettingsButton, CreditsButton;
    public GameObject settingsCanvas;

    public Toggle fsToggle;

    public GameObject creditsText;

    // Start is called before the first frame update
    void Start()
    {

        // Main Menu Button Events
        PlayButton.onClick.AddListener(StartGame);

        SettingsButton.onClick.AddListener(ToggleSettings);

        CreditsButton.onClick.AddListener(ToggleCredits);

        // Default
        settingsCanvas.SetActive(false);
        creditsText.SetActive(false);
    }

    void StartGame()
    {
        StartCoroutine(LoadGameScene());
    }

    private void ToggleCredits()
    {
       settingsCanvas.SetActive(false);
       creditsText.SetActive(!creditsText.activeSelf);
    }

    void ToggleSettings()
    {
        creditsText.SetActive(false);
        settingsCanvas.SetActive(!settingsCanvas.activeSelf);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void SetFullscreen()
    {
        Screen.fullScreen = fsToggle.isOn;
    }

    // Main Game Loader
    IEnumerator LoadGameScene()
    {
        yield return new WaitForSeconds(2f); // delay to ensure fade is complete
        SceneManager.LoadScene("MainScene");
    }

}
