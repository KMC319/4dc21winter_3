using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleGameManager : MonoBehaviour
{
    public  int Chicken_count = 5;
    public GameObject Chicken_Number;
    public static int a;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
      if(Chicken_count<=0)
        {
            Debug.Log("é∏îs");
        }
        Text Chicken_text = Chicken_Number.GetComponent<Text>();
        Chicken_text.text = "Å~" + Chicken_count;

        a = Chicken_count;
    }

    public static int getA()
    {
        return a;
    }
}
