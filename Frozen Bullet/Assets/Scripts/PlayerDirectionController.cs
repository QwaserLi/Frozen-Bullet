using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirectionController : MonoBehaviour
{
	 PlayerDirection playerDirection;

	private void Start()
	{
		playerDirection = PlayerDirection.Right;	
	}

	public void ChangeDirection(float movement)
	{
		if (movement > 0) {
			playerDirection = PlayerDirection.Left;

		}
		else if(movement < 0){
			playerDirection = PlayerDirection.Right;

		}
	}

	public PlayerDirection getDirection() {
		return playerDirection;
	}

	public bool isFacingEnemy(EnemyPosition enemyPosition) {
		if (enemyPosition == EnemyPosition.Right && playerDirection == PlayerDirection.Right ||
			enemyPosition == EnemyPosition.Left && playerDirection == PlayerDirection.Left)
		{
			return true;
		}
		else {
			return false;
		}

	}
}
