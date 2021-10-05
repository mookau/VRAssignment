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
	public class Reversal : MonoBehaviour
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
				str = Reverse(str);
				DisplayBtnText.text = str;
            }
            );
		}
		public static string Reverse( string s )
		{
			char[] charArray = s.ToCharArray();
			Array.Reverse( charArray );
			return new string( charArray );
		}
	}
}
