using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadZoneBehavior : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPannel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) //TODO A faire pour l'ia aussi
        {
            gameOverPannel.SetActive(true);
            Time.timeScale = 0;
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
