using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	public static void TestMovement(Enemy e, Vector3 originalPosition) {
		List<Vector3> movepoint = new List<Vector3>();
		List<float> movedelay = new List<float>();
		movepoint.Add(originalPosition + new Vector3(-4, 0, 0));
		movepoint.Add(movepoint[movepoint.Count - 1] + new Vector3(0, 4000, 0));

		movedelay.Add(0);
		movedelay.Add(0);

		e.SetMovePoint(movepoint);
		e.SetMovementDelay(movedelay);

	}

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

    public static void MoveToPlayerThenUp(Enemy e, Vector3 originalPosition, bool moveLeft)
    {
        //List<Vector3> movepoint = new List<Vector3>();
        //List<float> movedelay = new List<float>();
        //int left = -1;
        //if (!moveLeft)
        //{
        //    left = 1;
        //}
        ////game
        ////movepoint.Add();
        //movepoint.Add(movepoint[movepoint.Count - 1] + new Vector3(-left * 4000, 0, 0));

        //movedelay.Add(3f);
        //e.shootWhileMoving(false);
        //e.SetMovePoint(movepoint);
        //e.SetMovementDelay(movedelay);
    }


}
