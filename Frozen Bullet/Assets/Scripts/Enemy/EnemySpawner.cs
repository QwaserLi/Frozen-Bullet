using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    bool inSight;

    private void Start()
    {
        inSight = false;
    }

    public void toggleInsight() {
        inSight = !inSight;
    }

    public bool getInsight() {
        return inSight;
    }
}
