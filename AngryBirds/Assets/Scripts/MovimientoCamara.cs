using TMPro;
using UnityEngine;

public class MovimientoCamara : MonoBehaviour
{
    // Arrastra al pájaro aquí en el Inspector
    [SerializeField] private Transform pajaroTransform;

    // El punto máximo donde la cámara dejará de seguir al pájaro
    [SerializeField] private float posicionLimiteX = 15f;

    private Vector3 posicionInicial;
    
    void Start()
    {
        // Guardamos donde empieza la cámara para poder regresar
        posicionInicial = transform.position;
    }

    private void LateUpdate()
    {
        // Solo seguimos al pájaro si:
        // 1. El pájaro va más adelante que la cámara
        // 2. La cámara no ha pasado el límite
        if (pajaroTransform.position.x > transform.position.x && transform.position.x < posicionLimiteX)
        {
            // Movemos la cámara solo en el eje X, dejando Y y Z igual
            transform.position = new Vector3(pajaroTransform.position.x, transform.position.y, transform.position.z);
        }
    }

    // Esta es la función que llama el pájaro para resetear todo
    public void ResetPosition()
    {
        transform.position = posicionInicial;
    }

    
}