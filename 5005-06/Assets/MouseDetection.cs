using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System;
using UnityEngine;
using UnityEngine.UI;

// ------------------------------------------------------------------------------------------------------------<>
// Additional Notes to consider for later
// - Lines of words need to be a box, which hold textboxes for each individual word.
//
//
//



public class MouseDetection : MonoBehaviour
{
    //Read in values from the csv file

    [Header("Load File Attributes")]
    public bool eyeDetection = false;

    //bool eyeDetection = true;
    //bool eyeDetection = false;


    public Renderer[] lChildRenderers12;
    public Transform[] lChildRenderers13;

    string startScreen = "TextEffectsExample";
    string lastScreen = "TextEffectsExample";
    string currentScreen = "TextEffectsExample";


    //string[] listOfScreensArray = { "TestScreenExample", "OptionsExample", "TextEffectsExample", "TestSettingsExample", "QuestionScreenExample", "ResultsScreenExample" };

    string[] listOfScreensArray = { "OptionsExample", "TextEffectsExample", "TestScreenExample", "TestSettingsExample", "QuestionScreenExample", "ResultsScreenExample" };
    
    int[] layerNumber = { 10, 11, 12, 13, 14, 15 };


    //-------------------------------------------------------------------------------------------------------------
    //
    //The position of the canvas and buttonson the screen
    //
    //

    //Canvas deminstion
    // X = (277.8 - 693.9)
    // Y = (345.7 - 1.4)

    //Boolean
    double[] canvasX = { 277.8D, 693.9D };
    double[] canvasY = { 1.4D, 345.7D };

    bool button1 = false;   //(3.2, 342.6, -10.0) (135.4, 266.8, -10.0)
    double[] button1X = { 3.2D, 135.4D };
    double[] button1Y = { 266.8D, 342.6D };


    bool button2 = false;   //(4.2, 259.6, -10.0) (132.3, 185.9, -10.0)
    double[] button2X = { 3.2D, 135.5D };
    double[] button2Y = { 185.9D, 259.6D };


    bool button3 = false;   //(5.2, 177.7, -10.0) (135.4, 103.9, -10.0)
    double[] button3X = { 3.2D, 135.5D };
    double[] button3Y = { 103.9D, 177.7D };

    bool button4 = false;   //(5.2, 95.7, -10.0) (133.3, 20.9, -10.0)
    double[] button4X = { 3.2D, 135.5D };
    double[] button4Y = { 20.9D, 95.7D };

    //-------------------------------------------------------------------------------------------------------------

    // Screen 1 Variables : OptionsExample

        bool endOfLineHyphensOne = false;
        bool textJustificationOne = false;
        bool textReversalOne = false;

        string fontTypeOne = "Arial";
        int fontSizeOne = 12;


    // Screen 2 Variables : TextEffectScreen

        bool riversTwo = false;
        bool whirlpoolTwo = false;
        bool glareTwo = false;
        bool overlapTwo = false;
        bool disappearTwo = false;
        bool floatingTwo = false;

        // # Will need to do paging of text here


    // Screen 3 Variables : TestScreenExample

        // # At this point no variables on this page


    // Screen 4 Variables : TestSettingsExample

        int fontSizeFour = 12;
        string fontTypeFour = "Arial";
    
        //This time is given in seconds
        int timePerQuestion = 0; 


        bool riversFour = false;
        bool whirlpoolFour = false;
        bool glareFour = false;
        bool overlapFour = false;
        bool disappearFour = false;
        bool floatingFour = false;


    // Screen 5 & 6: Test Screens, Use the same data

        List<int> questionNumberList = new List<int>();
        List<int> submittedAnswerList = new List<int>();
        List<int> actualAnswerList = new List<int>();
        List<float> secondsTakenList = new List<float>();
        List<bool> correctQuestionAnswer = new List<bool>();

    //-------------------------------------------------------------------------------------------------------------

    // Shaders

    Shader OnShaderGreen;
    Shader OffShaderRed;
    Shader DisabledButton;

    //-------------------------------------------------------------------------------------------------------------

    Renderer cubed;
    private bool cubeVis = false;

    // Start is called before the first frame update
    void Start()
    {
        print("StartStartStartStart");
        OnShaderGreen = Shader.Find("1OneButton");
        OffShaderRed = Shader.Find("1OffButton");
        DisabledButton = Shader.Find("1DISABLED Button");



        lChildRenderers12 = gameObject.GetComponentsInChildren<Renderer>();

        //invisTrial();
        //Canvas canvas[];
        //print("1");
        //Canvas[] canvas = gameObject.GetComponentsInChildren<Canvas>();
        //print("2");

        //canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        //textBox = gameObject.GetComponent<Text>();

        //RectTransform rectTransform;
        //rectTransform = textBox.GetComponentsInChildren<RectTransform>();
        //rectTransform.localPosition = new Vector3(0, 0, 0);
        //rectTransform.sizeDelta = new Vector2(600, 200);

        //Renderer[] lChildRenderers = gameObject.GetComponentsInChildren<Renderer>();
        //Component[] childCanvas = gameObject.GetComponentsInChildren(typeof(Canvas));
        //Rigidbody[] childCanvas = gameObject.GetComponentsInChildren<Rigidbody>();

        //gameObject[] lChildRenderers = gameObject.GetComponentsInChildren<gameObject>();
        //print("Len Child: " + lChildRenderers.Length);
        //print("Len Canvas: " + childCanvas.Length);

        //Text text2 = childCanvas[0].AddComponent<Text>();
        //text2.setText("Apple");

        //foreach (gameObject x in lChildRenderers)
        /*
        foreach (Renderer x in lChildRenderers)
        {
            print(x.name);
            if ((x.name).Equals("Cube"))
            {
                cubed = x;
                print("Added Cube");

            }

        }
        */
        //print("- - - - - - - - - - - -");
        //foreach (Component x in childCanvas)
        //{
        //    print(x);
        //}

        //clearAll(false);

        //superHandler();
        clearAllVersionTwo();
        //loadSpecificScreenVersionTwo(startScreen);
        //clearAllVersionTwo();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 worldPosition;
        if (eyeDetection)
        {
            if (cubeVis == false)
            { cubed.enabled = true; cubeVis = true; }

            worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //cubed.transform.position = new Vector3(worldPosition.x, worldPosition.y, (float)(worldPosition.z));
            cubed.transform.position = new Vector3(worldPosition.x, worldPosition.y, (float)(worldPosition.z * 0 - 1));

        }
        else
        {
            if (cubeVis == true)
            { cubed.enabled = false; cubeVis = false; }

            worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);


            //
            //Check to see if over the text canvas
            //
            //
            if ((worldPosition.x >= canvasX[0] && worldPosition.x <= canvasX[1]) && (worldPosition.y >= canvasY[0] && worldPosition.y <= canvasY[1]))
            {
                print("Over Canvas");
                //if (Input.GetMouseButtonDown(0))
                //{
                //print("Thing");
                //}



            }



            //
            //Here is the check to see if the buttons are pressed
            //
            //
            //Button 1
            if ((worldPosition.x >= button1X[0] && worldPosition.x <= button1X[1]) && (worldPosition.y >= button1Y[0] && worldPosition.y <= button1Y[1]))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    button1 = !button1;
                    print("Button 1: " + (button1).ToString());
                    //Function A
                }
            }
            //Button 2
            else if ((worldPosition.x >= button2X[0] && worldPosition.x <= button2X[1]) && (worldPosition.y >= button2Y[0] && worldPosition.y <= button2Y[1]))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    button2 = !button2;
                    print("Button 2: " + (button2).ToString());
                }
            }
            //Button 3
            else if ((worldPosition.x >= button3X[0] && worldPosition.x <= button3X[1]) && (worldPosition.y >= button3Y[0] && worldPosition.y <= button3Y[1]))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    button3 = !button3;
                    print("Button 3: " + (button3).ToString());
                }
            }
            //Button 4
            else if ((worldPosition.x >= button4X[0] && worldPosition.x <= button4X[1]) && (worldPosition.y >= button4Y[0] && worldPosition.y <= button4Y[1]))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    button4 = !button4;
                    print("Button 4: " + (button4).ToString());
                }
            }

        }
        //
        //Get the mouse position clause
        //
        /*
        if (Input.GetMouseButton(0))
        {
            //break;
            //print("Thing");

            print(worldPosition);
            
            //textBox.text = "Forgive me, my Lady... I swore an oath, but I have failed you... ... Lady Elfriede...";
        }
        */
    }


    void carryoutVisualUpdate(Vector3 mousePosition)
    {





    }


    // ----------------------------------------------------------------------------------------------------<>


    //Function A
    public void carryOutButtonFunction(string ExecutionCode)
    {
        print("Inside the mouseDetection code: Execution Code ==> " + ExecutionCode);

        int determinedValue = -1;
        int valueEnable = -1;
        bool contin = false;

        if (ExecutionCode.Equals("ResultsBack"))
        {
            //valueEnable = 3;
            valueEnable = 1;
        }
        if (ExecutionCode.Equals("TestResult"))
        {
            //valueEnable = 6;
            valueEnable = 2;
        }
        if (ExecutionCode.Equals("ResultsRetest"))
        {
            //valueEnable = 5;
            valueEnable = 3;
        }


        Renderer[] lChildRenderers = gameObject.GetComponentsInChildren<Renderer>();


        //lChildRenderers[1].enabled = true;
        foreach (Renderer x in lChildRenderers)
        {
            x.enabled = false;
            //if(x.name.Equals("Text"))
            if (x.name.Contains("Text"))
            {
                x.gameObject.SetActive(false);

            }
        }

        if (ExecutionCode.Equals("Apple"))
        {
            return;
        }

        foreach (Renderer x in lChildRenderers)
        {
            if (x.name.Contains("Text"))
            {
                print("Text");
            }

            if (x.name.Contains("FinalSphere") && !contin)
            {
                determinedValue += 1;
                if (determinedValue == valueEnable)
                {
                    print("Made True");
                    contin = true;
                }

                if (determinedValue == valueEnable)
                {
                    //contin = true;
                    print("Equal");
                    x.enabled = true;
                    if (x.name.Contains("Text"))
                    {
                        x.gameObject.SetActive(true);
                        print("Set True");
                    }

                }
            }
            //if (determinedValue == valueEnable)
            else
            {
                //contin = true;
                print("Equal");
                x.enabled = true;
                if (x.name.Contains("Text"))
                {
                    x.gameObject.SetActive(true);
                    print("----> Set True");
                }

                if (x.name.Contains("FinalSphere"))
                {
                    determinedValue += 1;
                    contin = false;
                }

            }


        }

        //lChildRenderers[1].enabled = false;

    }


    // Function B

    public void invisTrial()
    {
        //lChildRenderers12 = GameObject.Find("TestScreenExample").GetComponentsInChildren<Renderer>();
        //lChildRenderers12 = GameObject.Find("OptionsExample").GetComponentsInChildren<Renderer>();
        //lChildRenderers12 = GameObject.Find("TextEffectsExamples").GetComponentsInChildren<Renderer>();
        //lChildRenderers12 = GameObject.Find("TestSettingsExample").GetComponentsInChildren<Renderer>();
        //lChildRenderers12 = GameObject.Find("QuestionScreenExample").GetComponentsInChildren<Renderer>();
        lChildRenderers12 = GameObject.Find("ResultsScreenExample").GetComponentsInChildren<Renderer>();
        print("###################");
        foreach (Renderer x in lChildRenderers12)
        {
            x.enabled = false;
            print(x.name);
            //if(x.name.Equals("Text"))
            if (x.name.Contains("Text"))
            {
                x.gameObject.SetActive(false);


            }
        }
    }

    public void loadSpecificScreen(string screenName)
    {
        //Potential Screens
        // - TestScreenExample
        // - OptionsExample
        // - TextEffectsExamples
        // - TestSettingsExample
        // - QuestionScreenExample
        // - ResultsScreenExample





        //Remove lastScreen
        print("Removing");
        elementalDisplay(lastScreen, false);

        //Show New Screen
        print("Showing");
        elementalDisplay(screenName, true);


        lastScreen = currentScreen;
        currentScreen = screenName;
    }


    public void elementalDisplay(string screenName, bool boolValue)
    {
        print("Searching for: " + screenName);
        lChildRenderers12 = GameObject.Find(screenName).GetComponentsInChildren<Renderer>();
        print("Found Gameobject");
        print("$$$$$$$$$$$$$");
        foreach (Renderer x in lChildRenderers12)
        {
            print(x.name);
            x.enabled = boolValue;
            if (x.name.Contains("Text"))
            {
                x.gameObject.SetActive(boolValue);
            }
        }
    
        //Do the elementCheck values
    }

    //---------------
    /*
    public void elementalDisplay2(string screenName, bool boolValue)
    {
        print("Searching for: " + screenName);
        lChildRenderers13 = GameObject.Find(screenName).GetComponentsInChildren<Transform>();
        print("Found Gameobject");
        print("$$$$$$$$$$$$$");
        foreach (Transform x in lChildRenderers13)
        {
            print(x.name);
            x.gameObject.SetActive(boolValue);
            if (x.name.Contains("Text"))
            {
                x.gameObject.SetActive(boolValue);
            }
        }

        //Do the elementCheck values
    }


    */
    public void clearAll(bool boolValue)
    {
        foreach (string x in listOfScreensArray)
        {
            
            if (!x.Equals(startScreen))
            {
                elementalDisplay(x, false);
            }
            print("()()()()");
        }
    }


    void screenShiftHandler(string screenName)
    {
        foreach (string x in listOfScreensArray)
        {
            if (screenName.Equals(x))
            {
                print("Inside Handler");
                loadSpecificScreen(x);
            }
        }
    }


    void superHandler()
    {
        print("Current GameObject: " + gameObject.name);
        //Transform[] lChildRenderers7 = GameObject.GetComponents<Transform>();
        //Transform[] lChildRenderers2 = GameObject.Find("TextEffectsExamples").GetComponentsInChildren<Transform>();

        Transform[] lChildRenderers2 = GameObject.Find("UltimateView").GetComponentsInChildren<Transform>(true);

        //Transform[] lChildRenderers2 = gameObject.GetComponents<Transform>(true);
        print(lChildRenderers2.Length);
        print("EAST WAYS");
        try
        {

            foreach (Transform x in lChildRenderers2)
            {
                //print(x.gameObject.layer);
                print(x.name);

                x.gameObject.SetActive(false);

                //x.gameSetActive(false);
                //print("- " + x.gameObject.name);
                //x.gameObject.SetActive(false);
            }
            gameObject.SetActive(true);
            foreach (Transform x in lChildRenderers2)
            {
                //print(x.gameObject.layer);
                print(x.name);
                print(x.gameObject.layer);
                if (x.gameObject.layer == 10)
                {
                    x.gameObject.SetActive(true);
                }
                //x.gameSetActive(false);
                //print("- " + x.gameObject.name);
                //x.gameObject.SetActive(false);
            }
        }
        catch(Exception ex)
        { }
        /*
        foreach (Transform x in lChildRenderers2)
        {
            //print(x.gameObject.layer);
            print(x.name);
            x.gameObject.SetActive(true);
            //x.gameSetActive(false);
            //print("- " + x.gameObject.name);
            //x.gameObject.SetActive(false);
        }
        //Trn myObject2 = lChildRenderers2[0].child;
        //print(myObject2)
        */
    }


    // Button Press Handler
    // Button Press Handler
    // Button Press Handler
    // Button Press Handler
    // Button Press Handler
    // Button Press Handler
    // Button Press Handler
    // Button Press Handler




    //Button Handler
    public void buttonPressedHandler(string executionCode)
    {
        //print("Input Length: " + executionCode.Length);

        string commandCode = executionCode.Substring(0, 4);
        //print("Code: " + commandCode);


        int lengthDummy = executionCode.Length - 4;
        //print("Execution Code: " + executionCode);
        string content = executionCode.Substring(4, lengthDummy);
        //print("Content: " + content);

        //If you want to shift between Screens
        if (commandCode.Equals("%***"))
        {
            //print("Inside");
            //screenShiftHandler(content);
            screenShiftHandlerVersionTwo(content);
        }

        if (commandCode.Equals("*%**"))
        {
            //print("Inside");
            //screenShiftHandler(content);
            boolButtonHandler(content);
        }
    }


    //#########################


    public void loadSpecificScreenVersionTwo(string screenName)
    {
        //Potential Screens
        // - TestScreenExample
        // - OptionsExample
        // - TextEffectsExample
        // - TestSettingsExample
        // - QuestionScreenExample
        // - ResultsScreenExample

        //Remove lastScreen
        print("Removing");
        print("lastScreen: " + currentScreen);
        elementalDisplayVersionTwo(currentScreen, false);
        //clearAllVersionTwo();


        //Show New Screen
        print("Showing");
        print("ScreenName: " + screenName);
        elementalDisplayVersionTwo(screenName, true);


        lastScreen = currentScreen;
        currentScreen = screenName;

        print("------------------");
        print("lastScreen: " + lastScreen) ;
        print("CurrentScreen: " + currentScreen);
        

    }


    public void elementalDisplayVersionTwo(string screenName, bool boolValue)
    {
        Transform[] lChildRenderers2 = GameObject.Find("UltimateView").GetComponentsInChildren<Transform>(true);

        int counterz = 9;
        foreach (string x in listOfScreensArray)
        {
            print("..........");
            print(x + "(");
            print(screenName + "(");
            print(x.Equals(screenName));

            if (x.Equals(screenName))
            { counterz += 1; break; }
            counterz += 1;
        }
        print("Layer: " + counterz);
        try
        {

            gameObject.SetActive(true);
            foreach (Transform x in lChildRenderers2)
            {
                //print(x.gameObject.layer);
                //print(x.name);
                //print(x.gameObject.layer);
                if (x.gameObject.layer == counterz)
                {
                    x.gameObject.SetActive(boolValue);
                }
                
            }
            gameObject.SetActive(true);
        }
        catch (Exception ex)
        { }

        //Do the elementCheck values
    }

   
    public void clearAllVersionTwo()
    {
        foreach (string x in listOfScreensArray)
        {

            if (!x.Equals(startScreen))
            {
                elementalDisplayVersionTwo(x, false);
            }
            print("()()()()");
        }
    }


    void screenShiftHandlerVersionTwo(string screenName)
    {
        foreach (string x in listOfScreensArray)
        {
            if (screenName.Equals(x))
            {
                print("Inside Handler");
                loadSpecificScreenVersionTwo(x);
            }
        }
    }




    void boolButtonHandler(string content)
    {
        string[] listOfContents = content.Split('.');
        int buttonNumber = int.Parse(listOfContents[1]);
        int changeVal = int.Parse(listOfContents[2]);

        print(listOfContents[0]);
        print(buttonNumber);
        print(changeVal);

        //If OptionsExample
        if(listOfContents[0].Equals(listOfScreensArray[0]))
        {
            optionsExampleButtonHandler(buttonNumber, changeVal, "");
        }

        //If OptionsExample
        else if (listOfContents[0].Equals(listOfScreensArray[1]))
        {
            textEffectsExampleButtonHandler(buttonNumber, changeVal, "");
        }

        else if (listOfContents[0].Equals(listOfScreensArray[2]))
        {
            //textEffectsExampleButtonHandler(buttonNumber, changeVal, "");
        }

        else if (listOfContents[0].Equals(listOfScreensArray[3]))
        {
           testSettingsExampleButtonHandler(buttonNumber, changeVal, "");
        }
    }


    void optionsExampleButtonHandler(int buttonNumber, int changeVal, string fontName)
    { 
        if(buttonNumber == 0)
        { 
            //Change the button Value
            if (changeVal == 0)
            { endOfLineHyphensOne = false; }
            if (changeVal == 1)
            { endOfLineHyphensOne = true; }
            if (changeVal == 2)
            { endOfLineHyphensOne = !endOfLineHyphensOne; }

            print("Set endOfLineHyphensOne to: " + endOfLineHyphensOne);

            /*
            //Change the appearance of the buttons
            if (endOfLineHyphensOne)
            {
                GameObject.Find("0.0.0").renderer.material.shader = OnShaderGreen;
                GameObject.Find("0.0.1").renderer.material.shader = DisabledButton;
            }
            else 
            {
                GameObject.Find("0.0.0").renderer.material.shader = DisabledButton;
                GameObject.Find("0.0.1").renderer.material.shader = OnShaderGreen;
            }
            */
        }
        else if (buttonNumber == 1)
        {
            //Change button value 
            if (changeVal == 0)
            { textJustificationOne = false; }
            if (changeVal == 1)
            { textJustificationOne = true; }
            if (changeVal == 2)
            { textJustificationOne = !textJustificationOne; }

            print("Set textJustificationOne to: " + textJustificationOne);

            //Change the appearance of the buttons

        }
        else if (buttonNumber == 2)
        {
            //Change button value 
            if (changeVal == 0)
            { textReversalOne = false; }
            if (changeVal == 1)
            { textReversalOne = true; }
            if (changeVal == 2)
            { textReversalOne = !textReversalOne; }

            print("Set textReversalOne to: " + textReversalOne);

            //Change the appearance of the buttons

        }
        else if (buttonNumber == 3)
        { }
        else if (buttonNumber == 4)
        { }
    }


    // *%**TextEffectsExample.00.02
    /*
        bool riversTwo = false;
        bool whirlpoolTwo = false;
        bool glareTwo = false;
        bool overlapTwo = false;
        bool disappearTwo = false;
        bool floatingTwo = false;

    */
    void textEffectsExampleButtonHandler(int buttonNumber, int changeVal, string fontName)
    {
        if (buttonNumber == 0)
        {
            //Change the button Value
            if (changeVal == 0)
            { riversTwo = false; }
            if (changeVal == 1)
            { riversTwo = true; }
            if (changeVal == 2)
            { riversTwo = !riversTwo; }

            print("Set riversTwo to: " + riversTwo);

            /*
            //Change the appearance of the buttons
            if (endOfLineHyphensOne)
            {
                GameObject.Find("0.0.0").renderer.material.shader = OnShaderGreen;
                GameObject.Find("0.0.1").renderer.material.shader = DisabledButton;
            }
            else 
            {
                GameObject.Find("0.0.0").renderer.material.shader = DisabledButton;
                GameObject.Find("0.0.1").renderer.material.shader = OnShaderGreen;
            }
            */
        }
        else if (buttonNumber == 1)
        {
            //Change button value 
            if (changeVal == 0)
            { whirlpoolTwo = false; }
            if (changeVal == 1)
            { whirlpoolTwo = true; }
            if (changeVal == 2)
            { whirlpoolTwo = !whirlpoolTwo; }

            print("Set whirlpoolTwo to: " + whirlpoolTwo);

            //Change the appearance of the buttons

        }
        else if (buttonNumber == 2)
        {
            //Change button value 
            if (changeVal == 0)
            { glareTwo = false; }
            if (changeVal == 1)
            { glareTwo = true; }
            if (changeVal == 2)
            { glareTwo = !glareTwo; }

            print("Set glareTwo to: " + glareTwo);

            //Change the appearance of the buttons

        }
        else if (buttonNumber == 3)
        {
            //Change button value 
            if (changeVal == 0)
            { overlapTwo = false; }
            if (changeVal == 1)
            { overlapTwo = true; }
            if (changeVal == 2)
            { overlapTwo = !overlapTwo; }

            print("Set overlapTwo to: " + overlapTwo);

            //Change the appearance of the buttons

        }
        else if (buttonNumber == 4)
        {
            //Change button value 
            if (changeVal == 0)
            { disappearTwo = false; }
            if (changeVal == 1)
            { disappearTwo = true; }
            if (changeVal == 2)
            { disappearTwo = !disappearTwo; }

            print("Set disappearTwo to: " + disappearTwo);

            //Change the appearance of the buttons
        }
        else if (buttonNumber == 5)
        {
            //Change button value 
            if (changeVal == 0)
            { floatingTwo = false; }
            if (changeVal == 1)
            { floatingTwo = true; }
            if (changeVal == 2)
            { floatingTwo = !floatingTwo; }

            print("Set disappearTwo to: " + floatingTwo);

            //Change the appearance of the buttons
        }

    }



    /*
        bool riversFour = false;
        bool whirlpoolFour = false;
        bool glareFour = false;
        bool overlapFour = false;
        bool disappearFour = false;
        bool floatingFour = false;
     */
    void testSettingsExampleButtonHandler(int buttonNumber, int changeVal, string fontName)
    {
        if (buttonNumber == 4)
        {
            //Change the button Value
            if (changeVal == 0)
            { riversFour = false; }
            if (changeVal == 1)
            { riversFour = true; }
            if (changeVal == 2)
            { riversFour = !riversFour; }

            print("Set riversFour to: " + riversFour);

            /*
            //Change the appearance of the buttons
            if (endOfLineHyphensOne)
            {
                GameObject.Find("0.0.0").renderer.material.shader = OnShaderGreen;
                GameObject.Find("0.0.1").renderer.material.shader = DisabledButton;
            }
            else 
            {
                GameObject.Find("0.0.0").renderer.material.shader = DisabledButton;
                GameObject.Find("0.0.1").renderer.material.shader = OnShaderGreen;
            }
            */
        }
        else if (buttonNumber == 5)
        {
            //Change button value 
            if (changeVal == 0)
            { whirlpoolFour = false; }
            if (changeVal == 1)
            { whirlpoolFour = true; }
            if (changeVal == 2)
            { whirlpoolFour = !whirlpoolFour; }

            print("Set whirlpoolFour to: " + whirlpoolFour);

            //Change the appearance of the buttons

        }
        else if (buttonNumber == 6)
        {
            //Change button value 
            if (changeVal == 0)
            { glareFour = false; }
            if (changeVal == 1)
            { glareFour = true; }
            if (changeVal == 2)
            { glareFour = !glareFour; }

            print("Set glareFour to: " + glareFour);

            //Change the appearance of the buttons

        }
        else if (buttonNumber == 7)
        {
            //Change button value 
            if (changeVal == 0)
            { overlapFour = false; }
            if (changeVal == 1)
            { overlapFour = true; }
            if (changeVal == 2)
            { overlapFour = !overlapFour; }

            print("Set overlapFour to: " + overlapFour);

            //Change the appearance of the buttons

        }
        else if (buttonNumber == 8)
        {
            //Change button value 
            if (changeVal == 0)
            { disappearFour = false; }
            if (changeVal == 1)
            { disappearFour = true; }
            if (changeVal == 2)
            { disappearFour = !disappearFour; }

            print("Set disappearFour to: " + disappearFour);

            //Change the appearance of the buttons
        }
        else if (buttonNumber == 9)
        {
            //Change button value 
            if (changeVal == 0)
            { floatingFour = false; }
            if (changeVal == 1)
            { floatingFour = true; }
            if (changeVal == 2)
            { floatingFour = !floatingFour; }

            print("Set floatingFour to: " + floatingFour);

            //Change the appearance of the buttons
        }

    }
}

