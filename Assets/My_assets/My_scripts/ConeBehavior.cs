using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeBehavior : MonoBehaviour
{
    public bool isHit;

    [SerializeField] private Sprite[] spriteArray;   
    private SpriteRenderer spriteRenderer;

    private Collider2D coneCollider;

    private void OnEnable() // quand l'object est activé 
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        coneCollider = this.gameObject.GetComponent<BoxCollider2D>();
        SwitchSprite();
    }
    //void Start()
    //{
        
    //}

    private void SwitchSprite()
    {
        if(isHit)
        {
            spriteRenderer.sprite = spriteArray[1];
        }
        else
        {
            spriteRenderer.sprite = spriteArray[0];
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) // Detecte la collision 
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("IA")) 
        {
            isHit = true;
            coneCollider.isTrigger = true;
            SwitchSprite();
        }
    }
}
