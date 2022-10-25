using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlacement : MonoBehaviour
{
    [SerializeField]
    private GameObject barrackGameObject;
    [SerializeField]
    private GameObject powerPlantGameObject;
    [SerializeField]
    private GameObject headQuarterGameObject;


    private GameObject currentPlacingGameObject;

    public void BarrackPlacement()
    {
        if (barrackGameObject != null)
            currentPlacingGameObject = Instantiate(barrackGameObject);
    }

    public void PowerPlantPlacement()
    {
        if (powerPlantGameObject != null)
            currentPlacingGameObject = Instantiate(powerPlantGameObject);
    }

    public void HeadQuarterPlacement()
    {
        if (headQuarterGameObject != null)
            currentPlacingGameObject = Instantiate(headQuarterGameObject);
    }

}
