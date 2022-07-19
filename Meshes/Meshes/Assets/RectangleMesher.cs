using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (MeshFilter))]
[RequireComponent (typeof (MeshRenderer))]
public class RectangleMesher : MonoBehaviour
{
    Vector3[] vertices;
    int[] triangles;

    Mesh mesh;

    void Start(){

        mesh = GetComponent<MeshFilter>().mesh;

        createMeshData();
        createMesh();
    }

    void createMeshData(){

        // (0,0,1) -------- (1,0,1)
        //    |                |
        //    |                |
        // (0,0,0) -------- (1,0,0)

        //  2  3
        //  0  1 


        vertices = new Vector3[]{
            Vector3.zero, //(0,0,0)
            Vector3.right, //(1,0,0)
            Vector3.forward, //(0,0,1)
            Vector3.right + Vector3.forward, //(1,0,1)
        };

        triangles = new int[]{
            0, 2, 1,
            2, 3, 1
        };
    }
    

    void createMesh(){
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
    }

}
