using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	private static GameManager instance;
	public static GameManager Instance => instance;
	public bool IsGameStart = false;
    public GameObject gameOverCanvas;
	public GameObject starGameCanvas;

	// Start is called before the first frame update

	protected void Awake()
	{
		if (GameManager.instance != null) Debug.LogWarning("Only 1 GameManager allow to exist");
		GameManager.instance = this;
	}
	public void Start()
	{
		Time.timeScale = 1;
		this.gameOverCanvas.SetActive(false);
		this.starGameCanvas.SetActive(true);
	}

	private void Update()
	{
		if(!IsGameStart & Input.GetMouseButtonDown(0))
		{
			GameStart();
		}
	}

	public void GameStart()
	{
		IsGameStart = true;
		this.starGameCanvas.SetActive(false);
		Time.timeScale = 1;
	}

	public void GameOver()
    {
		gameOverCanvas.SetActive(true);
        Time.timeScale = 0;
    }

	public void Replay()
	{
		SceneManager.LoadScene(0);
	}
}
