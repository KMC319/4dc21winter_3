using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class GameOver : MonoBehaviour
{
    public GameObject Cool_text;
    private static readonly string[] COMMENTS = new string[] {"îÚÇ◊Ç»Ç¢ÇÌÇØÇ≈ÇÕÇ»Ç¢ÅBÇ‹ÇæîÚÇŒÇ»Ç¢ÇæÇØÅB\nIt's not that I can't fly. It just doesn't fly yet.",
    "aaaaaaaa","bbbbbbbb","ccccccc","ddddddd",};
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
        Debug.Log("titleÇ÷");
    }

    public void Toquit()
    {
        Debug.Log("end");
    }
}
