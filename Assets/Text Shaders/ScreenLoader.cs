using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1600, 720, FullScreenMode.FullScreenWindow);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
