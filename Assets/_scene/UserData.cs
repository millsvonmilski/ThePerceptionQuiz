/*
  # ================================================================================================== #
  # DESCRIPCION DE LA CLASE #
  # DESCRIPCION DE LA CLASE #
  #                                   Creado por: Argenis Mills                                      # 
  # ================================================================================================== #
*/

using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace LeQuiz
{

public class UserData : MonoBehaviour 
{

	public User user;
	public UniqueID uniqueID;
	public VerifyEmail verifyEmail;
	public XmlParser xmlParser;
	public InputField nom;
	public InputField email;
	public bool gameStarted;
	public float currentTime;


	void Start()
	{
		gameStarted = false;  // GAME N'AS PAS ENCORE COMMENCE
	}


	void Update () 
	{
		TimePlayed ();
	}

	public void UserIdentification()
	{
		
		if (nom.text == "") 
		{

			Debug.Log ("You have to give me your name");

		} else if (email.text == "") 
		{

			Debug.Log ("You have to give me your Email");

		} else if(!VerifyEmail.IsEmail(email.text))
		{
			Debug.Log ("Give me a valid email");

		} else 
		{

			//SceneManager.LoadScene ("le_quiz", LoadSceneMode.Single);
					
			user.UserName = nom.text;
			user.UserEmail = email.text;

			gameStarted = true;

			// CREATE THE USER ID.
			user.UserId = uniqueID.getID();
			xmlParser.SaveToFile ();
		}
	}

	void TimePlayed()
	{
		if (gameStarted) 
		{
			currentTime += Time.deltaTime;
			user.TimePlayed = currentTime.ToString ("#:00");
		}
	}
/*
	public int Score()
	{
		
	}

	void TimeReponse()
	{
		
	}

	void ControlSuccesEchecs()
	{
		
	}
*/
  }
}
