using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class GameOver : MonoBehaviour
{
    public GameObject Cool_text;
    private static readonly string[] COMMENTS = new string[] {"��ׂȂ��{�͂����̌{����\nA chicken that can't fly is just a chicken. ",
    "�����̂��O�I�{��100g������Ɋ܂܂�鎉���͌{��100g������\nHey, you! That's 100 grams of fat in every 100 grams of chicken.",
        "�ŁA�����������ꂽ���Ă킯\nAnd then they cooked me.","�{���A�����猩�邩�����猩�邩\nChicken, viewed from below or from the side",
        "�����A�{���̌ċz�A��̌^�A�{�I�I\nBird pillar, chicken breath, type one, chicken!","���j��������䖝�ł������ǁA���j������䖝�ł��Ȃ�����\nI could  was my first son, but I couldn't because my second son.",
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
    }
    public void Totitle()
    {
        Debug.Log("title��");
    }

    public void Toquit()
    {
        Debug.Log("end");
    }
}
