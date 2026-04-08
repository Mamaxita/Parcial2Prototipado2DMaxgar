using UnityEngine;
using TMPro;

public class Puntaje : MonoBehaviour
{
    
    public static Puntaje instancia;

    public TextMeshProUGUI textoDePuntos;
    private int puntosTotales = 0;

    void Awake()
    {
        
        instancia = this;
    }

    public void SumarPuntos(int cantidad)
    {
        puntosTotales += cantidad;

        
        if (textoDePuntos != null)
        {
            textoDePuntos.text = "Puntos: " + puntosTotales;
        }
    }
}