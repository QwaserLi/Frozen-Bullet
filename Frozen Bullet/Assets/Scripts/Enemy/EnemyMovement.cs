using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	public static void MoveStopShootAndGo(Enemy e, Vector3 originalPosition, bool moveLeft)
	{
		List<Vector3> movepoint = new List<Vector3>();
		List<float> movedelay = new List<float>();
		int left = -1;
		if (!moveLeft) {
			left = 1;
		}
		movepoint.Add(originalPosition + new Vector3(left*4, 0, 0));
		movepoint.Add(movepoint[movepoint.Count - 1] + new Vector3(left * 4000, 0, 0));

		movedelay.Add(1.5f);
		e.shootWhileMoving(false);
		e.SetMovePoint(movepoint);
		e.SetMovementDelay(movedelay);

	}


    public static void MoveStopShootAndGoBack(Enemy e, Vector3 originalPosition, bool moveLeft)
    {
        List<Vector3> movepoint = new List<Vector3>();
        List<float> movedelay = new List<float>();
        int left = -1;
        if (!moveLeft)
        {
            left = 1;
        }
        movepoint.Add(originalPosition + new Vector3(left * 4, 0, 0));
        movepoint.Add(movepoint[movepoint.Count - 1] + new Vector3(-left * 4000, 0, 0));

        movedelay.Add(1.5f);
        e.shootWhileMoving(false);
        e.SetMovePoint(movepoint);
        e.SetMovementDelay(movedelay);
    }

    public static void MoveToPlayerThenGo(Enemy e, Vector3 originalPosition, bool moveLeft)
    {
        List<Vector3> movepoint = new List<Vector3>();
        List<float> movedelay = new List<float>();
        int left = -1;
        if (!moveLeft)
        {
            left = 1;
        }
        Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        playerPos.x += Random.Range(-3, 3);

        playerPos.y += Random.Range(-4, 4);
        movepoint.Add(playerPos);
        movepoint.Add(movepoint[movepoint.Count - 1] + new Vector3(left * 4000, 0, 0));

        movedelay.Add(1f);
        e.shootWhileMoving(false);
        e.SetMovePoint(movepoint);
        e.SetMovementDelay(movedelay);
    }
    

    //NOT TOO BALANCED
    public static void MoveToMiddlethenVertical(Enemy e, Vector3 originalPosition, bool moveLeft)
    {
        List<Vector3> movepoint = new List<Vector3>();
        List<float> movedelay = new List<float>();
        int left = -1;
        if (!moveLeft)
        {
            left = 1;
        }
        float Middle = Random.Range(-1, 1);
        movepoint.Add(new Vector3(left * Middle, originalPosition.y, 0));

        if (originalPosition.y >= 0)
        {
            movepoint.Add(movepoint[movepoint.Count - 1] + new Vector3(0, left * 4000, 0));

        }
        else {
            movepoint.Add(movepoint[movepoint.Count - 1] + new Vector3(0, -left * 4000, 0));

        }


        movedelay.Add(3f);
        e.shootWhileMoving(false);
        e.SetMovePoint(movepoint);
        e.SetMovementDelay(movedelay);
    }

    public static void ZigZagFull(Enemy e, Vector3 originalPosition, bool moveLeft)
    {
      
    }


}
