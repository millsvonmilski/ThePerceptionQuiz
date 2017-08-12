/*
  # ================================================================================================== #
  # DESCRIPCION DE LA CLASE #
  # DESCRIPCION DE LA CLASE #
  #                                   Creado por: Argenis Mills                                      # 
  # ================================================================================================== #
*/
using UnityEngine;
using System.Xml;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace LeQuiz
{

	public class XmlParser : MonoBehaviour 
{

	public User user;
	public UserData userData;

		void Start()
		{
			
		}

		public void SaveToFile()
		{
			XmlSerializer xs = new XmlSerializer(typeof(User));
			using (StreamWriter wr = new StreamWriter("userInfo.xml"))
			{
				xs.Serialize(wr, user);
			}

		}

}
}