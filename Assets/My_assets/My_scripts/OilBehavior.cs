﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilBehavior : MonoBehaviour
{
    
    private Collider2D oilCollider;
    private bool isHit;

    
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
            Debug.Log("ralenti");
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
        Debug.Log("TEST");
    }
    IEnumerator AccelDelay()
    {
        yield return new WaitForSeconds(1F);
        isHit = false;
        oilCollider.isTrigger = false;
    }


}
