using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class clickFinalButtons : MonoBehaviour 
{

	public void OnClick()
	{
		if (this.name == "Restart") 
		{
			SceneManager.LoadScene ("welcomeScreen", LoadSceneMode.Single);

		} else	if (this.name == "Finish") 
		{
			UnityEditor.EditorApplication.isPlaying = false;
			Application.Quit();
		}
	}


}
