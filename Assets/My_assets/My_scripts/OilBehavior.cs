using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilBehavior : MonoBehaviour
{
    
    private Collider2D oilCollider;
    private bool isHit;

    //private void OnTriggerEnter(Collider collision) // Detecte la collision 
    //{
    //    if (collision.gameObject.CompareTag("Player")) //TODO ouvrir cette fonction a l'ia ( && IA) 
    //    {
    //        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(-F * Time.deltaTime, 0f, 0f));
    //        Debug.Log("ralenti");
    //    }
    //    Debug.Log("TEST");
    //}
    private void OnEnable() // quand l'object est activé 
    {
        oilCollider = this.gameObject.GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision) // Detecte la collision 
    {
        if (collision.gameObject.CompareTag("Player")) //TODO ouvrir cette fonction a l'ia ( && IA) 
        {
            isHit = true;
            oilCollider.isTrigger = true;
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            player.Ralentissement();
            StartCoroutine(AccelDelay());
            //collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(-F * Time.deltaTime, 0f, 0f));
            //collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(-F * Time.deltaTime, 0f, 0f));
            Debug.Log("ralenti");
        }
        Debug.Log("TEST");
    }
    IEnumerator AccelDelay()
    {
        yield return new WaitForSeconds(1F);
        isHit = false;
        oilCollider.isTrigger = false;
    }


}
