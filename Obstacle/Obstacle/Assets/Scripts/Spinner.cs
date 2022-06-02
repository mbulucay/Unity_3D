using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] float spin_x = 0;
    [SerializeField] float spin_y = 0;
    [SerializeField] float spin_z = 0;
    
    void Update()
    {
        transform.Rotate(spin_x, spin_y, spin_z);
    }

}
