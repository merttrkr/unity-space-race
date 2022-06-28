using UnityEngine;
using UnityEngine.UI;

public class RemainingTime : MonoBehaviour
{
    public float TimeLeft = 10f;
    public bool TimerOn = false;

    public Text TimerTxt;

    private void Start()
    {
        TimerOn = true;
    }

    private void Update()
    {
        if (TimerOn)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                updateTimer(TimeLeft);
            }
            else
            {
                Debug.Log("Time is UP!");
                TimeLeft = 0;
                TimerOn = false;
                FindObjectOfType<GameManager>().EndGame();
            }
        }
    }

    private void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        TimerTxt.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}