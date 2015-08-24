using UnityEngine;
using System.Collections;

public class GameManager : Singleton<GameManager> {

    private float _timeRemaining;
	private int _numCoins;
	private float maxTime = 5 * 60;
	private float _playerHealth;
	private int maxHealth = 3;
	private bool isInvulnerable = false;

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

	public float PlayerHealth
	{
		get
		{
			return _playerHealth;
		}
		set
		{
			_playerHealth = value;
		}
	}

	public float GetPlayerHealthPercentage()
	{
		return PlayerHealth / (float)maxHealth;
	}

	private void DecrementPlayerHealth(GameObject player)
	{
		if (isInvulnerable)
		{
			return;
		}

		StartCoroutine (InvulnerableDelay());

		PlayerHealth--;

		if(PlayerHealth <= 0)
		{
			Restart();
		}
	}

	private void Restart()
	{
		Application.LoadLevel(Application.loadedLevel);
		TimeRemaining = maxTime;
		PlayerHealth = maxHealth;
	}

	void OnEnable()
	{
		DamagePlayer.OnDamagePlayer += DecrementPlayerHealth;
	}

	void OnDisable()
	{
		DamagePlayer.OnDamagePlayer -= DecrementPlayerHealth;
	}

	void Start () {
        TimeRemaining = maxTime;
		PlayerHealth = maxHealth;
	}
	
	void Update () {
        TimeRemaining -= Time.deltaTime;

        if (TimeRemaining <= 0)
        {
			Restart();
        }
	}

	private IEnumerator InvulnerableDelay()
	{
		isInvulnerable = true;
		yield return new WaitForSeconds(1.0f);
		isInvulnerable = false;
	}
}
