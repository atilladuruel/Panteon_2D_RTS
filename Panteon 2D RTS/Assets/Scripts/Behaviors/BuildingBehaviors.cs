using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBehaviors : MonoBehaviour
{
    [SerializeField]
    private Buildings buildings;
    [SerializeField]
    private float _tileOffset;

    private bool _picked;

    private Vector2 _mousePosition;

    private List<GameObject> _collidedUnplayableGameObjects = new List<GameObject>();
    private List<GameObject> _collidedPlayableGameObjects = new List<GameObject>();

    void Start()
    {
        //Building object snap to mouse cursor at the creatin of building object
        _picked = true;
    }

    void Update()
    {
        if (_picked)//if Building object created or removed from own place its snaps to mouse cursor
        {
            _mousePosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(Mathf.RoundToInt(_mousePosition.x) + _tileOffset, Mathf.RoundToInt(_mousePosition.y) + _tileOffset);

            if (_collidedUnplayableGameObjects.Count == 0 && _collidedPlayableGameObjects.Count == (buildings.size.x * buildings.size.y))
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                { _picked = false; }
            }
        }


    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "UnplayableTile")
        {
            _collidedUnplayableGameObjects.Add(collider.gameObject);
            if (collider.GetComponent<SpriteRenderer>() != null)
            {
                collider.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0, 64);
            }
        }
        else if (collider.tag == "PlayableTile")
        {
            _collidedPlayableGameObjects.Add(collider.gameObject);
            if (collider.GetComponent<SpriteRenderer>() != null)
            {
                collider.GetComponent<SpriteRenderer>().color = new Color(0, 255, 0, 64);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Trigger Exit! : " + collision.name);

        if (collision.tag == "UnplayableTile")
        {
            _collidedUnplayableGameObjects.Remove(collision.gameObject);
            if (collision.GetComponent<SpriteRenderer>() != null)
            {
                Color tmp = Color.white;
                tmp.a = 64;
                collision.GetComponent<SpriteRenderer>().color = tmp;
            }
        }
        else if (collision.tag == "PlayableTile")
        {
            _collidedPlayableGameObjects.Remove(collision.gameObject);
            if (collision.GetComponent<SpriteRenderer>() != null)
            {
                collision.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 64);
            }
        }
    }

}
