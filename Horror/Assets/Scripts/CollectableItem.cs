using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SphereCollider))]
public class CollectableItem : MonoBehaviour
{
    [SerializeField] private Item item;
    [SerializeField] private int amount = 1;
    public Button grabButton;
    bool isClicked = false;
    bool onStay = false;
    
    private void OnTriggerEnter(Collider other)
    {
        if (!item) return;

        var inventory = other.GetComponent<IntFace>();

        if(inventory)
        {
            grabButton.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!item) return;

        var inventory = other.GetComponent<IntFace>();

        onStay = false;

        if(inventory)
        {
            grabButton.gameObject.SetActive(false);
        }
    }

    public void ClickToAdd()
    {
        if (!onStay) return;

        isClicked = true;
    }

    private void OnTriggerStay(Collider other)
    {
        var inventory = other.GetComponent<IntFace>();

        onStay = true;

        if(isClicked == true)
        {
            if (inventory.AddItems(item, amount)) 
            {
                isClicked = false;
                Destroy(gameObject);
                grabButton.gameObject.SetActive(false);
            }
        }
    }
    
}
