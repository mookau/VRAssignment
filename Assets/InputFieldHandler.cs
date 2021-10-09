using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

[RequireComponent(typeof(MouseDetection))]
public class InputFieldHandler : MonoBehaviour
{
    public MouseDetection apples;
    //public MouseDetection apples;

    private int lastLength = 0;
    private int newLength = 0;

    // Start is called before the first frame update
    void Start()
    {
        apples = GameObject.Find("UltimateView").GetComponent<MouseDetection>();
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void editString()
    {
        print("Button Press");
        string executionCode = gameObject.GetComponent<InputField>().text;

        print("Pressed Code: " + executionCode);
        
        if (executionCode.Length == 0 || int.Parse(executionCode) == 0)
        {
            gameObject.GetComponent<InputField>().text = "1";
            executionCode = "1"; }

        apples.editTextSize(executionCode);
        
    }

    public void editStringTest()
    {
        string executionCode = gameObject.GetComponent<InputField>().text;
        if (executionCode.Length == 0 || int.Parse(executionCode) == 0)
        {
            gameObject.GetComponent<InputField>().text = "1";
            executionCode = "1"; }
        apples.editTextSizeTest(executionCode);
        
    }

    public void updatedString()
    {
        print("Updating string");
        
        //List<char> tempArr = executionCode.ToCharArray();
        string executionCode = gameObject.GetComponent<InputField>().text;
        newLength = executionCode.Length;

        /*
        if (char.IsDigit(tempArr.ElementAt(tempArr.Count - 1)))
        {
            tempArr.RemoveAt(tempArr.Count - 1);
            string tempStr = new string(tempArr);
            GameObject.GetComponents<GameObject>.text = tempStr; 
        }
        else
        {  }
        */
        if (lastLength < newLength)
        {
            if (!char.IsDigit(executionCode[executionCode.Length - 1]) || newLength > 2)
            //if (!char.IsDigit(executionCode[executionCode.Length - 1]) || newLength > 2 || executionCode == "0")
            {
                char[] ch = new char[executionCode.Length - 1];

                // Copy character by character into array 
                for (int i = 0; i < executionCode.Length - 1; i++)
                {
                    ch[i] = executionCode[i];
                }

                //tempArr.RemoveAt(tempArr.Count - 1);
                string tempStr = new string(ch);
                //Text[] tempList = gameObject.GetComponentsInChildren<Text>();

                //tempList[1].text = tempStr;

                gameObject.GetComponent<InputField>().text = tempStr;
                lastLength = newLength;
                newLength = 0;
            }
            else
            { }
        }

    }

    // ----------------------------------------------------------------------------------- <>
    //  Edit the time for each question input
    //
    public void updateTimeString()
    {
        print("Updating string");

        
        string executionCode = gameObject.GetComponent<InputField>().text;
        newLength = executionCode.Length;

        if (lastLength < newLength)
        {
            if (!char.IsDigit(executionCode[executionCode.Length - 1]) || newLength > 3)
            {
                char[] ch = new char[executionCode.Length - 1];

                // Copy character by character into array 
                for (int i = 0; i < executionCode.Length - 1; i++)
                {
                    ch[i] = executionCode[i];
                }

                //tempArr.RemoveAt(tempArr.Count - 1);
                string tempStr = new string(ch);
                //Text[] tempList = gameObject.GetComponentsInChildren<Text>();

                //tempList[1].text = tempStr;

                gameObject.GetComponent<InputField>().text = tempStr;
                lastLength = newLength;
                newLength = 0;
            }
            else
            { }
        }

    }

    public void editTimeString()
    {
        
        string executionCode = gameObject.GetComponent<InputField>().text;
        
        if(executionCode.Length == 0 || int.Parse(executionCode) == 0)
        {
            gameObject.GetComponent<InputField>().text = "1";
            executionCode = "1"; }
        
        apples.setTestTime(executionCode);

    }


    // ----------------------------------------------------------------------------------- <>
    //  Edit the test effect radius input
    //  
    public void editTestRadius()
    {
        string executionCode = gameObject.GetComponent<InputField>().text;
        if (executionCode.Length == 0 || int.Parse(executionCode) == 0)
        {
            gameObject.GetComponent<InputField>().text = "1";
            executionCode = "1"; }
        apples.editTestRadius(executionCode);

    }

    public void editEffectRadius()
    {
        string executionCode = gameObject.GetComponent<InputField>().text;
        if (executionCode.Length == 0 || int.Parse(executionCode) == 0)
        {
            gameObject.GetComponent<InputField>().text = "1";
            executionCode = "1"; }
        apples.editEffectRadius(executionCode);

    }

    public void updateRadius()
    {
        print("Updating string");


        string executionCode = gameObject.GetComponent<InputField>().text;
        newLength = executionCode.Length;

        if (lastLength < newLength)
        {
            if (!char.IsDigit(executionCode[executionCode.Length - 1]) || newLength > 3)
            {
                char[] ch = new char[executionCode.Length - 1];

                // Copy character by character into array 
                for (int i = 0; i < executionCode.Length - 1; i++)
                {
                    ch[i] = executionCode[i];
                }

                //tempArr.RemoveAt(tempArr.Count - 1);
                string tempStr = new string(ch);
                //Text[] tempList = gameObject.GetComponentsInChildren<Text>();

                //tempList[1].text = tempStr;

                gameObject.GetComponent<InputField>().text = tempStr;
                lastLength = newLength;
                newLength = 0;
            }
            else
            { }
        }

    }


    // ----------------------------------------------------------------------------------- <>
    //  Edit the font of the main
    //  
    public void editTestFont()
    {
        int executionCode = gameObject.GetComponent<Dropdown>().value;

        apples.setTestFont(executionCode);

    }

    public void editEffectFont()
    {
        int executionCode = gameObject.GetComponent<Dropdown>().value;

        apples.setEffectFont(executionCode);

    }
}