using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Text;

public class writeinfile : MonoBehaviour
{
    //private GameObject buttonObj;
    // Use this for initialization
    void Start()
    {
        Button btn = this.GetComponent<Button> ();
        btn.onClick.AddListener (OnClick);
    }

    // Update is called once per frame
    private void OnClick(){
		
		Debug.Log ("Button Clicked. ClickHandler.");
		string path = "C:\\Users\\Luo\\Desktop\\result.txt";
        StreamWriter sw;
        FileInfo fi = new FileInfo(path);

        if (!File.Exists(path))
        {
            sw = fi.CreateText();
			//sw.WriteLine("logs");
        }
        else {
            sw = fi.AppendText();
			//sw.WriteLine("\nlogs");			
        }
        sw.WriteLine("logs");
        sw.Close();
        sw.Dispose();
	}
}