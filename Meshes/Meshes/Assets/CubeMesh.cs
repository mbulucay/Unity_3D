using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (MeshFilter))]
[RequireComponent (typeof (MeshRenderer))]
public class CubeMesh : MonoBehaviour
{
    Mesh mesh;

    public float UpDownFactor = 0.1f;
    public float UpDownSpeed = 6f; 

    public float LeftFactor = 0.3f;
    public float LeftSpeed = 3f;
    public float LeftOffset = 2.3f;

    public float StrectFactor = -0.1f;
    public float StrectSpeed = 6f; 

    void Start()
    {
        mesh = gameObject.GetComponent<MeshFilter>().mesh;

        mesh.vertices = GenerateVertices();
        mesh.triangles = GenerateTriangles();
    }

    void Update()
    {
        mesh.vertices = GenerateVertices(
            Mathf.Sin(Time.realtimeSinceStartup * UpDownSpeed) * UpDownFactor,
            Mathf.Sin(Time.realtimeSinceStartup * LeftSpeed + LeftOffset) * LeftFactor,
            Mathf.Sin(Time.realtimeSinceStartup * StrectSpeed) * StrectFactor
        );
    }

    Vector3[] GenerateVertices(float up = 0f, float left = 0f, float stretch = 0f)
    {
        return new Vector3[]{
                //     0   1
                // 2   3
                //     4   5
                // 6   7
                new Vector3(0- stretch + left, 1 + up, 1 + stretch),    new Vector3(1  + stretch + left, 1 + up, 1 + stretch), 
            new Vector3(0  + stretch + left, 1 + up, 0 - stretch),  new Vector3(1  - stretch + left, 1 + up, 0 - stretch),
                new Vector3(0, 0, 1),                                   new Vector3(1, 0, 1),
            new Vector3(0, 0, 0),                                   new Vector3(1, 0, 0)

        };
    }

    int[] GenerateTriangles()
    {
        return new int[]{
            // top
            0,1,3, 
            2,0,3,

            //bottom
            5,4,7,
            4,6,7,

            //front
            2,3,7,
            6,2,7,

            //back
            1,0,5,
            0,4,5,

            //right
            3,1,5,
            7,3,5,

            //left
            0,2,4,
            6,4,2
        };
    }


}
