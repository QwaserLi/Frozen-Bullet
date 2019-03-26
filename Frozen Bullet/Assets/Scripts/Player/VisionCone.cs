using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionCone : MonoBehaviour
{
    public float viewRadius;
    [Range(0, 360)]
    public float viewAngle;

    public float meshResolution;

    public MeshFilter viewConeFilter;
    Mesh viewCone;
    float playerHealthPercentage;

    void Start()
    {
        viewCone = new Mesh();
        viewCone.name = "View Mesh";
        viewConeFilter.mesh = viewCone;
    }


    void LateUpdate()
    {
        DrawFieldOfView();
        // Need to rotate here instead
    }

    public void DrawFieldOfView()
    {

        float newAngle = viewAngle * GetComponent<PlayerController>().getHealthPercentage();
        int stepCount = Mathf.RoundToInt(newAngle * meshResolution);
        float stepAngleSize = newAngle / stepCount;
        List<Vector3> viewPoints = new List<Vector3>();
        for (int i = 0; i <= stepCount; i++)
        {
            float angle = transform.eulerAngles.y - newAngle / 2 + stepAngleSize * i;
            viewPoints.Add(getConePart(angle));
        }

        int vertexCount = viewPoints.Count + 1;
        Vector3[] vertices = new Vector3[vertexCount];
        int[] triangles = new int[(vertexCount - 2) * 3];

        vertices[0] = Vector3.zero;
        for (int i = 0; i < vertexCount - 1; i++)
        {
            vertices[i + 1] = transform.InverseTransformPoint(viewPoints[i]);

            if (i < vertexCount - 2)
            {
                triangles[i * 3] = 0;
                triangles[i * 3 + 1] = i + 1;
                triangles[i * 3 + 2] = i + 2;
            }
        }

        viewCone.Clear();
        viewCone.vertices = vertices;
        viewCone.triangles = triangles;
        viewCone.RecalculateNormals();

    }


    Vector3 getConePart(float angle)
    {
        Vector3 dir = new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad), Mathf.Cos(angle * Mathf.Deg2Rad), 0); ;
        return transform.position + dir * viewRadius;
    }
}
