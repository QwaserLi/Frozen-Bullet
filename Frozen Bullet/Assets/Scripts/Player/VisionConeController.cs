using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionConeController : MonoBehaviour
{

	// Update is called once per frame
	Color baseColor, damageColor;
	Renderer rend;
    bool FreezeBullets;
    CircleCollider2D bulletTimeCollider;
    PolygonCollider2D polyCol;

    private void Start()
    {
		rend = GetComponent<Renderer>();
		baseColor = new Color(0.4655588f, 1, 0, 0.4470588f);
		damageColor = new Color(1f, 0, 0, 0.4470588f);
        bulletTimeCollider = GetComponent<CircleCollider2D>();
        bulletTimeCollider.enabled = false;
        polyCol = GetComponent<PolygonCollider2D>();


    }

    private void Update()
	{
		if (transform.parent.GetComponent<PlayerController>().isPlayerDamaged())
		{
			rend.material.SetColor("_Color", damageColor);
		}
		else
		{
			rend.material.SetColor("_Color", baseColor);
		}
	}

	void FixedUpdate()
    {
        if (PlayerController.BulletTime == PlayerController.BulletTimeThreshold && Input.GetKey(KeyCode.Space)) {
            FreezeBullets = true;
            VisionCone.scaleWithHealth = false;
            PlayerController.BulletTime = 0;
            PlayerController.BulletTimeActivated = true;
            bulletTimeCollider.enabled = true;
            polyCol.enabled = false;
            Invoke("resetBulletTime",3f);
        }
		if (!PlayerController.BulletTimeActivated) {
			transform.localRotation = transform.parent.rotation;
		}
    }

    void resetBulletTime() {
        FreezeBullets = false;
        VisionCone.scaleWithHealth = true;
        PlayerController.BulletTime = 0;
        PlayerController.BulletTimeActivated = false;
        bulletTimeCollider.enabled = false;
        polyCol.enabled = true;



    }

    private void LateUpdate()
    {
        if (!PlayerController.BulletTimeActivated)
        {
            createColllider();
        }
    }

    private void createColllider() {
        Mesh visioncone = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = visioncone.vertices;
        int vertexCount = vertices.Length;

        Vector2[] vert2D = new Vector2[vertexCount + 1];
        for (int i = 0; i < vertexCount; i++)
        {
            vert2D[i] = new Vector2(vertices[i].x, vertices[i].y);
        }
        polyCol.points = vert2D;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //Do damage and destroy
            Enemy e = collision.gameObject.GetComponent<Enemy>();
            e.Freeze();
        }

        if (collision.gameObject.tag == "Spawner")
        {
            //Do damage and destroy
            EnemySpawner e = collision.gameObject.GetComponent<EnemySpawner>();
            e.toggleInsight();
        }

        if (collision.gameObject.tag == "EnemyProjectile" && FreezeBullets)
        {
            //Do damage and destroy
            EnemyBullet e = collision.gameObject.GetComponent<EnemyBullet>();
            e.Freeze();
        }
        if (collision.gameObject.tag == "EnemyProjectile" && !FreezeBullets)
        {
            //Do damage and destroy
            EnemyBullet e = collision.gameObject.GetComponent<EnemyBullet>();
            e.UnFreeze();
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //Do damage and destroy
            Enemy e = collision.gameObject.GetComponent<Enemy>();
            e.UnFreeze();
        }

        if (collision.gameObject.tag == "Spawner")
        {
            //Do damage and destroy
            EnemySpawner e = collision.gameObject.GetComponent<EnemySpawner>();
            e.toggleInsight();
        }

        if (collision.gameObject.tag == "EnemyProjectile")
        {
            //Do damage and destroy
            EnemyBullet e = collision.gameObject.GetComponent<EnemyBullet>();
            e.UnFreeze();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //Do damage and destroy
            Enemy e = collision.gameObject.GetComponent<Enemy>();
            e.Freeze();
        }
        if (collision.gameObject.tag == "EnemyProjectile" && FreezeBullets)
        {
            //Do damage and destroy
            EnemyBullet e = collision.gameObject.GetComponent<EnemyBullet>();
            e.Freeze();
        }
		if (collision.gameObject.tag == "EnemyProjectile" && !FreezeBullets)
		{
			//Do damage and destroy
			EnemyBullet e = collision.gameObject.GetComponent<EnemyBullet>();
			e.UnFreeze();
		}
	}
}
