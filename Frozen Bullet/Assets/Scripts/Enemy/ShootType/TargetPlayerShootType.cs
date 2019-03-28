using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPlayerShootType : ShootType
{
	public override void Fire()
	{
		if (timer > ShootingTimer)
		{

			GameObject player = GameObject.FindWithTag("Player");
			if (player != null) {
				Vector3 playerPos = player.transform.position;
				Vector3 playerDirection = Utility.getDirection(transform.position, playerPos);

				StartCoroutine(BurstShoot(playerDirection));
			}
			timer = 0;
		}
	}

	IEnumerator BurstShoot(Vector3 playerDirection) {

		EnemyBullet a = Instantiate(eb, transform.position, transform.rotation);
		Vector2 bulletDir = new Vector2(playerDirection.x, playerDirection.y);
		a.setBulletDirection(bulletDir);

		yield return new WaitForSeconds(0.2f);

		EnemyBullet b = Instantiate(eb, transform.position, transform.rotation);
		b.setBulletDirection(bulletDir + Utility.DegreeToVector2(-25));

		yield return new WaitForSeconds(0.2f);
		EnemyBullet c = Instantiate(eb, transform.position, transform.rotation);
		 c.setBulletDirection(bulletDir + Utility.DegreeToVector2(25));
		yield return null;
	}
}
