using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBehaviors : MonoBehaviour//Managing behaviors of buildings in building prefab
{

    [SerializeField]
    private Buildings _buildings;//Scriptable object referance that keeps building informations
    [SerializeField]
    private float _tileOffset;//Offset of tile pivot point locations

    private bool _picked;//Controller of buildings if its picked

    private Vector2 _mousePosition;//Mouse world position

    private List<GameObject> _collidedUnplayableGameObjects = new List<GameObject>();//Collided Unplayable Planes to building object while placing objects
    private List<GameObject> _collidedPlayableGameObjects = new List<GameObject>();//Collided Playable Planes to building object while placing objects

    void Start()
    {
        //Building object snap to mouse cursor at the creatin of building object
        _picked = true;

        //Assigning Building specs
        transform.parent.transform.localScale = _buildings.size;
    }

    void Update()
    {
        if (_picked)//if Building object created or removed from own place its snaps to mouse cursor
        {
            _mousePosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(Mathf.RoundToInt(_mousePosition.x) + (_tileOffset * (_buildings.size.x % 2)), Mathf.RoundToInt(_mousePosition.y) + (_tileOffset * (_buildings.size.y % 2)));


            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                //Placing Building with Left mouse click
                if (_collidedUnplayableGameObjects.Count == 0 && _collidedPlayableGameObjects.Count == (_buildings.size.x * _buildings.size.y))
                {
                    _picked = false;
                    GetComponent<BoxCollider2D>().isTrigger = true;
                    foreach (GameObject tmp in _collidedPlayableGameObjects)
                    {
                        tmp.tag = ChangeTileTag(tmp.tag);
                    }
                    GetComponentInParent<BuildingPlacement>().DoneAndCancelPlacement();
                }
            }
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                //Cancel placing building with right mouse click
                Destroy(gameObject);
                GetComponentInParent<BuildingPlacement>().DoneAndCancelPlacement();
            }
        }


    }


    private void OnTriggerEnter2D(Collider2D collider)//To represent player playable and unplayable grids of game surface by changing plane colors
    {
        if (collider.tag == "UnplayableTile")
        {
            _collidedUnplayableGameObjects.Add(collider.gameObject);
            if (collider.GetComponent<SpriteRenderer>() != null)
            {
                Color tmp = Color.red;
                tmp.a = 0.25f;
                collider.GetComponent<SpriteRenderer>().color = tmp;
            }
        }
        else if (collider.tag == "PlayableTile")
        {
            _collidedPlayableGameObjects.Add(collider.gameObject);
            if (collider.GetComponent<SpriteRenderer>() != null)
            {
                Color tmp = Color.green;
                tmp.a = 0.25f;
                collider.GetComponent<SpriteRenderer>().color = tmp;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)//After changing plane colors turn back its own color and alpha value
    {
        if (collision.tag == "UnplayableTile")
        {
            _collidedUnplayableGameObjects.Remove(collision.gameObject);
            if (collision.GetComponent<SpriteRenderer>() != null)
            {
                Color tmp = Color.white;
                tmp.a = 0.25f;
                collision.GetComponent<SpriteRenderer>().color = tmp;
            }
        }
        else if (collision.tag == "PlayableTile")
        {
            _collidedPlayableGameObjects.Remove(collision.gameObject);
            if (collision.GetComponent<SpriteRenderer>() != null)
            {
                Color tmp = Color.white;
                tmp.a = 0.25f;
                collision.GetComponent<SpriteRenderer>().color = tmp;
            }
        }
    }

    private void OnMouseOver()//Trigger the informative manu panel witk buildings informations
    {
        if (Input.GetMouseButtonDown(0) && !_picked)
        {
            UIController.instance.InformativeMenuSlideController(_buildings);
        }
    }

    private string ChangeTileTag(string tag)//This method used for changing tile tag by using a method and avoiding miss typing of tag in the code.
    { return tag == "UnplayableTile" ? "PlayableTile" : "UnplayableTile"; }

}
