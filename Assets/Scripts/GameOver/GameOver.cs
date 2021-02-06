using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;
using ProjectSystem;

public class GameOver : MonoBehaviour
{
    public GameObject[] Train;            
    public GameObject Cool_text;
    private static readonly string[] COMMENTS = new string[] {"”ò‚×‚È‚¢Œ{‚Í‚½‚¾‚ÌŒ{“÷‚¾\nA chicken that can't fly is just a chicken. ",
    "‚»‚±‚Ì‚¨‘OIŒ{“÷100g‚ ‚½‚è‚ÉŠÜ‚Ü‚ê‚é‰¿‚ÍŒ{“÷100g•ª‚¾‚º\nHey, you! That's 100 grams of fat in every 100 grams of chicken.",
        "‚ÅA‰´‚ª—¿—‚³‚ê‚½‚Á‚Ä‚í‚¯\nAnd then they cooked me.","Œ{“÷A‰º‚©‚çŒ©‚é‚©‰¡‚©‚çŒ©‚é‚©\nChicken, viewed from below or from the side",
        "’¹’ŒAŒ{“÷‚ÌŒÄ‹zAˆë‚ÌŒ^AŒ{II\nBird pillar, chicken breath, type one, chicken!","’·’j‚¾‚Á‚½‚ç‰ä–‚Å‚«‚½‚¯‚ÇAŸ’j‚¾‚©‚ç‰ä–‚Å‚«‚È‚©‚Á‚½\nI could  was my first son, but I couldn't because my second son.",
    "PUI PUI PUI ",};
    // Start is called before the first frame update
    void Start()
    {
        string comment = COMMENTS.ElementAt(Random.Range(0, COMMENTS.Count()));

        Text Random_text = Cool_text.GetComponent<Text>();
        Random_text.text = comment;

        var number = Random.Range(0, Train.Length);
        Instantiate(Train[number], transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Tomain()
    {
        Debug.Log("replay");
        SceneController.SceneMove(SceneName.Puzzle).Forget();
    }
    public void Totitle()
    {
        Debug.Log("title‚Ö");
        SceneController.SceneMove(SceneName.Title).Forget();
    }

    public void Toquit()
    {
        Debug.Log("end");
        Application.Quit();
    }
}
