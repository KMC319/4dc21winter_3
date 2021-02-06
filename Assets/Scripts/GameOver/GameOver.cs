using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;
using ProjectSystem;

public class GameOver : MonoBehaviour
{
    public GameObject Cool_text;
    private static readonly string[] COMMENTS = new string[] {"飛べない鶏はただの鶏肉だ\nA chicken that can't fly is just a chicken. ",
    "そこのお前！鶏肉100gあたりに含まれる脂質は鶏肉100g分だぜ\nHey, you! That's 100 grams of fat in every 100 grams of chicken.",
        "で、俺が料理されたってわけ\nAnd then they cooked me.","鶏肉、下から見るか横から見るか\nChicken, viewed from below or from the side",
        "鳥柱、鶏肉の呼吸、壱の型、鶏！！\nBird pillar, chicken breath, type one, chicken!","長男だったら我慢できたけど、次男だから我慢できなかった\nI could  was my first son, but I couldn't because my second son.",
    };
    // Start is called before the first frame update
    void Start()
    {
        string comment = COMMENTS.ElementAt(Random.Range(0, COMMENTS.Count()));

        Text Random_text = Cool_text.GetComponent<Text>();
        Random_text.text = comment;
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
        Debug.Log("titleへ");
        SceneController.SceneMove(SceneName.Title).Forget();
    }

    public void Toquit()
    {
        Debug.Log("end");
        Application.Quit();
    }
}
