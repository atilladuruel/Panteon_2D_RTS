using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance { get; private set; }//Singleton pattern created for using some methods out of this script

    [SerializeField]
    private GameObject _productionMenuGameObject;
    [SerializeField]
    private GameObject _informativeMenuGameObject;
    [SerializeField]
    private Text _informativeItemTitle;
    [SerializeField]
    private Image _informativeItemImage;
    [SerializeField]
    private GameObject _productScrollContentGameObject;
    [SerializeField]
    private GameObject _productButtonPrefab;

    private bool _productionMenuOpened;
    private bool _informativeMenuOpened;

    private void Awake()
    {
        if (instance != null && instance != this)//If there is an instance already created, it will be destroyed here
        {
            Destroy(this);
            return;
        }
        instance = this;
        ContollerInitialize();
    }


    private void ContollerInitialize()//Initialize animation controller in controller class
    {
        if (_productionMenuGameObject != null)
        {
            Animator animator = _productionMenuGameObject.GetComponent<Animator>();
            if (animator != null)
            {
                _productionMenuOpened = animator.GetBool("IsOpen");
            }
        }

        if (_informativeMenuGameObject != null)
        {
            Animator animator = _informativeMenuGameObject.GetComponent<Animator>();
            if (animator != null)
            {
                _informativeMenuOpened = animator.GetBool("IsOpen");
            }
        }
    }

    public void ProductionMenuSlideController()//Shows and hides Production menu due to its own animation
    {
        if (_productionMenuGameObject != null)
        {
            Animator animator = _productionMenuGameObject.GetComponent<Animator>();
            if (animator != null)
            {
                _productionMenuOpened = !animator.GetBool("IsOpen");
                animator.SetBool("IsOpen", _productionMenuOpened);
            }
        }
    }

    public void InformativeMenuSlideController()//Just Basic Open and Close Method For Informative Menu Animation
    {
        if (_informativeMenuGameObject != null)
        {
            Animator animator = _informativeMenuGameObject.GetComponent<Animator>();
            if (animator != null)
            {
                _informativeMenuOpened = !animator.GetBool("IsOpen");
                animator.SetBool("IsOpen", _informativeMenuOpened);
                if (!_informativeMenuOpened)
                {
                    _productScrollContentGameObject.SetActive(false);

                }
            }
        }
    }
    public void InformativeMenuSlideController(Buildings buildings)//Informative Panel Animation with Specification Assignment
    {
        if (_informativeMenuGameObject != null)
        {
            Animator animator = _informativeMenuGameObject.GetComponent<Animator>();
            if (animator != null)
            {
                _informativeMenuOpened = !animator.GetBool("IsOpen");
                animator.SetBool("IsOpen", _informativeMenuOpened);

                _informativeItemTitle.text = buildings.name;
                _informativeItemImage.sprite = buildings.sprite;

                _productScrollContentGameObject.SetActive(buildings.products.Count > 0);
            }
        }
    }

}
