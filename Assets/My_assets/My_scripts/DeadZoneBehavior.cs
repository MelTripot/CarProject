using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DeadZoneBehavior : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPannel;
    [SerializeField] private TextMeshProUGUI Win;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("IA")) 
        {            
            Time.timeScale = 0;
            gameOverPannel.SetActive(true);
            if (collision.gameObject.CompareTag("Player")) {Win.text = "Lose"; }
            if (collision.gameObject.CompareTag("IA")) {Win.text = "Win"; }
            
        }
    }

    public void ResetButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void MenuButton()
    {
        //TODO retour vers le menu 
    }
}
