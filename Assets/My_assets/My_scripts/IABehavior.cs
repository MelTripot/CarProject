using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IABehavior : MonoBehaviour
{
    private Rigidbody2D rb ;     

    private float horizontalSpeed, verticalSpeed, Ralenti, Maxspeed;
    private float horizontalMovement, verticalMovement;
    private bool isSlow = false;
    private bool isMoving = false;
    private Vector2 playerSize;
    private Vector3[] lane = new Vector3[3]; // les differentes position possible sur la route 


    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>(); // assigner la variable rb au rigidbody du joueur
        Maxspeed = 4200f;
        Ralenti = -2100f;
        horizontalSpeed = Maxspeed * 4F ;
        verticalSpeed = 0f;
        playerSize = new Vector2(2.4f, 1.4f); // distence entre le centre et les bords du vehicule 

        lane[0] = new Vector3(12f, 2.9f, 1.5f);// les differentes voies de circulation ici z correspond a la moitiée de la largeur d'une ligne 
        lane[1] = new Vector3(12f, 0f, 1.5f);// les differentes voies de circulation
        lane[2] = new Vector3(12f, -2.9f, 1.5f);// les differentes voies de circulation
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Deplacement(List<GameObject> ObstacleList)
    {
        if (!isSlow)
        {
            IASensor(ObstacleList);
            //TODO Mouvement de l'ia 
        }
        else
        {
            rb.AddForce(new Vector2(Ralenti * Time.deltaTime, verticalMovement));
        }
    }

    private void Move(string choice)
    {
        isMoving = true;
        Debug.Log("move");
        switch (choice)
        {
            case "up":
                Debug.Log("CAS O");
                rb.AddForce(new Vector2(0f, horizontalSpeed * Time.deltaTime));
                break;

            case "down":
                Debug.Log("CAS 1");
                rb.AddForce(new Vector2(0f, -horizontalSpeed * Time.deltaTime));
                break;

            default:
                break;
        }

        //rb.AddForce(new Vector2(0f, horizontalSpeed * Time.deltaTime));
        //rb.position = new Vector2(rb.position.x, lane[choice].y);
        isMoving = false;
        //rb.position = (new Vector2(horizontalMovement, verticalMovement));
        //rb.AddForce(new Vector2(horizontalMovement, verticalMovement));
    }

    private void IASensor(List<GameObject> ObstacleList) // prise de décision de l'evitement en fonction de la position de objets 
    {
        if (!isMoving)
        {
            foreach (var obstacle in ObstacleList)
            {
                if (obstacle.transform.position.x <= (rb.position.x + 8f) && obstacle.transform.position.x >= (rb.position.x + playerSize.x)) //Obstacle.X est devant l'ia.X a entre +2.5F et +8F 
                {
                    if (obstacle.transform.position.y <= (rb.position.y + playerSize.y) && obstacle.transform.position.y >= (rb.position.y - playerSize.y)) //l'obstacle est sur la meme voie que l IA 
                    {
                        if (obstacle.transform.position.y < (lane[0].y + lane[0].z) && obstacle.transform.position.y > (lane[0].y - lane[0].z)) //l'ia est sur la voie du haut
                        {
                            if (!((obstacle.transform.position.y < (lane[1].y + lane[1].z) && obstacle.transform.position.y > (lane[1].y - lane[1].z)) &&
                                ((obstacle.transform.position.x <= (rb.position.x + playerSize.x)) && (obstacle.transform.position.x >= (rb.position.x - playerSize.y))))) //il y a pas n'obstacle au milieux au niveau de la voiture 
                            {
                                Debug.Log("ah");
                                Move("down");// IA va sur la ligne du milieux
                            }

                        }
                        if (obstacle.transform.position.y < (lane[2].y + lane[2].z) && obstacle.transform.position.y > (lane[2].y - lane[2].z))//l'ia est sur la voie du bas
                        {
                            if (!((obstacle.transform.position.y < (lane[1].y + lane[1].z) && obstacle.transform.position.y > (lane[1].y - lane[1].z)) &&
                                ((obstacle.transform.position.x <= (rb.position.x + playerSize.x)) && (obstacle.transform.position.x >= (rb.position.x - playerSize.y))))) //il y a pas n'obstacle au milieux au niveau de la voiture 
                            {
                                Debug.Log("B");
                                Move("up");// IA va sur la ligne du milieux
                            }
                        }
                        if (obstacle.transform.position.y < (lane[1].y + lane[1].z) && obstacle.transform.position.y > (lane[1].y - lane[1].z))//l'ia est sur la voie du Millieu
                        {
                            if (!((obstacle.transform.position.y < (lane[0].y + lane[0].z) && obstacle.transform.position.y > (lane[0].y - lane[0].z)) &&
                                ((obstacle.transform.position.x <= (rb.position.x + playerSize.x)) && (obstacle.transform.position.x >= (rb.position.x - playerSize.y))))) //TODO il y a pas n'obstacle sur la voie du haut au niveau de la voiture
                            {
                                Debug.Log("C");
                                Move("up");// IA va sur la ligne du haut
                            }
                            else if (!((obstacle.transform.position.y < (lane[2].y + lane[2].z) && obstacle.transform.position.y > (lane[2].y - lane[2].z)) &&
                                ((obstacle.transform.position.x <= (rb.position.x + playerSize.x)) && (obstacle.transform.position.x >= (rb.position.x - playerSize.y))))) //TODO il y a pas n'obstacle sur la voie du bas au niveau de la voiture 
                            {
                                Debug.Log("D");
                                Move("down");// IA va sur la ligne du bas
                            }

                        }
                    }//else ne rien faire 
                }//else ne rien faire 
            }
        }
        
        
    }

    private bool WillCollide(Rigidbody2D rb, GameObject Ob) // me permet de determiner si mes deux objet vont collider
    {
        // determiner les extremitées 
        Vector2 Vectonull = new Vector2(0, 0);
        Vector2 IaWidth = new Vector2((rb.position.x - playerSize.x), (rb.position.x + playerSize.x)); // vecteur X extrémité droite, Y gauche
        Vector2 ObWidth = Vectonull;
        // si ob = cone 
        if (Ob.name.Contains("Cone")){
            ObWidth = new Vector2((Ob.transform.position.x - Ob.GetComponent<ConeBehavior>().size.x), (Ob.transform.position.x + playerSize.x));
        }
        // si ob = oil 
        if (Ob.name.Contains("oil")){
            ObWidth = new Vector2((Ob.transform.position.x - Ob.GetComponent<OilBehavior>().size.x), (Ob.transform.position.x + playerSize.x));
        }
        // si ob = camion 
        if (Ob.name.Contains("Truck")){
            ObWidth = new Vector2((Ob.transform.position.x - Ob.GetComponent<CamionBehavior>().size.x), (Ob.transform.position.x + playerSize.x));
        }
        if (ObWidth != Vectonull)
        {
            // regarde si les objets vont se chevaucher 
            if ((IaWidth.x >= ObWidth.x && IaWidth.x <= ObWidth.y) || //le point le plus a gauche de Ia ext entre les extremités de l'obstacle 
                (IaWidth.y >= ObWidth.x && IaWidth.y <= ObWidth.y)) //le point le plus a droite de Ia ext entre les extremités de l'obstacle 
            {
                return true;
            }
            else { return false; }
        }
        else return false;        
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
