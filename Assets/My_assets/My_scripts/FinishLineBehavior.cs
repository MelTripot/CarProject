using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinishLineBehavior : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPannel;
    [SerializeField] private TextMeshProUGUI Win;
    // Start is called before the first frame update
    private Collider2D finishline;
    public bool IsCrossable , isMovable = true ;
    public Vector2 size = new Vector2(1.64f, 1.43f);


    private void OnEnable() // quand l'object est activé 
    {
        finishline = this.gameObject.GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("IA")) 
        {
            if (IsCrossable == false)
            {
                Time.timeScale = 0;
                gameOverPannel.SetActive(true);
                if (collision.gameObject.CompareTag("Player")) {Win.text = "Win"; }
                if (collision.gameObject.CompareTag("IA")) {Win.text = "Lose"; } 
            }
            
            
        }
    }
}
