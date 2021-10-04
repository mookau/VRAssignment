using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System;
using System.IO;
using System.Timers;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Globalization;

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

    // ------------------------------------------------------------------------------
    // Load in the load file




    //Load in the question file

    List<formatQuestion> listQuestionStorage;
    formatQuestion[] questionStorage = { };
    //loadJSON();

    // ------------------------------------------------------------------------------


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

    // Font types here
    List<string> listOfFonts = new List<string> { "Alpha", "Bravo", "Charlie"};

    Dropdown testDropdown;
    Dropdown effectDropdown;

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

    float effectRadius = 1;
    float testRadius = 1;

    // # Will need to do paging of text here


    // Screen 3 Variables : TestScreenExample

    bool loadedTestStatement = false;


    // Screen 4 Variables : TestSettingsExample

    //private static System.Timers.Timer aTimer;


    int fontSizeFour = 12;
    string fontTypeFour = "Arial";

    //This time is given in seconds
    float timePerQuestion = 120;
    string timePerQuestionString = "120";
    


    bool riversFour = false;
    bool whirlpoolFour = false;
    bool glareFour = false;
    bool overlapFour = false;
    bool disappearFour = false;
    bool floatingFour = false;



    public Text timerText;
    public Text questionSpace;
    public Text question1Text;
    public Text question2Text;
    public Text question3Text;
    public Text question4Text;


    // Screen 5 & 6: Test Screens, Use the same data

    List<int> questionNumberList = new List<int>();
    List<int> submittedAnswerList = new List<int>();
    List<int> actualAnswerList = new List<int>();
    List<float> secondsTakenList = new List<float>();
    List<bool> correctQuestionAnswer = new List<bool>();



    bool inTestMode = false;
    bool timerOn = false;

    float timeLeft = 0;

    bool buttonPressedTest = false;


    // Here are the lists of answers and what not
    List<string> providedAnswers = new List<string>();
    List<string> actualAnswers = new List<string>();
    List<float> timeTakenToAnswer = new List<float>();

    int questionCounter = 0;
    string providedAnswerTemp = "-";
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
        //Load in the Load Files here


        //Load in the questions for the test mode
        loadJSON();



        // --------

        // Allocate Dropdowns

        testDropdown = GameObject.Find("TestDropdown").GetComponent<Dropdown>();
        effectDropdown = GameObject.Find("EffectDropdown").GetComponent<Dropdown>();

        setDropdown("Test");
        setDropdown("Else");

        // --------

        print("StartStartStartStart");
        OnShaderGreen = Shader.Find("1OneButton");
        OffShaderRed = Shader.Find("1OffButton");
        DisabledButton = Shader.Find("1DISABLED Button");

        // --------


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


        timerText = GameObject.Find("TimerText").GetComponent<Text>();
        questionSpace = GameObject.Find("QuestionStatementText").GetComponent<Text>();
        question1Text = GameObject.Find("AAnswerText").GetComponent<Text>();
        question2Text = GameObject.Find("BAnswerText").GetComponent<Text>();
        question3Text = GameObject.Find("CAnswerText").GetComponent<Text>();
        question4Text = GameObject.Find("DAnswerText").GetComponent<Text>();







        //superHandler();
        clearAllVersionTwo();
        //loadSpecificScreenVersionTwo(startScreen);
        //clearAllVersionTwo();
    }

    // Update is called once per frame
    void Update()
    {
        if(inTestMode)
        {
            if(!timerOn)
            {
                if (questionCounter < listQuestionStorage.Count)
                {
                    print("5555" + !timerOn);
                    timeLeft = timePerQuestion * 1;
                    timerOn = true;
                    displayTime(timeLeft);
                    editQuestionText();
                }
                else 
                {
                    inTestMode = false;
                    timerOn = false;
                
                }
                //aTimer = new System.Timers.Timer(timePerQuestion * 1000);
                //aTimer.Interval = 1000;
                //Set the timer box to the timer value
               
                //aTimer.Enabled = true;
            }
            else {
                // if button pressed
                if (buttonPressedTest)
                {
                    print("444");
                    buttonPressedTest = false;

                    //Add the results to the list
                    addDataToLists();
                    print("Added DATA to list");

                    if (questionCounter < listQuestionStorage.Count)
                    {
                        print("333");
                        editQuestionText();
                        timeLeft = timePerQuestion * 1;
                        displayTime(timeLeft);
                        print("33");
                    }
                    else
                    {
                        print("222");
                        saveJSON();
                        screenShiftHandlerVersionTwo("ResultsScreenExample");
                        print("22");
                        inTestMode = false;
                        timerOn = false;
                        providedAnswerTemp = "-";
                        providedAnswers.Clear();
                        actualAnswers.Clear();
                        timeTakenToAnswer.Clear();
                        questionCounter = 0;
                    }

                }
                else if (timeLeft > 0)
                {
                    timeLeft -= Time.deltaTime;
                    displayTime(timeLeft);

                }
                else 
                {
                    print("11111");
                    timeLeft = 0;
                    

                    //Add the results to the list
                    addDataToLists();
                    print("Added DATA to list");
                    //Load the new question, if there is one
                    if (questionCounter < listQuestionStorage.Count)
                    {
                        print("1111");
                        editQuestionText();
                        timeLeft = timePerQuestion * 1;
                        displayTime(timeLeft);
                    }
                    else
                    {
                        print("111");
                        saveJSON();
                        screenShiftHandlerVersionTwo("ResultsScreenExample");
                        timerOn = false;
                        inTestMode = false;
                        print("11");
                        providedAnswerTemp = "-";
                        providedAnswers.Clear();
                        actualAnswers.Clear();
                        timeTakenToAnswer.Clear();
                        questionCounter = 0;
                    }
                }
            }




        }
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
        catch (Exception ex)
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
        //If starting a test
        if(commandCode.Equals("**%*"))
        {
            inTestMode = true;
            screenShiftHandlerVersionTwo(content);
        }

        //If submitting an answer
        if (commandCode.Equals("***%"))
        {
            if (timeLeft / timePerQuestion < 0.99)
            {
                if (content.Equals("Surrender"))
                {

                    providedAnswerTemp = "S";
                    //screenShiftHandlerVersionTwo(content);

                }
            
                buttonPressedTest = true;
            }
        }

        //If exiting the test
        if (commandCode.Equals("%%**"))
        {
            buttonPressedTest = false;
            inTestMode = false;
            timerOn = false;
            timeLeft = 0;
            providedAnswers.Clear();
            actualAnswers.Clear();
            timeTakenToAnswer.Clear();
            questionCounter = 0;
            providedAnswerTemp = "-";

            screenShiftHandlerVersionTwo(content);
        }

        if (commandCode.Equals("%*%*"))
        {
            providedAnswerTemp = content;
        }


        if (commandCode.Equals("%%%%"))
        {
            Application.Quit();
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
        updateText(screenName);
        if(screenName.Equals("ResultsScreenExample"))
        {
            string[] apples = { "a", "b" };
            createTableRow(apples);

        }

        lastScreen = currentScreen;
        currentScreen = screenName;

        print("------------------");
        print("lastScreen: " + lastScreen);
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
        if (listOfContents[0].Equals(listOfScreensArray[0]))
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
        if (buttonNumber == 0)
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

    void editQuestionText()
    {
        //QuestionNumberText
        Text tempQuestion = GameObject.Find("QuestionNumberText").GetComponent<Text>();

        tempQuestion.text = "Question : " + (questionCounter + 1).ToString() + " / " + (listQuestionStorage.Count).ToString();



        formatQuestion tempQuestionHold = listQuestionStorage.ElementAt(questionCounter);
        questionSpace.text = tempQuestionHold.question;
        question1Text.text = tempQuestionHold.answerList.ElementAt(0);
        question2Text.text = tempQuestionHold.answerList.ElementAt(1);
        question3Text.text = tempQuestionHold.answerList.ElementAt(2);
        question4Text.text = tempQuestionHold.answerList.ElementAt(3);
        //questionCounter += 1;

    }

    void displayTime(float timeRemain)
    {
        if(timeRemain < 0)
        {
            timeRemain = 0;
            //timerOn = false;
        }

        float minutes = Mathf.FloorToInt(timeRemain / 60);
        float seconds = Mathf.FloorToInt(timeRemain % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }


    void addDataToLists()
    {
        print("Added Line to save");

        providedAnswers.Add(providedAnswerTemp);
        actualAnswers.Add(listQuestionStorage.ElementAt(questionCounter).answerNumber);
        timeTakenToAnswer.Add(timePerQuestion - timeLeft);

        providedAnswerTemp = "-";
        timeLeft = timePerQuestion * 1;
        //Iterate to next question
        questionCounter += 1;

    }

    //////////////////////////////////////////////////////////////////////////////////////////////////
    /// Creating the results table
    
    void createTable()
    {



    }


    void setTableValues()
    {
        // providedAnswers =
        // actualAnswers =
        // timeTakenToAnswer =


    }

    //////////////////////////////////////////////////////////////////////////////////////////////////
    ///Classes///

    class formatQuestion
    {
        //(string question, string[] answerlist, string answerNumber)
         public string question = "";

        //string[] answerList = { };
        public List<string> answerList;

        public string answerNumber = "";

        //public string returnQuestion { get => question; set => question = value; }

        //public string[] returnAnswerList { get => answerList; set => answerList = value; }
        //public List<string> returnAnswerList { get => answerList; set => answerList = value; }

        //public string returnAnswer { get => answerNumber; set => answerNumber = value; }

    }

    public void loadJSON()
    {
        print(Directory.GetCurrentDirectory() + "\\PUT_LOAD_FILES_HERE!!!!\\questionTxt.JSON");
        print(Directory.GetCurrentDirectory());
        using (StreamReader r = new StreamReader(Directory.GetCurrentDirectory() +"\\PUT_LOAD_FILES_HERE!!!!\\questionTxt.JSON"))
        {
            string json = r.ReadToEnd();
            listQuestionStorage = JsonConvert.DeserializeObject<List<formatQuestion>>(json);
            
        }
        print("NUmbers: " + listQuestionStorage.Count);




        
        foreach (formatQuestion x in listQuestionStorage)
        {

            print("OOF: " + x.question);
            print("AAA: " + x.answerList);
            print("BBB: " + x.answerNumber);


        }


    }


    public void saveJSON()
    {

        int x = 0;
        while( x < providedAnswers.Count)
        {

            print(" " + providedAnswers.ElementAt(x) + " | " + actualAnswers.ElementAt(x) + " | " + (double.Parse(timeTakenToAnswer.ElementAt(x).ToString())) + " | ");


            x += 1;
        }



    }

    // ----------------------------------------------------------------------------------- <>
    //  Edit text on the upload of the screen
    //
    public void updateText(string screenName)
    {
        // "OptionsExample", "TextEffectsExample", "TestScreenExample", "TestSettingsExample", "QuestionScreenExample", "ResultsScreenExample"

        if (screenName.Equals("OptionsExample"))
        {
            GameObject.Find("OptionsTrialText").GetComponent<Text>().fontSize = fontSizeOne;
            GameObject.Find("OptionsTestText").GetComponent<Text>().fontSize = fontSizeOne;
            
            GameObject.Find("EffectSizeInputField").GetComponent<InputField>().text = fontSizeOne.ToString();
            GameObject.Find("EffectRadiusInputField").GetComponent<InputField>().text = effectRadius.ToString();

            //GameObject.Find("OptionsTrialText").GetComponent<Text>().fontStyle = = Null;
            //GameObject.Find("OptionsTestText").GetComponent<Text>().fontStyle = Null;
        }
        else if (screenName.Equals("TextEffectsExample"))
        {
            GameObject.Find("EffectsTrialText").GetComponent<Text>().fontSize = fontSizeOne;
            GameObject.Find("EffectsTestText").GetComponent<Text>().fontSize = fontSizeOne;

            //GameObject.Find("EffectsTrialText").GetComponent<Text>().fontStyle = = Null;
            //GameObject.Find("EffectsTestText").GetComponent<Text>().fontStyle = Null;
        }
        else if (screenName.Equals("TestScreenExample"))
        {
            if (!loadedTestStatement)
            { }

        }
        else if (screenName.Equals("TestSettingsExample"))
        {
            print("Updating the test settings");
            GameObject.Find("TestSettingsTrialText").GetComponent<Text>().fontSize = fontSizeFour;
            GameObject.Find("TestSettingsTestText").GetComponent<Text>().fontSize = fontSizeFour;
            GameObject.Find("TimeAmountInputField").GetComponent<InputField>().text = timePerQuestionString;
            GameObject.Find("FontSizeInputField").GetComponent<InputField>().text = fontSizeFour.ToString();
            GameObject.Find("RadiusInputField").GetComponent<InputField>().text = testRadius.ToString();

        }
        else if (screenName.Equals("QuestionScreenExample"))
        {
            GameObject.Find("QuestionStatementText").GetComponent<Text>().fontSize = fontSizeFour;
            //GameObject.Find("QuestionStatementText").GetComponent<Text>().fontStyle = fontTypeFour;

        }
        else if (screenName.Equals("ResultsScreenExample"))
        { }

    }

    // ----------------------------------------------------------------------------------- <>
    //  Edit the text size of the effect screen
    //
    public void editTextSize(string fontSize)
    {
        /*
        Text[] listText = gameObject.GetComponentsInChildren<Text>().Find("TrialText");

        foreach (Text eachText in listText)
        {
            eachText.fontSize = int.Parse(fontSize);
        }
          
        */
        fontSizeOne = int.Parse(fontSize);
        GameObject.Find("OptionsTrialText").GetComponent<Text>().fontSize = fontSizeOne;
        GameObject.Find("OptionsTestText").GetComponent<Text>().fontSize = fontSizeOne;
        //GameObject.Find("EffectsTrialText").GetComponent<Text>().fontSize = effectFontSize;
        //GameObject.Find("EffectsTestText").GetComponent<Text>().fontSize = effectFontSize;
    }


    // ----------------------------------------------------------------------------------- <>
    //  Edit the text size of the test screen
    //  Edit the test time per question for test screen

    public void editTextSizeTest(string fontSize)
    {
        fontSizeFour = int.Parse(fontSize);
        GameObject.Find("TestSettingsTrialText").GetComponent<Text>().fontSize = fontSizeFour;
        GameObject.Find("TestSettingsTestText").GetComponent<Text>().fontSize = fontSizeFour;
    }

    public void setTestTime(string time)
    {
        timePerQuestion = float.Parse(time);
        timePerQuestionString = time;

    }

   
    // ----------------------------------------------------------------------------------- <>
    //  Set the radius values of effects
    //
    public void editTestRadius(string fontSize)
    {
        float radiusSize = float.Parse(fontSize);
        testRadius = radiusSize;
    }

    public void editEffectRadius(string fontSize)
    {
        float radiusSize = float.Parse(fontSize);
        effectRadius = radiusSize;
    }


    // ----------------------------------------------------------------------------------- <>
    //  Set the dropdown values for the test and effect screens
    //  #Using the listOfFonts

    public void setDropdown(string value)
    {

        if(value.Equals("Test"))
        {
            testDropdown.ClearOptions();
            testDropdown.AddOptions(listOfFonts);

        }
        else
        {
            effectDropdown.ClearOptions();
            effectDropdown.AddOptions(listOfFonts);

        }

    }


    public void setTestFont(int value)
    {
        print("Dropdown value: " + listOfFonts[value]);
    
    
    }

    public void setEffectFont(int value)
    {
        print("Dropdown value: " + listOfFonts[value]);


    }



    // ----------------------------------------------------------------------------------- <>
    //  Create the test screen for the test result
    //  

    public void createTableRow(string[] values)
    {



        //List<int> questionNumberList = new List<int>();
        //List<int> submittedAnswerList = new List<int>();
        //List<int> actualAnswerList = new List<int>();
        //List<float> secondsTakenList = new List<float>();
        //List<bool> correctQuestionAnswer = new List<bool>();  


        //clone1.transform.parent = GameObject.Find("Player(clone)").transform;
        //GameObject a = GameObject.Instantiate(GameObject.Find("TitleRow"));

        //This works
        //Transform a = GameObject.Find("TitleRow").transform;
        //a.Find("Question").Find("QuestionText").GetComponent<Text>().text = "Hello";
        //x = -5
        //z = -0.5
        //Start height = 199.3
        //Row height = 70
        float tempXValue = -5 - 16;
        double tempZValue = -0.5;
        double startingHeight = 199.3-90;
        double rowHeight = 41.0;

        // Generate Table
        // for each row in the table list
        //  //Delete all but title row
        //
        // for each row in the question results
        // create gameobject
        // change each value
        // create position
        Transform resultsTableTemp = GameObject.Find("ResultsTable").transform;

        var children = new List<GameObject>();
       // children.Add(child.gameObject);
        //children.ForEach(child => Destroy(child));


        int childCounter = 0;
        while (childCounter < resultsTableTemp.childCount)
        {
            if(childCounter > 1)
            {
                //Destroy(resultsTableTemp.GetChild(childCounter));
                children.Add(resultsTableTemp.GetChild(childCounter).gameObject);
            }
            childCounter += 1;
        }

        children.ForEach(child => Destroy(child));

        print("Len Sub: " + providedAnswers.Count);
        print("Len Act: " + actualAnswers.Count);
        //print("Len cor: " + actualAnswers.Count);

        int genCount = 1;
        while (genCount <= providedAnswers.Count)
        {
            print("Added a line");
            GameObject parentObject = GameObject.Find("TitleRow");
            Transform titleRowAdditional = GameObject.Instantiate(GameObject.Find("TitleRow")).transform;
            titleRowAdditional.Find("Question").Find("QuestionText").GetComponent<Text>().text = genCount.ToString();

            string app = providedAnswers.ElementAt(genCount - 1);
            print(app);
            titleRowAdditional.Find("SSubmited").Find("SubmittedText").GetComponent<Text>().text = app;
            titleRowAdditional.Find("ActualAnswer").Find("ActualText").GetComponent<Text>().text = actualAnswers.ElementAt(genCount-1).ToString();

            string valueTemp = "";
            if (providedAnswers.ElementAt(genCount - 1).ToString().Equals(actualAnswers.ElementAt(genCount - 1).ToString()))
            { valueTemp = "T"; }
            else
            { valueTemp = "F"; }

            titleRowAdditional.Find("CorrectAnswer").Find("CorrectText").GetComponent<Text>().text = valueTemp;
            
            print(tempXValue);
            print(startingHeight);
            titleRowAdditional.name = "AddedRow";
            titleRowAdditional.parent = GameObject.Find("ResultsTable").transform;
            titleRowAdditional.transform.position = parentObject.transform.position - new Vector3(0, (float)rowHeight, 0);

            //startingHeight = startingHeight - rowHeight;
            rowHeight += rowHeight;
            genCount += 1;
        }
        
    }










}

