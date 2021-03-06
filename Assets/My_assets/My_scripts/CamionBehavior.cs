using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamionBehavior : MonoBehaviour
{

    private Collider2D camionCollider;
    private const float force = 150000f;
    public Vector2 size = new Vector2(2.83f, 1.23f);
    void Start()
    {
        camionCollider = this.gameObject.GetComponent<BoxCollider2D>();        
    }


    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) // Detecte la collision 
    {
        if (collision.gameObject.CompareTag("Player")|| collision.gameObject.CompareTag("IA")) 
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(-force * Time.deltaTime, 0f,0f));
        }
    }
}
