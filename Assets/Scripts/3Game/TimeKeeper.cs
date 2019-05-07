using UnityEngine;
using UnityEngine.UI;

public class TimeKeeper : MonoBehaviour
{
    public bool isTimerEnabled = true;
    public float timer = 30;
    public Text timerText;
    // Start is called before the first frame update
    void Start()
    {
        SetGameTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimerEnabled)
        {
            timer -= Time.deltaTime;
            if (timerText)
                timerText.text = ((int)timer).ToString();
        }
        else
        {
            if (timerText)
                timerText.text = "Unlimited";
        }

        if (timer <= 0)
        {
            timerText.color = Color.red;
        }
    }

    public bool isTimerExpired()
    {
        return isTimerEnabled && timer < 0;
    }

    private void SetGameTimer()
    {
        switch (GameDataManager.timer)
        {
            case 1:
                timer = 15;
                break;
            case 2:
                timer = 30;
                break;
            case 3:
                timer = 60;
                break;
            case 4:
                isTimerEnabled = false;
                break;
        }
    }
}
