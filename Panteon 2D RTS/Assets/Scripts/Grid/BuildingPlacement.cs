using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlacement : MonoBehaviour //Cloning objects and placing in game.
{

    [SerializeField]
    private GameObject _barrackGameObject;//Game object holds barrack prefab game object
    [SerializeField]
    private GameObject _powerPlantGameObject;//Power plant prefab
    [SerializeField]
    private GameObject _headQuarterGameObject;//Head quarter prefab


    [SerializeField]
    private GameObject _gridPlanesStockGameObject;//Parent object of panels that represent places where the player can or cannot play


    private GameObject _currentPlacingGameObject;//Currently placing building if there is one

    private void Start()
    {
        _gridPlanesStockGameObject.SetActive(false);//deactive planes at the start
    }


    public void BarrackPlacement()//Barack Instantiation 
    {
        if (_currentPlacingGameObject == null)
        {
            if (_barrackGameObject != null)
            {
                _gridPlanesStockGameObject.SetActive(true);
                _currentPlacingGameObject = Instantiate(_barrackGameObject, transform);
            }
        }
    }

    public void PowerPlantPlacement()//Power Plant instantiation
    {
        if (_currentPlacingGameObject == null)
        {
            if (_powerPlantGameObject != null)
            {
                _gridPlanesStockGameObject.SetActive(true);
                _currentPlacingGameObject = Instantiate(_powerPlantGameObject, transform);
            }
        }
    }

    public void HeadQuarterPlacement()//Headquarter instantiation
    {
        if (_currentPlacingGameObject == null)
        {
            if (_headQuarterGameObject != null)
            {
                _gridPlanesStockGameObject.SetActive(true);
                _currentPlacingGameObject = Instantiate(_headQuarterGameObject, transform);
            }
        }
    }

    public void DoneAndCancelPlacement()//Control after building placement is completed or cancelled
    {
        if (_currentPlacingGameObject != null)
        {
            _gridPlanesStockGameObject.SetActive(false);
            _currentPlacingGameObject = null;
        }
    }

}
