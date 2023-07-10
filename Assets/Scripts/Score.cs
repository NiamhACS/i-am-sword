using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score = 0;

    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        text.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        score = GameController.instance.score;
        text.text = score.ToString();
    }
}
