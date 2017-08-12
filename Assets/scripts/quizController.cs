using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

public class quizController : MonoBehaviour 
{

	public Button[] Buttons; 
	public quizReponses reponses;
	public Text tryAgain;
	public GameObject finalWindow;
	public GameObject quizWindow;
	public Text headerFinalWindow;
	public Text bodyTextFinal;

	int randomNUM;
	float currentTime = 0f;
	private int numTries = 1;
	bool stop;
	float timer = 0;
	bool userWon;



	void Start () 
	{
		currentTime = 0f;
		stop = false;
		PutText ();
		tryAgain.enabled = false;

		finalWindow.SetActive(false);
		quizWindow.SetActive (true);
	}




	void PutText()
	{
		tryAgain.enabled = false;

		for (int i = 0; i < reponses.Responses.Length; i++) 
		{
			Buttons [i].interactable = true;
			Buttons [i].enabled = true;
			Buttons [i].GetComponentInChildren<Text>().text = reponses.Responses[i];	
		}

		int randomNUM = Random.Range (0,Buttons.Length);
		Buttons [randomNUM].GetComponentInChildren<Text> ().text = reponses.RightAnswer;
	}




	public void verifyAnswer(Text answer)
	{

		switch (numTries) 
		{
		case 1:

			if (answer.text == reponses.RightAnswer) 
			{

				stop = true; 
				FinishGame(true);
				reponses.numTries = 1;

			} else {
				
				PauseAndResume ();
				reponses.numTries = 1;
			}
			break;
		case 2:

			if (answer.text == reponses.RightAnswer) 
			{

				stop = true; 
				FinishGame(true);
				reponses.numTries = 2;

			} else {
				
				FinishGame(false);
				reponses.numTries = 2;
			}
			break;
		default:
			Debug.Log ("DEFAULT CASE, A VER !!!!");
			break;
		}
	}




	void Update () 
	{
		if (!stop) 
		{
			currentTime += Time.deltaTime;
			GameObject.Find ("counterText").GetComponent<Text> ().text = currentTime.ToString ("#:00");	
			reponses.time = currentTime.ToString ("#:00");
		}
	}
		



	void SaveToFile (string name, string email, string time, int tries)
	{

		StringBuilder userdata = new StringBuilder();

			userdata.Append(System.Environment.NewLine);
			userdata.Append("User Name: " + name);
			userdata.Append(System.Environment.NewLine); //Change line
			userdata.Append("User Email: " + email);
			userdata.Append(System.Environment.NewLine); //Change line
			userdata.Append("Time to finish: " +time+" Sec.");
			userdata.Append(System.Environment.NewLine); //Change line
			userdata.Append("Numbres of Tries: " + tries.ToString());
			userdata.Append(System.Environment.NewLine); //Change line


		if (File.Exists (reponses.workingDirectory+reponses.fileName)) 
		{
			// Append new text to an existing file.
			// The using statement automatically flushes AND CLOSES the stream and calls 
			// IDisposable.Dispose on the stream object.

			using (System.IO.StreamWriter file = 
				new System.IO.StreamWriter (@""+reponses.workingDirectory+reponses.fileName, true)) 
			{
				file.WriteLine (userdata.ToString());
			}

		} else {

			// Write one string to a text file.
			// WriteAllText creates a file, writes the specified string to the file,
			// and then closes the file.    You do NOT need to call Flush() or Close().

			File.WriteAllText (@""+reponses.workingDirectory+reponses.fileName, userdata.ToString());

			}
	}




	void PauseAndResume()
	{
		Time.timeScale = 0;

		tryAgain.enabled = true;
		tryAgain.text = "TRY AGAIN !!!";

		for (int i = 0; i < Buttons.Length; i++) 
		{
			Buttons [i].interactable = false;
			Buttons [i].enabled = false;
		}

		StartCoroutine(ResumeAfterNSeconds(2.0f));
	}




	IEnumerator ResumeAfterNSeconds(float timePeriod)
	{
		yield return new WaitForEndOfFrame();

		timer += Time.unscaledDeltaTime;

		if(timer < timePeriod)
			StartCoroutine(ResumeAfterNSeconds(2.0f));
		else
		{
			Reinitialize ();
		}
	}




	void Reinitialize()
	{
		Time.timeScale = 1;                
		timer = 0;
		numTries++;
		tryAgain.enabled = false;
		PutText ();
	}




	void FinishGame(bool resultat)
	{
		quizWindow.SetActive(false);
		finalWindow.SetActive(true);
		SaveToFile (reponses.name,reponses.email,reponses.time,reponses.numTries);

		StringBuilder userInfo = new StringBuilder();
	

		if (resultat) 
		{
			headerFinalWindow.text = "Congratulations !!!";

			userInfo.Append(System.Environment.NewLine);
			userInfo.Append("Thank you " + reponses.name);
			userInfo.Append(System.Environment.NewLine); //Change line
			userInfo.Append("for having play The Perception Quiz ");
			userInfo.Append(System.Environment.NewLine); //Change line
			userInfo.Append("You have finished the challenge in " +reponses.time+" Sec.");
			userInfo.Append(System.Environment.NewLine); //Change line
			userInfo.Append("You took  " + reponses.numTries.ToString() + " chances.");
			userInfo.Append("See you next time.");
			userInfo.Append(System.Environment.NewLine); //Change line

			bodyTextFinal.text = userInfo.ToString();

		} 

		if(!resultat)
		{

			headerFinalWindow.text = "Sorry. You lost your bet";

			userInfo.Append(System.Environment.NewLine);
			userInfo.Append("Thank you " + reponses.name);
			userInfo.Append(System.Environment.NewLine); //Change line
			userInfo.Append("for having play The Perception Quiz ");
			userInfo.Append(System.Environment.NewLine); //Change line
			userInfo.Append("you did not guess the answer ");
			userInfo.Append(System.Environment.NewLine); //Change line
			userInfo.Append("you took  " + reponses.numTries.ToString() + " chances in  " +reponses.time+" Sec.");
			userInfo.Append("See you next time.");
			userInfo.Append(System.Environment.NewLine); //Change line

			bodyTextFinal.text = userInfo.ToString();
		}

	}
		
}
