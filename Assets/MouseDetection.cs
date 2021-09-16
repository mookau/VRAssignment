using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
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

    Renderer cubed;
    private bool cubeVis = false;

    // Start is called before the first frame update
    void Start()
    {

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

        Renderer[] lChildRenderers = gameObject.GetComponentsInChildren<Renderer>();
        Component[] childCanvas = gameObject.GetComponentsInChildren(typeof(Canvas));
        //Rigidbody[] childCanvas = gameObject.GetComponentsInChildren<Rigidbody>();

        //gameObject[] lChildRenderers = gameObject.GetComponentsInChildren<gameObject>();
        print("Len Child: " + lChildRenderers.Length);
        print("Len Canvas: " + childCanvas.Length);

        //Text text2 = childCanvas[0].AddComponent<Text>();
        //text2.setText("Apple");

        //foreach (gameObject x in lChildRenderers)
        foreach (Renderer x in lChildRenderers)
        {
            print(x.name);
            if ((x.name).Equals("Cube"))
            {
                cubed = x;
                print("Added Cube");

            }

        }
        print("- - - - - - - - - - - -");
        //foreach (Component x in childCanvas)
        //{
        //    print(x);
        //}


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

    public void pressedBigB(string x)
    {
        print("Button Press");

    }

    //Function A


}

