using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionConeController : MonoBehaviour
{
    // Update is called once per frame


    private void Start()
    {
    }

    void Update()
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


}
