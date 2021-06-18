using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabs;

    private float spawnDelay;
    private int maxPropsCount;
    private int currentPropsCount;
    private Vector3[] startPositions = new Vector3[3];

    private GameObject[,] props = new GameObject[3,3];
    private float movementSpeed;

    void Start()
    {
        //delai de 3s entre chaque spawn 
        spawnDelay = 0.5f;
        maxPropsCount = 6;
        movementSpeed = 10f;
        // Possition des lignes 
        startPositions[0] = new Vector3(12f, 2.9f, 0f);
        startPositions[1] = new Vector3(12f, 0f, 0f);
        startPositions[2] = new Vector3(12f, -2.9f, 0f);

        InstantiateProps();
    }
     
    void Update()
    {
        MoveProps();
        RandomizePropsActivation();
    }

    private void InstantiateProps()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                GameObject currentProp = Instantiate(prefabs[i], startPositions[j], prefabs[i].transform.rotation, this.gameObject.transform);
                props[i, j] = currentProp;
                currentProp.name += "_" + j;
                currentProp.SetActive(false);
            }
        }
    }

    private void MoveProps()
    {
        for (int i = 0; i < this.gameObject.transform.childCount; i++) //parcourir tous les enfants du transform actuel
        {
            if(this.gameObject.transform.GetChild(i).gameObject.activeSelf) // si l'enfant est actif dans la scène
            {
                Transform currentProp = this.gameObject.transform.GetChild(i).transform;
                float currentPositionX = currentProp.localPosition.x;
                float currentPositionY = currentProp.localPosition.y;
                currentProp.localPosition = new Vector3(currentPositionX - movementSpeed * Time.deltaTime, currentPositionY, 0f);
                
                if (currentProp.localPosition.x <= -12f)
                {
                    string name = this.gameObject.transform.GetChild(i).name;
                    string subName = (name.Substring(name.Length - 1));
                    int xValue = int.Parse(subName);
                    
                    currentProp.localPosition = new Vector3(startPositions[xValue].x, currentPositionY, 0f);
                    if (currentProp.gameObject.name.Contains("Cone"))
                    {
                        currentProp.gameObject.GetComponent<ConeBehavior>().isHit = false; // remet le cone a son etats initial 
                        currentProp.gameObject.GetComponent<Collider2D>().isTrigger = false;
                    }
                    currentProp.gameObject.SetActive(false);
                    currentPropsCount -= 1;
                }
            }
        }
    }

    private void RandomizePropsActivation()
    {
        if(spawnDelay > 0)
        {
            //Verifie s'il reste du temps 
            spawnDelay -= Time.deltaTime;
        }
        else 
        {
            if (currentPropsCount <= maxPropsCount)
            {
                spawnDelay = Random.Range(0.5f, 3f); 
                int i = Random.Range(0, 3);
                int j = Random.Range(0, 3);
                props[i, j].SetActive(true);
                currentPropsCount += 1;
            }
                

        }
    }
}
