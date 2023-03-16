using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotadorMoneda : MonoBehaviour
{
    public float velocidad = 5;
    void Start()
    {
        
    }
    
    void Update()
    {
        transform.Rotate(0, 0, velocidad * Time.deltaTime);
    }
}