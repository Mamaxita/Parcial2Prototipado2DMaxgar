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

        // Empezamos sin gravedad para que no se caiga
        rb.bodyType = RigidbodyType2D.Kinematic;

        ActualizarTexto();
    }

    private void OnMouseDrag()
    {
        // Si ya se lanzó o no hay tiros, no hacemos nada
        if (yaSeLanzo || tiros <= 0) return;

        // Convertir la posición del mouse al mundo del juego
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        // Limitar que tanto podemos estirar el resorte
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
        tiros--; // Quitamos un tiro
        ActualizarTexto();

        // Activamos la física para que salga volando
        rb.bodyType = RigidbodyType2D.Dynamic;

        // Calculamos la fuerza hacia el lado opuesto de donde jalamos
        Vector2 vectorFuerza = posicionInicial - (Vector2)transform.position;
        rb.AddForce(vectorFuerza * fuerza);

        // Esperamos 3 segundos para regresar
        Invoke("RegresarAlInicio", 5f);
    }

    void RegresarAlInicio()
    {
        // Si ya no hay tiros, el pájaro se queda ahí
        if (tiros <= 0) return;

        yaSeLanzo = false;

        // Reset de posición y velocidad
        transform.position = posicionInicial;
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;

        // Reset de la cámara (buscamos el script en la cámara principal)
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