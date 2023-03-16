using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerController : MonoBehaviour
{
    public float velocidad = 10;
    public TextMeshProUGUI textoMonedas;
    public TextMeshProUGUI textoVictoria;

    private int monedas = 0;
    
    private Rigidbody miRigidbody;
    private Vector3 posicionInicial;
    private bool haSalido;

    private void Start()
    {
        miRigidbody = GetComponent<Rigidbody>();
        posicionInicial = transform.position;
        textoVictoria.enabled = false;
        haSalido = false;
    }

    private void Update()
    {
        if (!haSalido)
        {
            float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        
        miRigidbody.AddForce(new Vector3(horizontal, 0, vertical) * velocidad);
        }
    }

    private void OnTriggerEnter(Collider otro)
    {
        if (otro.CompareTag("Salida"))
        {
            haSalido = true;
            textoVictoria.enabled = true;
            miRigidbody.velocity = Vector3.zero;
            miRigidbody.angularVelocity = Vector3.zero;
        }
        else if (otro.CompareTag("Enemigo"))
        {
            miRigidbody.MovePosition(posicionInicial);
            miRigidbody.velocity = Vector3.zero;
            miRigidbody.angularVelocity = Vector3.zero;
            monedas = 0;
            textoMonedas.text = "Monedas: 0";
        }
        else if (otro.CompareTag("Moneda"))
        {
            otro.gameObject.SetActive(false);
            monedas = monedas + 1;
            textoMonedas.text = "Monedas " + monedas;
        }
    }
}