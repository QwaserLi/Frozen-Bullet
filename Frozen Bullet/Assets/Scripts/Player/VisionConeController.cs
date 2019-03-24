using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionConeController : MonoBehaviour
{

    // Update is called once per frame


    private void Start()
    {
    }

    void FixedUpdate()
    {
        transform.localRotation = transform.parent.rotation;
    }

    private void LateUpdate()
    {
        Mesh visioncone = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = visioncone.vertices;
        int vertexCount = vertices.Length;
        PolygonCollider2D polyCol = GetComponent<PolygonCollider2D>();

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

        if (collision.gameObject.tag == "EnemyProjectile")
        {
            //Do damage and destroy
            EnemyBullet e = collision.gameObject.GetComponent<EnemyBullet>();
            e.Freeze();
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
        if (collision.gameObject.tag == "EnemyProjectile")
        {
            //Do damage and destroy
            EnemyBullet e = collision.gameObject.GetComponent<EnemyBullet>();
            e.Freeze();
        }
    }
}
