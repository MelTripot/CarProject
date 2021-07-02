using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    private Collider2D finishline;
    public bool IsCrossable, isMovable = true ;
    public Vector2 size = new Vector2(1.64f, 1.43f);


    private void OnEnable() // quand l'object est activé 
    {
        finishline = this.gameObject.GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision) // Detecte la collision 
    {
        if (collision.gameObject.CompareTag("Player")) // si joueur
        {
           // TODO Win
        }
        if (collision.gameObject.CompareTag("IA")) // si IA 
        {
            // TODO LOSE
        }
    }
}
