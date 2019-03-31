using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTimeBar : MonoBehaviour
{

    float gauge;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerController.BulletTimeActivated)
        {
            gauge = (float)PlayerController.BulletTime / (float)PlayerController.BulletTimeThreshold;
            transform.localScale = new Vector3(gauge, 1, 1);
        }
        else {
            gauge -=  Time.deltaTime / 3;
            transform.localScale = new Vector3(gauge, 1, 1);
        }
    }
}
