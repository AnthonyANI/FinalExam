using UnityEngine;
using UnityEngine.UI;

public class LivesTracker : MonoBehaviour
{
    public static int lives = 9;
    public Text LivesRemaining;

    public void DecreaseLives()
    {
        lives -= 1;
        LivesRemaining.text = lives.ToString();
        Debug.Log(lives);
    }
    public void IncreaseLives()
    {
        lives += 1;
        LivesRemaining.text = lives.ToString();
        Debug.Log(lives);
    }

}
