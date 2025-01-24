using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoScroll : MonoBehaviour
{
    public float scrollSpeed = 5f; // Vitesse de défilement
    public float resetPosition = 20f; // Position où le fond revient au départ
    public float startPosition = 0f; // Position initiale du fond

    void Update()
    {
        // Déplacement vers le bas
        transform.Translate(Vector3.down * scrollSpeed * Time.deltaTime);

        // Réinitialisation de la position quand l'objet sort de l'écran
        if (transform.position.y <= -resetPosition)
        {
            transform.position = new Vector3(transform.position.x, startPosition, transform.position.z);
        }
    }
}
