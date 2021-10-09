using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HyphensTest : MonoBehaviour
{

	void Start()
	{
		string str = "12345678901234567890123";
		str = AddHyphens(str);

		//Debug.Log(str);

	}
	public static string AddHyphens(string s)
	{
		string buildString = "";
		int currentIndex;

		//go through the line every 10 characters
		for (currentIndex = 0; currentIndex < s.Length; currentIndex += 10)
        {
			if (currentIndex + 10 < s.Length - 1) {
				//every 10 characters add to our built line and add a "-" and a new line to the end
				buildString += s.Substring(currentIndex, 10) + "-\n";
			}
            else
            {
				//if we've hit the end, stop the loop
				break;
            }
        }
		//add the last bit
		buildString += s.Substring(currentIndex, s.Length - currentIndex);

		//return the fully built string
		return buildString;
	}
}
