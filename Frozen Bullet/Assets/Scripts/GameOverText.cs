using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverText : MonoBehaviour
{
    Text restart;
    Text Score;
    Text points;

    // Start is called before the first frame update
    void Start()
    {
        Score = GameObject.Find("EndGameScore").GetComponent<Text>();
        points = GameObject.Find("EndGamePoints").GetComponent<Text>();
        restart = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Level.playerIsDead) {
            Score.enabled = true;
            points.enabled = true;
            restart.enabled = true;

        }
    }
}
