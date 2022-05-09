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
    
    private void OnTriggerEnter(Collider other)
    {
        if (!item) return;

        var inventory = other.GetComponent<IntFace>();

        if(inventory)
        {
            grabButton.gameObject.SetActive(true);
        }
    }

    public void ClickToAdd(Collider other)
    {
        var inventory = other.GetComponent<IntFace>();

        if(inventory.AddItems(item, amount))
            {
                Destroy(gameObject);
                grabButton.gameObject.SetActive(false);
            }
    }

}
