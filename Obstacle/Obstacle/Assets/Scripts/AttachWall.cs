using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachWall : MonoBehaviour
{

    // [SerializeField] string msg = "Default Message";
    [SerializeField] Material collision_material;

    void Awake() {
        // GetComponent<MeshRenderer>();
        // msg = "Default Message";
    }

    void OnCollisionEnter(Collision other) {

        // Debug.Log(msg);
        if(other.gameObject.tag == "Player"){
            GetComponent<MeshRenderer>().material = collision_material;
            gameObject.tag = "Hit";
        }
    }

}
