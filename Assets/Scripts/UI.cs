using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI : MonoBehaviour {

    [SerializeField]
    private Text timerLabel;
	
	void Update () 
    {
        timerLabel.text = FormatTime(GameManager.Instance.TimeRemaining);
	}

    private string FormatTime(float timeInSeconds)
    {
        return string.Format("{0}:{1:00}", Mathf.FloorToInt(timeInSeconds/60), Mathf.FloorToInt(timeInSeconds % 60));
    }
}
