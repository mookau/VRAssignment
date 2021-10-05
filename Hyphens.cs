using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Linq;
using UnityEngine.UI;
using UnityEditor;
using System.IO;
using System;

namespace SimpleUIFrame
{
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
				string str = File.ReadAllText(Mytxt); 
				//str = "12345678910";
				str = AddHyphens(str);
				DisplayBtnText.text = str;
            }
            );
		}
		public static string AddHyphens( string s )
		{
			char[] charArray = s.ToCharArray();
			//char[] arr   = new char[charArray.Length-1];
			for(int i = 12; i >= 11; i--){
				charArray[i] = charArray[i - 1];
				
			}
			charArray[12-1] = '-';
			
			return new string( charArray );
		}
	}
}
