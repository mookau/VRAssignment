using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MouseDetection))]
public class ButtonHandler : MonoBehaviour
{
    public MouseDetection apples;

    // Start is called before the first frame update
    void Start()
    {
        apples = GameObject.Find("UltimateView").GetComponent<MouseDetection>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pressedBigB(string executionCode)
    {
        print("Button Press");
        print("Pressed Code: " + executionCode);
        //myObject2.carryOutButtonFunction();
        apples.buttonPressedHandler(executionCode);
        //carryOutButtonFunction();
    }

}
