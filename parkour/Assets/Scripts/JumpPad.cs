using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public GameObject Player;
    // Zmienna przechowująca siłę skoku
    public float jumpForce = 10.0f;

    // Funkcja wywoływana, gdy gracz dotknie jump padu
    void OnTriggerEnter(Collider collision)
    {
        // Sprawdzamy, czy dotknięty obiekt jest graczem
        if (collision.gameObject == Player)
        {
            // Pobieramy komponent Rigidbody gracza
            Rigidbody playerRigidbody = collision.gameObject.GetComponent<Rigidbody>();

            // Ustawiamy siłę skoku na gracza
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}