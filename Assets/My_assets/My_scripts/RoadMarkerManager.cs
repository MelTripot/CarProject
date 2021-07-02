using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMarkerManager : MonoBehaviour
{
    public float movementSpeed;

    [SerializeField] private GameObject maker;
    [SerializeField] private GameObject FinishLine;
    private Vector3 startPosition;
    void Start()
    {
        startPosition = new Vector3(12f, 1.5f, 0f);
        InstantiateMarker();
        movementSpeed = 10f;
    }

    void Update()
    {
        MoveMarker();
    }
    // Instancie les marker 
    private void InstantiateMarker()
    {
        float offset = -8f;
        for (int i = 0; i < 6; i++)
        {
            //TOP 
            GameObject currentMarkerTop = Instantiate(maker, startPosition, Quaternion.identity, this.gameObject.transform);
            currentMarkerTop.name = "MarkerTop_" + i;
            currentMarkerTop.transform.position = new Vector3(offset + i*4f, 1.5f, 0f);
            //BOTTOM
            GameObject currentMarkerBottom = Instantiate(maker, startPosition, Quaternion.identity, this.gameObject.transform);
            currentMarkerBottom.name = "MarkerBottom_" + i;
            currentMarkerBottom.transform.position = new Vector3(offset + i*4f, -1.5f, 0f);
            
        }

    }

    private void MoveMarker()
    {
        for (int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            Transform currentMarker = this.gameObject.transform.GetChild(i).transform;
            float currentPositionX = currentMarker.localPosition.x;
            float currentPositionY = currentMarker.localPosition.y;
            currentMarker.localPosition = new Vector3(currentPositionX - movementSpeed * Time.deltaTime, currentPositionY, 0f);
            // remet les marker sortie en position de départ 
            if(currentMarker.localPosition.x <= -12f)
            {
                currentMarker.localPosition = new Vector3(startPosition.x, currentPositionY, 0f);
            }
        }
    }
}
