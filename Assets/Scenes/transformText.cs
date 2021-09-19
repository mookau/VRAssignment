using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class transformText : MonoBehaviour
{
    int increment = 0;
    Text myText = null;
    private bool isRotated = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        myText = GameObject.Find("Canvas/Text1").GetComponent<Text>();//reading text file by giving path from canvas
        
        if (isRotated == false )
        {
            myText.transform.Rotate(0, 180.0f, 0);//rotates text on Y-Axis if not already rotated
            isRotated = true;
            myText.text = "Number is: " + increment.ToString();
        }

        else
        {
            myText.text = "Number is: " + increment.ToString();
        }

        increment++;

    }
}
