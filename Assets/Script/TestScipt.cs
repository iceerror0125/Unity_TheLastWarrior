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
    public Vector3 origin;
    int rayCount = 60;
    float viewDistance = 50;
    private void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

    }
    private void Update()
    {
        origin = transform.position;//transform.position;

        angle = startingAngle;
        float angleIncrease = fov / rayCount;


        //transform.localRotation = transform.parent.rotation;

        /*   if (Mathf.Abs(transform.parent.eulerAngles.y) == 180)
           {
               angle -= 60;
           }*/


        Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = origin;
        int vertexIndex = 1;
        int triangleIndex = 0;
        Debug.Log("Out: " + origin);
        for (int i = 0; i <= rayCount; i++)
        {
            Vector3 vertex;


            RaycastHit2D rayCast = Physics2D.Raycast(vertices[0], GetVectorFromAngle(angle), viewDistance, 1 << 3);

            Debug.DrawRay(vertices[0], GetVectorFromAngle(angle) * viewDistance, Color.red);

            Debug.Log("In: " + origin);


            if (rayCast.collider == null)
            {
                vertex = origin + GetVectorFromAngle(angle) * viewDistance;
            }
            else
            {
                vertex = rayCast.point;
            }
            if (transform.position.x > 0)
            {
                vertex += transform.position;
            } 
            else
            {
                vertex -= transform.position;
            }


            vertices[vertexIndex] = vertex;

            if (i > 0)
            {
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
    private float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;
    }
    private void SetAimDir(Vector3 aimDir)
    {
        startingAngle = GetAngleFromVectorFloat(aimDir) - fov / 2f;
    }

    /* private void OnDrawGizmos()
     {
         Gizmos.color = Color.red;
         for (int i = 0; i <= rayCount; i++)
         {
             RaycastHit2D rayCast = Physics2D.Raycast(origin, GetVectorFromAngle(angle), viewDistance, 1 << 3);
             Gizmos.color = Color.red;
             Gizmos.DrawLine(origin, (rayCast.collider == null) ? (origin + GetVectorFromAngle(angle) * viewDistance) : rayCast.point);
         }
     }*/
}
