using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Linq;
using UnityEngine.UI;
using UnityEditor;
using System.IO;
using System;


public class Hyphens : MonoBehaviour
{
	public Text DisplayBtnText;                     
    public Text BtnText { get; set; }

	void Start()
	{
		this.gameObject.GetComponent<Button>().onClick.AddListener(delegate ()
            {
                Text text= this.gameObject.GetComponentInChildren<Text>();
                //BtnText = text;
				string Mytxt = ("C:\\Users\\Luo\\Desktop\\sample.txt");
				string[] str = File.ReadAllLines(Mytxt); 
				//str = "12345678910";
				string Nstr = AddHyphens(str);
				DisplayBtnText.text = Nstr;
            }
            );

	}
	public static string AddHyphens(string[] s)
	{
		string buildString = "";
		int currentIndex;
		foreach (string i in s){
		//go through the line every 10 characters
			if (i.Length > 1){
				for (currentIndex = 0; currentIndex < i.Length; currentIndex += 11)
				{
					if (currentIndex + 11 < i.Length - 1) {
					//every 10 characters add to our built line and add a "-" and a new line to the end
						buildString += i.Substring(currentIndex, 11) + "-\n";
					}
					else{
					//if we've hit the end, stop the loop
						break;
					}
				}
				//add the last bit
				buildString += i.Substring(currentIndex, i.Length - currentIndex)+ "\n";
			}
		}
		//return the fully built string
		return buildString;
	}
}
