using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{

    [SerializeField] float moveSpeed = 5f;
    
    float x, z;

    Vector3 pos;

    

    void Start()
    {
        
    }

    void Update()
    {
        x = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        // y = 0f;
        z = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        pos = new Vector3(x, 0, z);
        transform.Translate(pos);
    }

    // void OnMove(InputValue key){
    //     rawInput = key.Get<Vector2>();
    //     float x = rawInput.x;
    //     // float y = rawInput.z;
    //     float z = rawInput.y;


    //     transform.Translate(x, 0, z);
        
    //     Debug.Log(rawInput);

        
    // }

}
