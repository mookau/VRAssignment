using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateFont : MonoBehaviour
{
    [SerializeField]
    private Font[] myFonts;
    private Text text;
    private int counter;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        counter = 0;
        text.font = myFonts[counter];
        
    }

    // Update is called once per frame
    
        public void changeFont()
        {
            counter += 1;
            if(counter > 3)
            {
                counter = 0;
            }
            text.font = myFonts[counter];
        }
        
    
}
