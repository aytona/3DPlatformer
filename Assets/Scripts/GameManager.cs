using UnityEngine;
using System.Collections;

public class GameManager : Singleton<GameManager> {

    private float _timeRemaining;
	private int _numCoins;

    public float TimeRemaining
    {
        get
        {
            return _timeRemaining;
        }
        set
        {
            _timeRemaining = value;
        }
    }

    public int NumCoins
    {
        get
        {
            return _numCoins;
        }
        set
        {
            _numCoins = value;
        }
    }

    private float maxTime = 5 * 60;

	void Start () {
        TimeRemaining = maxTime;
	}
	
	void Update () {
        TimeRemaining -= Time.deltaTime;

        if (TimeRemaining <= 0)
        {
            Application.LoadLevel(Application.loadedLevel);
            TimeRemaining = maxTime;
        }
	}
}
