using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour
{
    public TimeKeeper timeKeeper;
    public Text playerSpeedText;
    public Text playerSizeText;

    // Start is called before the first frame update
    void Start()
    {
        UpdatePlayerSpeedUI();
        UpdatePlayerSizeUI();
        playerSizeText.text = GameDataManager.playerSize.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeKeeper.isTimerExpired())
        {
            // Load next scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void EndGame()
    {
        // Load next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void UpdatePlayerSpeedUI()
    {
        switch (GameDataManager.playerSpeed)
        {
            case 1:
                playerSpeedText.text = "Slow";
                break;
            case 2:
                playerSpeedText.text = "Normal";
                break;
            case 3:
                playerSpeedText.text = "Fast";
                break;
        }
    }

    public void UpdatePlayerSizeUI()
    {
        switch (GameDataManager.playerSize)
        {
            case 1:
                playerSpeedText.text = "Small";
                break;
            case 2:
                playerSpeedText.text = "Normal";
                break;
            case 3:
                playerSpeedText.text = "Large";
                break;
        }
    }
}
