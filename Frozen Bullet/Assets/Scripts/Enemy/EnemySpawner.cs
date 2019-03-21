using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    float spawnTimer;
    public float spawnFrequency;
    public Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnFrequency) {
            Vector3 position = new Vector3(Random.Range(-8, 8), Random.Range(-4, 4));
            Instantiate(enemy, position, transform.rotation);
            spawnTimer = 0;

        }
    }
}
