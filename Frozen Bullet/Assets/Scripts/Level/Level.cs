using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
	public Enemy[] EnemyTypes;
    public EnemySpawner[] LeftSpawners;
    public EnemySpawner[] RightSpawners;

    //1:Left Shoot
    //2:Right Shoot
    //3:Plus Shoot
    //4: Cirle Shoot
    //5: Spiral Shoot
	//6: target player
    private List<Enemy> currentEnemies;
	private List<IEnumerable> sections;
	int currentSectionIndex;
	bool currentSectionEnded;

    // Start is called before the first frame update
    void Start()
    {
		currentSectionIndex = 0;
		currentSectionEnded = true;

		currentEnemies = new List<Enemy>();
		sections = new List<IEnumerable>();

		//Add all sections to section list 

		sections.Add(StartSection1());
        sections.Add(StartSection2());
        sections.Add(StartSection3());

    }

    // Update is called once per frame
    void Update()
    {
        List<Enemy> removeEnemies = new List<Enemy>();


        foreach (Enemy e in currentEnemies) {
            if (e.health <= 0) {
                removeEnemies.Add(e);
            }
        }

        foreach (Enemy e in removeEnemies)
        {
                currentEnemies.Remove(e);  
        }


        if (currentEnemies.Count == 0 || currentSectionEnded) {
			currentSectionEnded = false;
			if (currentSectionIndex < sections.Count) {
				StartCoroutine(sections[currentSectionIndex++].GetEnumerator());
            }
        }
    }

	IEnumerable StartSection1()
	{
        for (int i = 0; i<=5;i++) {
            Transform t = RightSpawners[i].transform;
            Enemy e = Instantiate(EnemyTypes[5],t.position,t.rotation);
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
			EnemyMovement.MoveStopShootAndGo(e, t.position, true);

			currentEnemies.Add(e);

		}

		for (int i = LeftSpawners.Length - 1; i >= 0; i-=10)
		{
			Transform t = LeftSpawners[i].transform;
			Enemy e = Instantiate(EnemyTypes[4], t.position, t.rotation);
			e.SetMoveDirection(new Vector2(1, 0));
			EnemyMovement.MoveStopShootAndGo(e, t.position, false);

			currentEnemies.Add(e);

		}

		yield return new WaitForSeconds(2.5f);


        currentSectionEnded = true;
    }

	IEnumerator RandomSection() {
		yield return new WaitForSeconds(2.5f);

	}

}
