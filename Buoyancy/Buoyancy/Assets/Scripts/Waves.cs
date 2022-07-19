using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{
    public static Waves instance;

    public float amplitude = 1f;
    public float length = 2f;
    public float speed = 1f;
    public float offset = 0f;
    
    private void Awake() {
        if(instance == null){
            instance = this;
        }else{
            Debug.Log("Object already created destroying");
            Destroy(this);
        }
    }

    void Start()
    {    }

    void Update()
    {
        offset += Time.deltaTime * speed;
    }

    public float getWaveHeight(float _x)
    {
        return amplitude * Mathf.Sin(_x / length + offset);
    }

}
