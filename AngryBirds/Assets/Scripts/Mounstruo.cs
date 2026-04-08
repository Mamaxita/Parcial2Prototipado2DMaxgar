using UnityEngine;

public class Monster : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 1. ¿Fue el pájaro?
        Pajaro pajaro = collision.gameObject.GetComponent<Pajaro>();

        // 2. ¿Le cayó algo encima? 
        // (Si el golpe viene de arriba, el valor es negativo)
        bool meAplastaron = collision.contacts[0].normal.y < -0.5f;

        // 3. Si pasó cualquiera de las dos cosas, el monstruo desaparece
        if (pajaro != null || meAplastaron)
        {
            Puntaje.instancia.SumarPuntos(100);
            Destroy(gameObject);
        }
    }
}