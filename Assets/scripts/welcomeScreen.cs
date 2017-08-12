using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class welcomeScreen : MonoBehaviour 
{

	public Button start;
	public Text Name;
	public Text Email;
	public quizReponses reponses;
	public InputField mainInputField;
	public InputField secondInputField;

	void Start () 
	{
		//Button start = GetComponentInChildren<Button> ();
		mainInputField.ActivateInputField(); 
		start.GetComponentInChildren<Image> ().color = Color.blue;
	}
	

	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Tab) && mainInputField.text != "") 
		{
			secondInputField.ActivateInputField ();	
		}
			
			if (start.GetComponentInChildren<Image> ().color == Color.blue) {
				start.GetComponentInChildren<Image> ().color = Color.red;
			} else {
				start.GetComponentInChildren<Image> ().color = Color.blue;
			}
	}

	public void initializeGame()
	{
		if (mainInputField.text == "") {

			Debug.Log ("You have to give me your name");

		} else if (secondInputField.text == "") {
			
			Debug.Log ("You have to give me your Email");

		} else {

			SceneManager.LoadScene ("le_quiz", LoadSceneMode.Single);

			reponses.name = Name.text;
			reponses.email = Email.text;		

		}
	}
}
