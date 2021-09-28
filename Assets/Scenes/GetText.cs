using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;

public class GetText : MonoBehaviour
{
    public Transform contentWindow;
    public GameObject recallTextObject;

    public static bool isNumeric(string s)
    {
        return int.TryParse(s, out int n);
    }

    // Start is called before the first frame update
    void Start()
    {
        string readFromFilePath = Application.streamingAssetsPath + "/Recall_Chat/" + "Chat" + ".txt";

        List<string> fileLines = File.ReadAllLines(readFromFilePath).ToList();

        foreach (string line in fileLines)
        {
            string[] words = line.Split();
            int lengthOf = words.Length;
            for (int a = 0; a < lengthOf; a++)
            {
                if (isNumeric(words[a]))
                {
                    Instantiate(recallTextObject, contentWindow);
                    recallTextObject.GetComponent<Text>().text = words[a];

                    recallTextObject.transform.Rotate(0, 180.0f, 0);
                }
                else
                {
                    Instantiate(recallTextObject, contentWindow);
                    recallTextObject.GetComponent<Text>().text = words[a];
                    //recallTextObject.transform.Rotate(0, 180.0f, 0);
                }

            }
            /*Instantiate(recallTextObject, contentWindow);
            recallTextObject.GetComponent<Text>().text = line;*/
        }

    }

    // Update is called once per frame
    /*void Update()
    {
        
    }*/
}
