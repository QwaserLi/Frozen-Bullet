using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletTimeView : MonoBehaviour
{
    Text BulletTimeText;


    // Start is called before the first frame update
    void Start()
    {
        BulletTimeText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        BulletTimeText.text = PlayerController.BulletTime.ToString();

    }
}
