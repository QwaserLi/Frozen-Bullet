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
		movepoint.Add(originalPosition + new Vector3(left*Random.Range(2,4), 0, 0));
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
        playerPos.x += Random.Range(-5, 5);

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
        float Middle = Random.Range(-5, 5);
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

    public static void AngleMoveTwice(Enemy e, Vector3 originalPosition, bool moveLeft)
    {
        List<Vector3> movepoint = new List<Vector3>();
        List<float> movedelay = new List<float>();

        Vector2 angle;

        if (moveLeft) {
            angle = Utility.DegreeToVector2(Random.Range(-70, 70));
        }
        else {
            angle = Utility.DegreeToVector2(Random.Range(110, 250));
        }
        int multi = Random.Range(4, 7);
        movepoint.Add(new Vector3(angle.x*multi,angle.y*multi,0));
        if (moveLeft)
        {
            angle = Utility.DegreeToVector2(Random.Range(-70, 70));
        }
        else
        {
            angle = Utility.DegreeToVector2(Random.Range(110, 250));
        }

        movepoint.Add(movepoint[movepoint.Count - 1] + new Vector3(angle.x*2, angle.y*2, 0));
        if (moveLeft)
        {
            angle = Utility.DegreeToVector2(Random.Range(-70, 70));
        }
        else
        {
            angle = Utility.DegreeToVector2(Random.Range(110, 250));
        }
        movepoint.Add(movepoint[movepoint.Count - 1] + new Vector3(angle.x * 4000, angle.y * 4000, 0));

        movedelay.Add(3f);
        movedelay.Add(2f);

        e.shootWhileMoving(false);
        e.SetMovePoint(movepoint);
        e.SetMovementDelay(movedelay);
    }


}
