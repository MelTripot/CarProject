using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamionBehavior : MonoBehaviour
{

    private Collider2D camionCollider;
    private const float force = 150000f; 
    void Start()
    {
        camionCollider = this.gameObject.GetComponent<BoxCollider2D>();
    }


    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) // Detecte la collision 
    {
        if (collision.gameObject.CompareTag("Player")) //TODO ouvrir cette fonction a l'ia ( && IA) 
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(-force * Time.deltaTime, 0f,0f));
            Debug.Log("hit");
        }
    }
}
