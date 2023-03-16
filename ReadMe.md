# Laberinto

## Scripts:

### PlayerController-> En este scripts es donde hacemos que el jugador se mueva con las teclas AWSD, además también implementamos la interfaz, donde mostramos las monedas que llevamos conseguidas y cuando llegamos al final nos indica que finalizamos el juego, también acumulamos las monedas y cuando entramos en contacto con un enemigo nos devuelve automaticamente al punto de inicio

```
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
```

### CameraController-> En este script es donde adaptamos la cámara, la distancia y que siga al jugador.

```
 void Start()
    {
        distancia = transform.position - jugador.transform.position;
    }
    
    void Update()
    {
        transform.position = jugador.transform.position + distancia;
    }
```

### RotadorMoneda-> En este script hacemos que la moneda gire.

```
void Update()
{
transform.Rotate(0, 0, velocidad * Time.deltaTime);
}
``` 
### PatrullaEnemigo-> En este script hacemos que los enemigos se muevan entre dos puntos que designamos mediante dos objetos vacíos.

```
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
```

<p><img align="left" src="https://github.com/AlejandroQuintaFarina/gifUnity/blob/main/20230316_141753_AdobeExpress.gif" widht="500" height="320" /></p>
<p><img align="left" src="https://github.com/AlejandroQuintaFarina/gifUnity/blob/main/20230316_183726_AdobeExpress.gif" widht="500" height="320" /></p>
