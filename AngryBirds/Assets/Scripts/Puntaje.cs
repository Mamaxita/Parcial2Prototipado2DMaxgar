using UnityEngine;
using TMPro;

public class Puntaje : MonoBehaviour
{
    // Esto es para que los monstruos puedan encontrar esta "caja" fácilmente
    public static Puntaje instancia;

    public TextMeshProUGUI textoDePuntos;
    private int puntosTotales = 0;

    void Awake()
    {
        // Al empezar el juego, esta es la instancia principal
        instancia = this;
    }

    public void SumarPuntos(int cantidad)
    {
        puntosTotales += cantidad;

        // Actualizamos lo que dice el texto en la pantalla
        if (textoDePuntos != null)
        {
            textoDePuntos.text = "Puntos: " + puntosTotales;
        }
    }
}