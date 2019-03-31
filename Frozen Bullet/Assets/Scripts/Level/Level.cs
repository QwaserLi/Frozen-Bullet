using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Level : MonoBehaviour
{
    public Enemy[] EnemyTypes;
    public EnemySpawner[] LeftSpawners;
    public EnemySpawner[] RightSpawners;

    //0:Left Shoot
    //1:Right Shoot
    //2:Plus Shoot
    //3: Cirle Shoot
    //4: Spiral Shoot
    //5: target player
    private List<Enemy> currentEnemies;
    PlayerController player;
    float spawnTimer;
    float spawnRate;

    public static int HighScore;
    int bulletTime;

    // Start is called before the first frame update
    void Start()
    {

        spawnRate = 4.0f;
        currentEnemies = new List<Enemy>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        //Add all sections to section list 

    }

    // Update is called once per frame
    void Update()
    {
        //Clear Enemies
        List<Enemy> removeEnemies = new List<Enemy>();

        foreach (Enemy e in currentEnemies)
        {
            if (e.health <= 0)
            {
                removeEnemies.Add(e);
            }
        }

        foreach (Enemy e in removeEnemies)
        {
            currentEnemies.Remove(e);
            if (e.health > -10000 && e.health <= 0)
            {
                float scale = 1 + (1 - player.getHealthPercentage());
                float points = 200 * scale;
                HighScore += (int)points;

            }
            else if (e.health <= -10000) {
                float scale = 1 + (1 - player.getHealthPercentage());
                float points = 50 * scale;
                HighScore += (int)points;
            }
        }


        //Spawn Enemies
        SpawnEnemies();


    }

    void SpawnEnemies()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnRate)
        {
            int amtEnemy = getEnemiesSpawned();
            List<EnemySpawner> avaliableSpawners = new List<EnemySpawner>();
            List<EnemySpawner> selectedSpawners = new List<EnemySpawner>();
            List<int> spawnerIndex = new List<int>();
            List<int> selectedIndices = new List<int>();

            for (int i = 0; i < LeftSpawners.Length; i++)
            {
                EnemySpawner spawner = LeftSpawners[i];
                if (!spawner.getInsight())
                {
                    avaliableSpawners.Add(spawner);
                    spawnerIndex.Add(i);
                }
            }

            for (int i = 0; i < RightSpawners.Length; i++)
            {
                EnemySpawner spawner = RightSpawners[i];
                if (!spawner.getInsight())
                {
                    avaliableSpawners.Add(spawner);
                    spawnerIndex.Add(i);

                }
            }

            for (int i = 0; i < amtEnemy; i++)
            {
                if (avaliableSpawners.Count > 0)
                {
                    int randomSpawner = Random.Range(0, avaliableSpawners.Count);
                    selectedSpawners.Add(avaliableSpawners[randomSpawner]);
                    selectedIndices.Add(spawnerIndex[randomSpawner]);
                    avaliableSpawners.RemoveAt(randomSpawner);
                    spawnerIndex.Remove(randomSpawner);

                }
            }

            for (int i = 0; i < selectedSpawners.Count; i++)
            {
                // Spawn Enemies
                int enemyTyping = selectedIndices[i];
                int enemyType = 0;
                int[] re;
                switch (enemyTyping)
                {
                    case 1:
                        re = new int[] { 3, 4 };
                        enemyType = re[Random.Range(0, re.Length)];
                        break;
                    case 2:
                        re = new int[] { 3, 4 };
                        enemyType = re[Random.Range(0, re.Length)];
                        break;
                    case 3:
                        re = new int[] { 5, 2 };
                        enemyType = re[Random.Range(0, re.Length)];
                        break;
                    case 4:
                        re = new int[] { 5 };
                        enemyType = re[Random.Range(0, re.Length)];
                        break;
                    case 5:
                        re = new int[] { 0, 1 };
                        enemyType = re[Random.Range(0, re.Length)];
                        break;
                    case 6:
                        re = new int[] { 0, 1, 2, 3, 4, 5 };
                        enemyType = re[Random.Range(0, re.Length)];
                        break;
                    case 7:
                        re = new int[] { 0, 1 };
                        enemyType = re[Random.Range(0, re.Length)];
                        break;
                    case 8:
                        re = new int[] { 5 };
                        enemyType = re[Random.Range(0, re.Length)];
                        break;
                    case 9:
                        re = new int[] { 5, 2 };
                        enemyType = re[Random.Range(0, re.Length)];
                        break;
                    case 10:
                        re = new int[] { 3, 4 };
                        enemyType = re[Random.Range(0, re.Length)];
                        break;
                    case 11:
                        re = new int[] { 3, 4 };
                        enemyType = re[Random.Range(0, re.Length)];
                        break;
                    default:
                        break;
                }
                Transform t = selectedSpawners[i].transform;

                bool left = t.position.x < 0 ? true : false;

                if (left && enemyType == 0)
                {
                    enemyType = 1;
                }
                else if (!left && enemyType == 1)
                {
                    enemyType = 0;
                }

                Enemy e = Instantiate(EnemyTypes[enemyType], t.position, t.rotation);
                e.SetMoveDirection(new Vector2(-1, 0));

                //Select Random Movement NEED TO IMPLEMENT ZIG ZAG
                decideMovement(e, t.position, left);
                // Decide type of movement 
                currentEnemies.Add(e);

            }

            spawnTimer = 0;
        }
    }

    void decideMovement(Enemy e, Vector3 position, bool left) {
        int movement = 0;

        if (HighScore <= 2000)
        {
            movement = 3;
        }
        else if (HighScore <= 5000)
        {
            movement = 4;
        }
        else if (HighScore <= 8000)
        {
            movement = 5;
        }
        else if (HighScore <= 15000)
        {
            movement = 5;

        }
        else if (HighScore <= 30000)
        {
            movement = 5;
        }
        else {
            movement = 6;
        }



        int selectMovement = Random.Range(1, movement);

        switch (selectMovement)
        {
            case 1:
                EnemyMovement.MoveStopShootAndGo(e, position, !left);

                break;
            case 2:
                EnemyMovement.MoveStopShootAndGoBack(e, position, !left);

                break;
            case 3:
                EnemyMovement.MoveToMiddlethenVertical(e, position, !left);

                break;
            case 4:
                EnemyMovement.MoveToPlayerThenGo(e, position, !left);
                break;
            case 5:
                EnemyMovement.AngleMoveTwice(e, position, !left);
                break;
            default:
                break;


        }


    }

    int getEnemiesSpawned() {
        int amt = 0;
        if (HighScore <=2000) {
            spawnRate = 3.0f;

            amt = Random.Range(2, 5);
        }
        else if (HighScore <= 5000) {
            spawnRate = 3.0f;

            amt = Random.Range(2, 5);

        }
        else if (HighScore <= 8000)
        {
            spawnRate = 2.5f;

            amt = Random.Range(3, 5);

        }
        else if (HighScore <= 15000)
        {
            spawnRate = 2.5f;

            amt = Random.Range(3, 5);
        }
        else if (HighScore <= 30000)
        {
            spawnRate = 2.5f;

            amt = Random.Range(3, 6);
        }
        else if (HighScore <= 50000)
        {
            spawnRate = 2.5f;

            amt = Random.Range(3, 7);
        }
        else if (HighScore <= 75000)
        {
            spawnRate = 2.5f;

            amt = Random.Range(4, 7);
        }
        else if (HighScore <= 100000)
        {
            spawnRate = 2f;

            amt = Random.Range(4, 8);
        }
        else if (HighScore >= 100000)
        {
            spawnRate = 2f;

            amt = Random.Range(5, 9);
        }

        return amt;
    }
}
