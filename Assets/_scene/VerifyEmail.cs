/*
  # ================================================================================================== #
  # DESCRIPCION DE LA CLASE #
  # DESCRIPCION DE LA CLASE #
  #                                   Creado por: Argenis Mills                                      # 
  # ================================================================================================== #
*/
using UnityEngine;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace LeQuiz
{
	
public class VerifyEmail : MonoBehaviour 
{

	public const string MatchEmailPattern =
		@"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
            + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
              + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
            + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";


	// FUNCTION THAT VERIFIES IF THE EMAIL IS VALID
	public static bool IsEmail(string email)
	{
		if (email != null) return Regex.IsMatch(email, MatchEmailPattern);
		else return false;
	}

}
}