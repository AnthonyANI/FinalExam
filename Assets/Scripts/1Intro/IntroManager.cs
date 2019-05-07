using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroManager : MonoBehaviour
{
    public Toggle useUserPrefs;
    public Slider playerSpeedSlider;
    public Dropdown playerSizeDropdown;
    public Dropdown gameTimerDropdown;

    // Start is called before the first frame update
    void Start()
    {
        GameDataManager.LoadGameOptions();
        UpdateUserPrefsUI();
    }

    public void PlayGame()
    {
        // Load next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void toggleUserPrefs(bool value)
    {
        playerSpeedSlider.interactable = value;
        playerSizeDropdown.interactable = value;
        gameTimerDropdown.interactable = value;
        GameDataManager.useUserPrefs = value;
        GameDataManager.SaveGameOptions();

        if (!value)
        {
            GameDataManager.LoadDefaultOptions();
        }
    }

    public void changePlayerSpeed()
    {
        GameDataManager.playerSpeed = (int)playerSpeedSlider.value;
        GameDataManager.SaveGameOptions();
    }

    public void changePlayerSize()
    {
        GameDataManager.playerSize = playerSizeDropdown.value + 1;
        GameDataManager.SaveGameOptions();
    }

    public void changeGameTimer()
    {
        GameDataManager.timer = gameTimerDropdown.value + 1;
        GameDataManager.SaveGameOptions();
    }

    private void UpdateUserPrefsUI()
    {
        useUserPrefs.isOn = GameDataManager.useUserPrefs;
        playerSpeedSlider.value = GameDataManager.playerSpeed;
        playerSizeDropdown.value = GameDataManager.playerSize - 1;
        gameTimerDropdown.value = GameDataManager.timer - 1;
    }
}
