using UnityEngine;

public class Monster : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        Pajaro pajaro = collision.gameObject.GetComponent<Pajaro>();

        
        bool meAplastaron = collision.contacts[0].normal.y < -0.5f;

       
        if (pajaro != null || meAplastaron)
        {
            Puntaje.instancia.SumarPuntos(100);
            Destroy(gameObject);
        }
    }
}