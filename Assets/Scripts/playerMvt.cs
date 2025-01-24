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
