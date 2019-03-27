using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
	public Enemy[] EnemyTypes;
	//1:Left Shoot
	//2:Right Shoot
	//3:Plus Shoot
	//4: Cirle Shoot
	//5: Spiral Shoot
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
    }

    // Update is called once per frame
    void Update()
    {
		if (currentEnemies.Count == 0 || currentSectionEnded) {
			currentSectionEnded = false;
			if (currentSectionIndex +1 < sections.Count) {
				StartCoroutine(sections[currentSectionIndex++].GetEnumerator());
			}
		}
    }

	IEnumerable StartSection1()
	{
		

		yield return null;

		currentSectionEnded = true;
	}

	void runLevel() {

	}
}
