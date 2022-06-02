using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{

    [SerializeField] double waitTime = 5f;   
    double start_time;
    Rigidbody rbd;
    MeshRenderer mrenderer;

    bool isfall = false;
    void Start()
    {
        start_time = Time.time;

        mrenderer = GetComponent<MeshRenderer>();
        rbd = GetComponent<Rigidbody>();

        mrenderer.enabled = false;
        rbd.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(!isfall && Time.time - start_time > waitTime){
            Debug.Log(Time.time);
            mrenderer.enabled = true;
            rbd.useGravity = true;
            isfall = true;
        }

    }
}
