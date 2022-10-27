using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlacement : MonoBehaviour
{
    [SerializeField]
    private GameObject parentGameObject;

    [SerializeField]
    private GameObject barrackGameObject;
    [SerializeField]
    private GameObject powerPlantGameObject;
    [SerializeField]
    private GameObject headQuarterGameObject;


    [SerializeField]
    private GameObject _gridPlanesStockGameObject;


    private GameObject currentPlacingGameObject;

    private void Update()
    {
        if (!parentGameObject)
            Debug.Log("parent null");
    }

    public void BarrackPlacement()
    {
        if (currentPlacingGameObject == null)
        {
            if (barrackGameObject != null)
            {
                currentPlacingGameObject = Instantiate(barrackGameObject, parentGameObject.transform);
                Debug.Log("Instatiate Barrack");
            }
        }
    }

    public void PowerPlantPlacement()
    {
        if (currentPlacingGameObject == null)
        {
            if (powerPlantGameObject != null)
            {
                currentPlacingGameObject = Instantiate(powerPlantGameObject, parentGameObject.transform);
                Debug.Log("Instatiate Power Plant");
            }
        }
    }

    public void HeadQuarterPlacement()
    {
        if (currentPlacingGameObject == null)
        {
            if (headQuarterGameObject != null)
            {
                currentPlacingGameObject = Instantiate(headQuarterGameObject, parentGameObject.transform);
                Debug.Log("Instatiate Headquarter");
            }
        }
    }

}
