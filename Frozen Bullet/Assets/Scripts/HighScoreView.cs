using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreView : MonoBehaviour
{
     Text HighScoreText;

    // Start is called before the first frame update
    void Start()
    {
        HighScoreText = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        HighScoreText.text = Level.HighScore.ToString();

    }
}
