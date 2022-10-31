using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSController : MonoBehaviour //Player controls in RTS game like selecting objects
{
    [SerializeField]
    private Transform _selectionAreaTransform;//Background of the box selection
    private Vector2 _beginningPosition;//First clicked position
    private Vector2 _mousePosition;//Current mouse position
    private List<UnitBehaviors> _selectedUnits; //Selected objects

    private void Awake()
    {//Initializations
        _selectedUnits = new List<UnitBehaviors>();
        _selectionAreaTransform.gameObject.SetActive(false);
    }

    private void Update()
    {
        _mousePosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        SquareChoose();
    }

    private void SquareChoose()
    {//Resizeing box method that selects game object which stays in box
        if (Input.GetMouseButtonDown(0))
        {
            _selectionAreaTransform.gameObject.SetActive(true);
            _beginningPosition = _mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            _selectionAreaTransform.position = _beginningPosition;
            _selectionAreaTransform.localScale = _mousePosition - _beginningPosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            _selectionAreaTransform.gameObject.SetActive(false);
            _selectedUnits.Clear();
            Collider2D[] selectedObjects = Physics2D.OverlapAreaAll(_beginningPosition, _mousePosition);
            foreach (Collider2D obj in selectedObjects)
            {
                Debug.Log(obj.name + " Choosed");
                UnitBehaviors unit = obj.GetComponent<UnitBehaviors>();
                if (unit != null)
                {
                    unit.SetSelection(true);
                    _selectedUnits.Add(unit);
                }
            }
        }
    }
}
