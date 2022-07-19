using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (MeshFilter))]
[RequireComponent (typeof (MeshRenderer))]
public class PlaneMesh : MonoBehaviour
{
    public int sizeby = 4;
    public float xMult = 1f;
    public float zMult = 1f;
    public float yMult = 0.58f;

    public float Offset = 0f;

    private List<Vector3> vertices = new List<Vector3>();
    private List<int> triangles = new List<int>();
    private float[, ] heights;

    private Mesh mesh;

    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        heights = new float[sizeby, sizeby];
        createHeight();
    }

    void Update()
    {
        createMeshData();
        createMesh();
        Offset += 0.02f;
        createHeight();
    }

    void createMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.RecalculateNormals();
    }

    void createMeshData()
    {
        createVertices();
        createTriangles();
    }

    void createHeight()
    {
        for(int x=0; x<sizeby; ++x){
            for(int z=0; z<sizeby; ++z){
                float localX = x * xMult + Offset;
                float localZ = z * zMult;
                heights[x, z] = Mathf.PerlinNoise(localX * yMult, localZ * yMult);
            }
        }
    }

    void createVertices()
    {
        for(int x=0; x<sizeby; ++x){
            for(int z=0; z<sizeby; ++z){
                vertices.Add(new Vector3(x * xMult, heights[x, z], z * zMult));
            }
        }
    }

    void createTriangles()
    {
        int v = 0;
        for(int i=0; i<(sizeby-1); ++i){
            for(int j=0; j<(sizeby-1); ++j){
                triangles.Add(v);
                triangles.Add(v+1);
                triangles.Add(v + sizeby + 1);
                v++;
            }
            v++;
        }

        v = 0;
        for(int i=0; i<(sizeby-1); ++i){
            for(int j=0; j<(sizeby-1); ++j){
                
                triangles.Add(v);
                triangles.Add(v + sizeby + 1);
                triangles.Add(v + sizeby);
                v++;
            }
            v++;
        }
    }

}
