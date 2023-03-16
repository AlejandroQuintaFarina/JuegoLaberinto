using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrullaEnemigo : MonoBehaviour
{
    public Transform desde;
    public Transform hasta;

    public float velocidad;

    private bool llendo;
    void Start()
    {
        llendo = true;
    }
    void Update()
    {
        Vector3 objetivo;
        if (llendo)
        {
            objetivo = hasta.position;
        }
        else
        {
            objetivo = desde.position;
        }

        Vector3 distancia = objetivo - transform.position;
        Vector3 desplazamiento = distancia.normalized * velocidad * Time.deltaTime;

        if (desplazamiento.sqrMagnitude >= distancia.sqrMagnitude)
        {
            desplazamiento = distancia;
        }

        transform.position = transform.position + desplazamiento;

        if (desplazamiento.sqrMagnitude < 0.00001)
        {
            llendo = !llendo;
        }
    }
}