using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject jugador;
    private Vector3 distancia;
    void Start()
    {
        distancia = transform.position - jugador.transform.position;
    }
    
    void Update()
    {
        transform.position = jugador.transform.position + distancia;
    }
}