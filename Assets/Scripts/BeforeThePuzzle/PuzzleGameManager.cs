using ProjectSystem;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleGameManager : MonoBehaviour
{
    public static int Chicken_count = 5;
    public static int Death_count = 0;
    public static int Yakitori_count = 0;
    public static int Toripack_count = 0;
    public Text Chicken_Number;
    public Text Yakitori_Number;
    public Text Toripack_Number;

    public int StartLife;
    
    /*public static int a;
    public static int b;*/

   
    // Start is called before the first frame update
    void Start() {
        Chicken_count = StartLife;
        Death_count = Yakitori_count = Toripack_count = 0;
    }

    // Update is called once per frame
    void Update()
    { 
      if(Chicken_count<=0 && !SceneController.IsSceneChanging)
        {
            SceneController.SceneMove(SceneName.GameOver).Forget();
        }
        Chicken_Number.text = "~" + Chicken_count;

        Yakitori_Number.text = "~" + Yakitori_count;

        Toripack_Number.text = $"x{Toripack_count}";

        /*a = Chicken_count;
        b = Yakitori_count;*/
    }

    /*public static int getA()
    {
        return a;
    }

    public static int getB()
    {
        return b;
    }*/
}