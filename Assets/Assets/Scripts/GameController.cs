using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public GameObject redGhost;
	public Text timerText;
	public Text loseText;

	private int timer;
	private int startTime;
	private int elapsedTime;

	void Start ()
	{
		loseText.text = "";
		startTime = (int) Time.time;
		SetTimerText();
		InvokeRepeating("SpawnGhost", 0.0f, 5.0f);
	}

	void Update () {
		if(Input.GetKeyDown(KeyCode.R))
		{
			Time.timeScale = 1;
			SceneManager.LoadScene( SceneManager.GetActiveScene().name );
		}
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}

		SetTimerText();
	}

	void SetTimerText ()
	{
		elapsedTime = (int) Time.time - startTime;
		timerText.text = "Time: " + elapsedTime.ToString();
	}

	void SpawnGhost ()
	{
		Instantiate(redGhost, new Vector3(0f, 0f, 0f), Quaternion.identity);
	}

	public void GameOver()
	{
		loseText.text = "Game Over!";
		Time.timeScale = 0;
	}

}
