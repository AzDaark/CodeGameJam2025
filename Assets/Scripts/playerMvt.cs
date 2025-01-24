
/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class NewBehaviourScript : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal"); // recuperer quand le joueur appui sur les touches gauche et droite
        
        if (x < 0f )
        {
            rb.velocity = new Vector2(rb.velocity.x - speed*Time.deltaTime, rb.velocity.y); // assigner la position du joueur 
        }
        else if(x > 0f )
        {
            rb.velocity = new Vector2(rb.velocity.x + speed * Time.deltaTime, rb.velocity.y );// assigner la position du joueur 
        }
    }
}
*/
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float laneWidth = 2.0f; // Largeur entre les voies
    public int currentLane = 1; // Voie actuelle : 0 = gauche, 1 = milieu, 2 = droite
    public float transitionSpeed = 10f; // Vitesse de transition entre les voies

    private Vector3 targetPosition; // Position cible de la voiture

    void Start()
    {
        // Initialise la position cible au début
        targetPosition = transform.position;
    }

    void Update()
    {
        HandleInput();
        MoveToTargetLane();
    }

    void HandleInput()
    {
        // Vérifie si une touche fléchée est pressée
        if (Input.GetKeyDown(KeyCode.LeftArrow) && currentLane > 0)
        {
            currentLane--; // Déplace vers la voie de gauche
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && currentLane < 2)
        {
            currentLane++; // Déplace vers la voie de droite
        }

        // Calcule la position cible selon la voie actuelle
        targetPosition = new Vector3(currentLane * laneWidth - laneWidth, transform.position.y, transform.position.z);
    }

    void MoveToTargetLane()
    {
        // Déplace la voiture progressivement vers la position cible
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * transitionSpeed);
    }
}
