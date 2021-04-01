using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScenes : MonoBehaviour {
	public GameObject startPanel;
	public GameObject levelPanel;
	public string mainScene;
	public string gameEasyScrene;

	private void Start() {
		this.startPanel.SetActive(true);
		this.levelPanel.SetActive(false);
	}

	public void GameStart() {
		this.startPanel.SetActive(false);
		this.levelPanel.SetActive(true);
	}

	public void GameExit() {
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#else
      Application.Quit();
#endif
	}

	public void GameLoadEasy() {
		SceneManager.LoadScene(gameEasyScrene);
	}
}
