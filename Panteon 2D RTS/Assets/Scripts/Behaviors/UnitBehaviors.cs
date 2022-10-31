using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitBehaviors : MonoBehaviour//Unit informations initializations and controls
{
    [SerializeField]
    private GameObject _selectionCone;//Little cone indicate which unit is controlling currently

    [SerializeField]
    private Soldiers _soldiers;//soldier scriptable object 

    [SerializeField]
    private float _tileOffset;//tile offset for soldier pozisitons

    private Vector2 _target;//Target locations for units desired to reach locations

    private NavMeshAgent _agent;//Nav mesh agent for finding path to target

    private bool _selected;
    private bool _mouseOver;


    void Start()
    {
        Initialze();
    }

    private void Initialze()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;

        SetSelection(false);
    }

    void Update()
    {
        _agent.SetDestination(_target);//target point refresing for soldier
        _selectionCone.SetActive(_selected);
        if (!_mouseOver && _selected)//Control place to select and relocate soldiers.
        {
            if (Input.GetMouseButtonDown(0))
            {
                SetSelection(false);
            }
            if (Input.GetMouseButtonDown(1))
            {
                SetTarget((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition));
            }
        }
    }
    public void SetTarget(Vector2 target)//Changing target with  snaping to playable game tiles
    {
        Debug.Log("Target: " + target);
        Vector2 tmp = new Vector2(Mathf.RoundToInt(target.x) + (_tileOffset * (_soldiers.size.x % 2)), Mathf.RoundToInt(target.y) + (_tileOffset * (_soldiers.size.y % 2)));
        _target = target;
    }

    public void SetSelection(bool selected)//Chaning selection controller
    {
        _selected = selected;
    }

    private void OnMouseOver()//Single unit selection
    {
        _mouseOver = true;
        if (Input.GetMouseButtonDown(0) && !_selected)
        {
            SetSelection(true);
        }
    }
    private void OnMouseExit()
    {
        _mouseOver = false;
    }
}
