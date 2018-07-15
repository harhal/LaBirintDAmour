
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameScript : MonoBehaviour {

	public Image image;

	private void Update()
	{
		if (Input.GetKey(KeyCode.Escape))
		{
			SceneManager.LoadScene("Menu");
			//Application.Quit();
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Time.timeScale = 0;
		image.gameObject.SetActive(true);
		//Debug.Log("Extis");
	}
}
