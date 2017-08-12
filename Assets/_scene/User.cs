/*
  # ================================================================================================== #
  # DESCRIPCION DE LA CLASE #
  # DESCRIPCION DE LA CLASE #
  #                                   Creado por: Argenis Mills                                      # 
  # ================================================================================================== #
*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace LeQuiz
{

public class User : MonoBehaviour 
{

	private string _userID;
	private string _userPrenom;
	private string _userEmail;
	private string _name;
	private int _userNumSucces;
	private int _userNumEchecs;
	private string _timePlayed;
	private double _timeReponseXquiz;
	private int _score;

	
	public User()
	{
			
	}
		
						// ------- ACCESSORS ------- //

	public string UserId 
	{
		get
		{
			return _userID;
		}
		set
		{
			_userID = value;
		}
	}


	public string UserName 
	{
		get
		{
			return _name;
		}

		set 
		{ 
			_name = value; 
		}
	}


	public string UserEmail 
	{
		get 
		{
			return _userEmail;
		}

		set 
		{ 
			_userEmail = value; 
		}
	}


	public string TimePlayed 
	{
		get
		{
			return _timePlayed;
		}
		set 
		{ 
			_timePlayed = value; 
		}
	}
/*
	public int NumSucces 
	{
		get
		{
			return _userNumSucces;
		}

		set { ; }
	}

	public int NumEchecs 
	{
		get
		{ 
			return _userNumEchecs; 
		}

		set { ; }
	}

	

	public double TimeReponse 
	{
		get 
		{
			return _timeReponseXquiz;
		}

		set { ; }
	}

	public int Score 
	{
		get 
		{
			return _score;
		}

		set { ; }
	}
*/
}
}