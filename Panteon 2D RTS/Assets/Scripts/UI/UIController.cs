using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private bool _productionMenuOpened;
    private bool _informativeMenuOpened;


    [SerializeField]
    private GameObject productionMenuGameObject;
    [SerializeField]
    private GameObject informativeMenuGameObject;

    [SerializeField]
    private Button informationBackButton;

    private void Start()
    {
        ContollerInitialize();
    }

    private void ContollerInitialize()
    {
        if (productionMenuGameObject != null)
        {
            Animator animator = productionMenuGameObject.GetComponent<Animator>();
            if (animator != null)
            {
                _productionMenuOpened = animator.GetBool("IsOpen");
            }
        }
        
        if (informativeMenuGameObject != null)
        {
            Animator animator = informativeMenuGameObject.GetComponent<Animator>();
            if (animator != null)
            {
                _informativeMenuOpened = animator.GetBool("IsOpen");
            }
        }
    }

    public void ProductionMenuSlideController()
    {
        if (productionMenuGameObject != null)
        {
            Animator animator = productionMenuGameObject.GetComponent<Animator>();
            if (animator != null)
            {
                _productionMenuOpened = !animator.GetBool("IsOpen");
                animator.SetBool("IsOpen", _productionMenuOpened);
            }
        }
    }
    
    public void InformativeMenuSlideController()
    {
        if (informativeMenuGameObject != null)
        {
            Animator animator = informativeMenuGameObject.GetComponent<Animator>();
            if (animator != null)
            {
                _informativeMenuOpened = !animator.GetBool("IsOpen");
                animator.SetBool("IsOpen", _informativeMenuOpened);
            }
        }
    }
}
