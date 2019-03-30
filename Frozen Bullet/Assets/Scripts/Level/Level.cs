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
    private List<IEnumerable> sections;
    int currentSectionIndex;
    bool currentSectionEnded;
    PlayerController player;
    float spawnTimer;
    float spawnRate = 2.0f;

    int HighScore;
    public Text HighScoreText;


    // Start is called before the first frame update
    void Start()
    {
        currentSectionIndex = 0;
        currentSectionEnded = true;

        currentEnemies = new List<Enemy>();
        sections = new List<IEnumerable>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        //Add all sections to section list 

        //sections.Add(StartSection1());
        //sections.Add(StartSection2());
        //sections.Add(StartSection3());
        //sections.Add(TwoSpawnSection());
        //sections.Add(TwoSpawnSection());
        //sections.Add(TwoSpawnSection());

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
			if (e.health > -10000 && e.health <= 0) {
                float scale = 1 +(1-player.getHealthPercentage());
                float points = 200 * scale;
				HighScore += (int)points;

			}
			HighScoreText.text = HighScore.ToString();
        }


        //Spawn Enemies
        SpawnEnemies();

        //if (currentEnemies.Count == 0 || currentSectionEnded)
        //{
        //    currentSectionEnded = false;
        //    if (currentSectionIndex < sections.Count)
        //    {
        //        StartCoroutine(sections[currentSectionIndex++].GetEnumerator());
        //    }
        //}
    }

    void SpawnEnemies() {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnRate)
        {
            int amtEnemy = Random.Range(1, 6);
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
                    int randomSpawner = Random.Range(0, avaliableSpawners.Count - 1);
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

                //Select Random Movement NOT IMPLEMENTED YET

                EnemyMovement.MoveToPlayerThenGo(e, t.position, !left);
                // Decide type of movement 
                currentEnemies.Add(e);

            }

            spawnTimer = 0;
        }
    }

    IEnumerable StartSection1()
    {
        for (int i = 0; i <= 5; i++)
        {
            Transform t = RightSpawners[i].transform;
            Enemy e = Instantiate(EnemyTypes[5], t.position, t.rotation);
            e.SetMoveDirection(new Vector2(-1, 0));
            EnemyMovement.MoveStopShootAndGo(e, t.position, true);
            // Decide type of movement 
            currentEnemies.Add(e);

            yield return new WaitForSeconds(0.2f);

        }
        yield return new WaitForSeconds(1.5f);


        currentSectionEnded = true;
    }

    IEnumerable StartSection2()
    {
        for (int i = LeftSpawners.Length - 1; i >= 5; i--)
        {
            Transform t = LeftSpawners[i].transform;
            Enemy e = Instantiate(EnemyTypes[5], t.position, t.rotation);
            e.SetMoveDirection(new Vector2(-1, 0));
            EnemyMovement.MoveStopShootAndGo(e, t.position, false);
            // Decide type of movement 
            currentEnemies.Add(e);

            yield return new WaitForSeconds(0.2f);
        }
        yield return new WaitForSeconds(3.0f);

        currentSectionEnded = true;
    }

    IEnumerable StartSection3()
    {
        for (int i = 0; i <= 10; i += 10)
        {
            Transform t = RightSpawners[i].transform;
            Enemy e = Instantiate(EnemyTypes[4], t.position, t.rotation);
            e.SetMoveDirection(new Vector2(-1, 0));
            EnemyMovement.MoveStopShootAndGoBack(e, t.position, true);

            currentEnemies.Add(e);

        }

        for (int i = LeftSpawners.Length - 1; i >= 0; i -= 10)
        {
            Transform t = LeftSpawners[i].transform;
            Enemy e = Instantiate(EnemyTypes[4], t.position, t.rotation);
            e.SetMoveDirection(new Vector2(1, 0));
            EnemyMovement.MoveStopShootAndGoBack(e, t.position, false);

            currentEnemies.Add(e);

        }

        yield return new WaitForSeconds(3f);


        currentSectionEnded = true;
    }

    IEnumerable TwoSpawnSection()
    {

        int enemyType = Random.Range(0, EnemyTypes.Length);

        int spawner = Random.Range(0, RightSpawners.Length);
        Transform t = RightSpawners[spawner].transform;
        Enemy e = Instantiate(EnemyTypes[enemyType], t.position, t.rotation);
        e.SetMoveDirection(new Vector2(-1, 0));
        EnemyMovement.MoveStopShootAndGo(e, t.position, true);
        currentEnemies.Add(e);


        //DELAY
        spawner = Random.Range(0, RightSpawners.Length);
        t = LeftSpawners[spawner].transform;
        e = Instantiate(EnemyTypes[enemyType], t.position, t.rotation);
        e.SetMoveDirection(new Vector2(1, 0));
        EnemyMovement.MoveStopShootAndGo(e, t.position, false);
        currentEnemies.Add(e);


        yield return new WaitForSeconds(3f);

        currentSectionEnded = true;
    }

}
