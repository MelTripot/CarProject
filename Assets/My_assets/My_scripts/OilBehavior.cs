using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilBehavior : MonoBehaviour
{
    
    private Collider2D oilCollider;
    private bool isHit;
    public Vector2 size = new Vector2(1.64f,1.43f);


    private void OnEnable() // quand l'object est activé 
    {
        oilCollider = this.gameObject.GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision) // Detecte la collision 
    {
        if (collision.gameObject.CompareTag("Player")) // si joueur
        {
            isHit = true;
            oilCollider.isTrigger = true;
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            player.Ralentissement();
            StartCoroutine(AccelDelay());
        }
        if (collision.gameObject.CompareTag("IA")) // si IA 
        {
            isHit = true;
            oilCollider.isTrigger = true;
            IABehavior ia = collision.gameObject.GetComponent<IABehavior>();
            ia.Ralentissement();
            StartCoroutine(AccelDelay());
            // TODO comportement de l'ia en cas de collision
        }
    }
    IEnumerator AccelDelay()
    {
        yield return new WaitForSeconds(1F);
        isHit = false;
        oilCollider.isTrigger = false;
    }


}
