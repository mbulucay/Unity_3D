using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountScore : MonoBehaviour
{
    private int score = 0;


    void OnCollisionEnter(Collision other) {

        if(other.gameObject.tag != "Hit"){
            score++;
            Debug.Log("New Score " + score);
        }
    }


}
