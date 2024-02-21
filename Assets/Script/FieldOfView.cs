using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FieldOfView : MonoBehaviour
{
    Mesh mesh;
    public float startingAngle = 0;
    public Vector3 origin = Vector3.zero;
    public float angle;
    public float fov = 120f;
    public float viewDistance = 50;
    public int rayCount = 60;
    public LayerMask target;
    public bool catchedTarget { get; private set; }

    private void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

    }
    private void Update()
    {
        DetectObject();
    }

    public bool DetectObject()
    {
       
        float angleIncrease = fov / rayCount;
        angle = startingAngle;

        if (Mathf.Abs(Mathf.DeltaAngle(transform.parent.eulerAngles.y, 180)) < 0.1f)
        {
            angle -= 127;
            //startingAngle *= -1;
        }

        for (int i = 0; i <= rayCount; i++)
        {
            RaycastHit2D rayCast = Physics2D.Raycast(origin, GetVectorFromAngle(angle), viewDistance);

            Debug.DrawRay(origin, GetVectorFromAngle(angle) * viewDistance, Color.blue);

            if (rayCast.collider != null)
            {
                if (rayCast.collider.gameObject.layer == 6)
                {
                    return true;
                }
            }
          


            angle -= angleIncrease;
        }
        return false;
    }

    // deprecate method
    private void DetectByMesh()
    {
        int rayCount = 60;
        float angleIncrease = fov / rayCount;
        float angle = startingAngle;

        transform.localRotation = transform.parent.rotation;
        if (Mathf.Abs(transform.parent.eulerAngles.y) == 180)
        {
            angle -= 60;
        }


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
                /* if (rayCast.collider.gameObject.layer == 3)
                 {
                     Debug.Log(rayCast.point);
                     vertex = rayCast.point;
                 }
                 else
                 {
                     vertex = origin + GetVectorFromAngle(angle) * viewDistance;
                 }*/
                if (rayCast.collider.gameObject.layer == target)
                {
                    catchedTarget = true;
                }
                else
                {
                    catchedTarget = false;
                }
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
}
