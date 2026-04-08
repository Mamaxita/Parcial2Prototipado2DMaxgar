using TMPro;
using UnityEngine;

public class MovimientoCamara : MonoBehaviour
{
    
    [SerializeField] private Transform pajaroTransform;

    
    [SerializeField] private float posicionLimiteX = 15f;

    private Vector3 posicionInicial;
    
    void Start()
    {
        
        posicionInicial = transform.position;
    }

    private void LateUpdate()
    {
        
        if (pajaroTransform.position.x > transform.position.x && transform.position.x < posicionLimiteX)
        {
            
            transform.position = new Vector3(pajaroTransform.position.x, transform.position.y, transform.position.z);
        }
    }

    
    public void ResetPosition()
    {
        transform.position = posicionInicial;
    }

    
}