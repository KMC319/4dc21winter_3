using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PuzzleGameManager : MonoBehaviour
{
    public  int Chicken_count = 5;
    public int Yakitori_count = 0;
    public GameObject Chicken_Number;
    public GameObject Yakitori_Number;
    public static int a;
    public static int b;

   
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

        Text Yakitori_text = Yakitori_Number.GetComponent<Text>();
        Yakitori_text.text = "Å~" + Yakitori_count;

        a = Chicken_count;
        b = Yakitori_count;
    }

    public static int getA()
    {
        return a;
    }

    public static int getB()
    {
        return b;
    }
}
