using TMPro;
using UnityEngine;

public class Pajaro : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 posicionInicial;
    public TextMeshProUGUI textoUI;
    int contadorTiros = 0;

    [SerializeField] private float fuerza = 350f;
    [SerializeField] private float distanciaMaxima = 3f;
    [SerializeField] private int tiros = 3;

    public TextMeshProUGUI textoTiros;
    private bool yaSeLanzo = false;
   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        posicionInicial = transform.position;

        
        rb.bodyType = RigidbodyType2D.Kinematic;

        ActualizarTexto();
    }

    private void OnMouseDrag()
    {
       
        if (yaSeLanzo || tiros <= 0) return;

       
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        
        if (Vector2.Distance(mousePos, posicionInicial) > distanciaMaxima)
        {
            Vector2 direccion = ((Vector2)mousePos - posicionInicial).normalized;
            transform.position = posicionInicial + (direccion * distanciaMaxima);
        }
        else
        {
            transform.position = mousePos;
        }
    }

    private void OnMouseUp()
    {
        if (yaSeLanzo || tiros <= 0) return;

        yaSeLanzo = true;
        tiros--; 
        ActualizarTexto();

       
        rb.bodyType = RigidbodyType2D.Dynamic;

       
        Vector2 vectorFuerza = posicionInicial - (Vector2)transform.position;
        rb.AddForce(vectorFuerza * fuerza);

        
        Invoke("RegresarAlInicio", 5f);
    }

    void RegresarAlInicio()
    {
       
        if (tiros <= 0) return;

        yaSeLanzo = false;

       
        transform.position = posicionInicial;
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;

       
        Camera.main.GetComponent<MovimientoCamara>().ResetPosition();
    }

    void ActualizarTexto()
    {
        if (textoTiros != null)
        {
            textoTiros.text = "Tiros: " + tiros;
        }
    }

    void ContarNuevoGolpe()
    {
        contadorTiros = contadorTiros - 1;
        textoUI.text = "Golpes: " + contadorTiros;
    }
}