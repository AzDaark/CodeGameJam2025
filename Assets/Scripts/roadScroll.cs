using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoScroll : MonoBehaviour
{
    public float scrollSpeed = 5f; // Vitesse de d�filement
    public float resetPosition = 20f; // Position o� le fond revient au d�part
    public float startPosition = 0f; // Position initiale du fond

    void Update()
    {
        // D�placement vers la gauche
        transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);

        // R�initialisation de la position quand l'objet sort de l'�cran
        if (transform.position.x <= -resetPosition)
        {
            transform.position = new Vector3(startPosition, transform.position.y, transform.position.z);
        }
    }
}
