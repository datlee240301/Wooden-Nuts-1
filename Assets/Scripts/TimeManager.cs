using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    // Update is called once per frame
    void Update()
    {
        if(remainingTime > 0)
            remainingTime -= Time.deltaTime;
        else if(remainingTime < 0) {
            remainingTime = 0;
            Debug.Log("vippro");
        }
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}",minutes,seconds);
    }
}
