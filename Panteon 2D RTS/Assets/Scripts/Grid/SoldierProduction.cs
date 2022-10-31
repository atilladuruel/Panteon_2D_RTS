using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierProduction : MonoBehaviour//Instantiate Soldier Playable objects from its prefab
{
    [SerializeField]
    private GameObject _generalPrefab;
    [SerializeField]
    private GameObject _InfantryPrefab;
    [SerializeField]
    private GameObject _specialForcePrefab;


    [SerializeField]
    private Transform _spawnPoint;//spawn point of soldiers every barrack has one spawn point for them self

    public void GeneralProduction()//General instantiation method
    {
        if (_generalPrefab != null)
        {
            GameObject unitParentGameObject = GameObject.FindGameObjectWithTag("Moveables");
            if (unitParentGameObject != null)
            {
                Transform tmpTransform = GetComponentInChildren<BuildingBehaviors>().gameObject.transform;
                GameObject tmp = Instantiate(_generalPrefab, tmpTransform.position, tmpTransform.rotation, unitParentGameObject.transform);
                if (tmp.GetComponentInChildren<UnitBehaviors>() != null)
                {
                    tmp.GetComponentInChildren<UnitBehaviors>().SetTarget(_spawnPoint.position);
                }
            }
        }
    }

    public void InfantryProduction()//Infantry soldier instantiation method
    {
        if (_InfantryPrefab != null)
        {
            GameObject unitParentGameObject = GameObject.FindGameObjectWithTag("Moveables");
            if (unitParentGameObject != null)
            {
                Transform tmpTransform = GetComponentInChildren<BuildingBehaviors>().gameObject.transform;
                GameObject tmp = Instantiate(_InfantryPrefab, tmpTransform.position, tmpTransform.rotation, unitParentGameObject.transform);
                if (tmp.GetComponentInChildren<UnitBehaviors>() != null)
                {
                    tmp.GetComponentInChildren<UnitBehaviors>().SetTarget(_spawnPoint.position);
                }
            }
        }
    }

    public void SpecialForceProduction()//Special Force instantiation method
    {
        if (_specialForcePrefab != null)
        {
            GameObject unitParentGameObject = GameObject.FindGameObjectWithTag("Moveables");
            if (unitParentGameObject != null)
            {
                Transform tmpTransform = GetComponentInChildren<BuildingBehaviors>().gameObject.transform;
                GameObject tmp = Instantiate(_specialForcePrefab, tmpTransform.position, tmpTransform.rotation, unitParentGameObject.transform);
                if (tmp.GetComponentInChildren<UnitBehaviors>() != null)
                {
                    tmp.GetComponentInChildren<UnitBehaviors>().SetTarget(_spawnPoint.position);
                }
            }
        }
    }

}
