using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TestScipt : MonoBehaviour
{
    Mesh mesh;
    public float startingAngle;
    public float angle;
    public float fov = 120f;
    private Quaternion rotationFlag;
    private void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        rotationFlag = transform.parent.rotation;

    }
    private void Update()
    {
        Vector3 origin = Vector3.zero;
        int rayCount = 60;
       /* if (rotationFlag != transform.parent.rotation)
        {
            rotationFlag = transform.parent.rotation;
            transform.Rotate(0, 180, 0);
            if (Mathf.Abs(transform.parent.eulerAngles.y) == 180)
            {
                startingAngle -= 60;
            }
            else
            {
                startingAngle += 60;
            }

        }*/
        angle = startingAngle;

        transform.localRotation = transform.parent.rotation;

        if (Mathf.Abs(transform.parent.eulerAngles.y) == 180)
        {
            angle -= 60;
        }

        float angleIncrease = fov / rayCount;
        float viewDistance = 50;

        Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = origin;

        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i <= rayCount; i++)
        {
            Vector3 vertex;

            RaycastHit2D rayCast = Physics2D.Raycast(origin, GetVectorFromAngle(angle), viewDistance, 1 << 3);
            if (rayCast.collider == null)
            {
                vertex = origin + GetVectorFromAngle(angle) * viewDistance;
            }
            else
            {
                vertex = rayCast.point;
            }


            vertices[vertexIndex] = vertex;

            if (i > 0)
            {
                /* if (Mathf.Abs(transform.rotation.y) == 180)
                 {
                     triangles[triangleIndex + 0] = 0;
                     triangles[triangleIndex + 1] = vertexIndex;
                     triangles[triangleIndex + 2] = vertexIndex + 1;
                 }
                 else
                 {
                     triangles[triangleIndex + 0] = 0;
                     triangles[triangleIndex + 1] = vertexIndex - 1;
                     triangles[triangleIndex + 2] = vertexIndex;
                 }
                */
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }
            vertexIndex++;
            angle -= angleIncrease;
        }



        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
    }

    private Vector3 GetVectorFromAngle(float angle)
    {
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }
}
