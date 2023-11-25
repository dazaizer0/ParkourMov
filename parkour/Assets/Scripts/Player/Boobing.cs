using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boobing : MonoBehaviour
{
    public Transform playerCamera;
    public float bobbingSpeed = 1.5f;
    public float bobbingAmount = 0.05f;

    private float timer = 0f;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Sprawdź, czy postać jest w ruchu.
        if (Mathf.Abs(horizontalInput) > 0.1f || Mathf.Abs(verticalInput) > 0.1f)
        {
            // Oblicz efekt head bobbing.
            float wave = Mathf.Sin(timer);
            float bob = wave * bobbingAmount;

            // Modyfikuj pozycję kamery.
            playerCamera.localPosition = new Vector3(playerCamera.localPosition.x, bob, playerCamera.localPosition.z);

            // Aktualizuj timer na podstawie prędkości biegu.
            timer += bobbingSpeed * Time.deltaTime;

            // Ogranicz timer do zakresu 0-2π (jedna pełna fala sinusoidalna).
            if (timer > Mathf.PI * 2)
            {
                timer -= Mathf.PI * 2;
            }
        }
        else
        {
            // Jeśli postać nie jest w ruchu, zresetuj pozycję kamery.
            playerCamera.localPosition = new Vector3(playerCamera.localPosition.x, 0f, playerCamera.localPosition.z);
        }
    }

}
