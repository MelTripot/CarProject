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
    private Vector3[] lane = new Vector3[3]; // les differentes position possible sur la route 

    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>(); // assigner la variable rb au rigidbody du joueur
        Maxspeed = 4200f;
        Ralenti = -2100f;
        horizontalSpeed = Maxspeed;
        verticalSpeed = 6000f;
        playerSize = new Vector2(2.4f, 1.4f); // distence entre le centre et les bords du vehicule 

        lane[0] = new Vector3(12f, 2.9f, 1.5f);// les differentes voies de circulation ici z correspond a la moitiée de la largeur d'une ligne 
        lane[1] = new Vector3(12f, 0f, 1.5f);// les differentes voies de circulation
        lane[2] = new Vector3(12f, -2.9f, 1.5f);// les differentes voies de circulation
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

    public void IASensor(List<GameObject> ObstacleList) // prise de décision de l'evitement en fonction de la position de objets 
    {
        foreach (var obstacle in ObstacleList)
        {
            if (obstacle.transform.position.x <= (rb.position.x + 8f) || obstacle.transform.position.x >= (rb.position.x + playerSize.x)) //Obstacle.X est devant l'ia.X a entre +2.5F et +8F 
            {
                if (obstacle.transform.position.y <= (rb.position.y + playerSize.y) || obstacle.transform.position.y >= (rb.position.y - playerSize.y)) //l'obstacle est sur la meme voie que l IA 
                {
                    if (obstacle.transform.position.x < (lane[0].x + lane[0].z) || obstacle.transform.position.x > (lane[0].x - lane[0].z)) //l'ia est sur la voie du haut
                    {
                        //TODO  il y a pas n'obstacle au milieux au niveau de la voiture 
                    }
                    else if (obstacle.transform.position.x < (lane[2].x + lane[2].z) || obstacle.transform.position.x > (lane[2].x - lane[2].z))//l'ia est sur la voie du bas
                    {
                        //TODO  il y a pas n'obstacle au milieux au niveau de la voiture 
                    }
                    else if (obstacle.transform.position.x < (lane[1].x + lane[1].z) || obstacle.transform.position.x > (lane[1].x - lane[1].z))//l'ia est sur la voie du Millieu
                    {
                        //TODO il y a pas n'obstacle sur la voie du haut au niveau de la voiture
                        //TODO il y a pas n'obstacle sur la voie du bas au niveau de la voiture 
                    }
                }//else ne rien faire 
            }//else ne rien faire 
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
