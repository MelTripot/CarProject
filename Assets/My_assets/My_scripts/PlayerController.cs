using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    private float horizontalSpeed, verticalSpeed , Ralenti, Maxspeed;
    private float horizontalMovement, verticalMovement;
    private bool isSlow = false;

    private Vector2 playerSize;

    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>(); // assigner la variable rb au rigidbody du joueur
        Maxspeed = 4200f;
        Ralenti = -2100f;
        horizontalSpeed = Maxspeed;
        verticalSpeed = 6000f;

        playerSize = new Vector2(2.4f, 1.4f);
    }

    void Update()
    {
        PlayerInput();
        
    }

    private void PlayerInput()
    {
        if (!isSlow)
        {
            //if (this.gameObject.transform.position.x - playerSize.x / 2 <= -8f && Input.GetAxis("Horizontal") < 0)
            //{
            //    horizontalMovement = 0f;
            //}
            //else if (this.gameObject.transform.position.x + playerSize.x / 2 >= 0f && Input.GetAxis("Horizontal") > 0)
            //{
            //    horizontalMovement = 0f;
            //}
            //else
            //{
            //    horizontalMovement = Input.GetAxis("Horizontal") * horizontalSpeed * Time.deltaTime;
            //}
            verticalMovement = Input.GetAxis("Vertical") * verticalSpeed * Time.deltaTime;
            rb.AddForce(new Vector2(horizontalMovement, verticalMovement));
        }
        else
        {
            rb.AddForce(new Vector2(Ralenti * Time.deltaTime, verticalMovement));
        }
        
    }

    public void Ralentissement()
    {
        isSlow = true;
        //horizontalSpeed = Ralenti;
        StartCoroutine(AccelDelay());
    }

    IEnumerator AccelDelay()
    {
        yield return new WaitForSeconds(1F);
        //rb.velocity = Vector2.zero;
        //horizontalSpeed = Maxspeed;
        isSlow = false;
    }
}
