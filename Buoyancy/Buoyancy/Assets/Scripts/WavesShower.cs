using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class WavesShower : MonoBehaviour
{
    private Mesh mesh;

    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3[] vertices = mesh.vertices;

        for(int i=0; i<vertices.Length; ++i){
            vertices[i].y = Waves.instance.getWaveHeight(transform.position.x + vertices[i].x);
        }
        
        mesh.vertices = vertices;
        mesh.RecalculateNormals();
    }
}
