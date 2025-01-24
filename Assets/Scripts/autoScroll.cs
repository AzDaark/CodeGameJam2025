using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoScroll : MonoBehaviour
{
<<<<<<< HEAD
    public float speed;
    Vector2 offset;
    
=======
    public float scrollSpeed = 5f; // Vitesse de défilement
    public float resetPosition = 20f; // Position où le fond revient au départ
    public float startPosition = 0f; // Position initiale du fond
>>>>>>> 5f869236d4719beddc85531ccc077a7f66ec11a3

    // Update is called once per frame
    private void Update()
    {
<<<<<<< HEAD
        offset = new Vector2(0,Time.time * speed) ;
        GetComponent<Renderer>().material.mainTextureOffset = offset;
=======
        // Déplacement vers le bas
        transform.Translate(Vector3.down * scrollSpeed * Time.deltaTime);

        // Réinitialisation de la position quand l'objet sort de l'écran
        if (transform.position.y <= -resetPosition)
        {
            transform.position = new Vector3(transform.position.x, startPosition, transform.position.z);
        }
>>>>>>> 5f869236d4719beddc85531ccc077a7f66ec11a3
    }
}
