using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IABehavior : MonoBehaviour
{
    private Rigidbody2D rb ;     

    private float horizontalSpeed, verticalSpeed, Ralenti, Maxspeed;
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

    // Update is called once per frame
    void Update()
    {
        Deplacement();
    }


    private void Deplacement()
    {
        if (!isSlow)
        {
            //TODO Mouvement de l'ia 
        }
        else
        {
            rb.AddForce(new Vector2(Ralenti * Time.deltaTime, verticalMovement));
        }
    }

    public Rigidbody2D GetRigidbody() { return rb; }

    public void IASensor(List<GameObject> ObstacleList) // prise de désision de l'evitement en fonction de la position de objets 
    {
        if (ObstacleList[0].transform.position.x <= (rb.position.x + 8f) || ObstacleList[0].transform.position.x >= (rb.position.x +2.5f)) //Obstacle.X est devant l'ia.X a entre +2.5F et +8F 
        {
            // suite algo 
        }
    }

    public void Ralentissement()
    {
        isSlow = true;
        StartCoroutine(AccelDelay());
    }


    IEnumerator AccelDelay()
    {
        yield return new WaitForSeconds(1F);
        isSlow = false;
    }
}
