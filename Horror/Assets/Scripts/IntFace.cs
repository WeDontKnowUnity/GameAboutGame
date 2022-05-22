using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

[System.Serializable]
public class InventorySlot 
{
    public Item item;
    public int amount;

    public InventorySlot(Item item, int amount = 1)
    {
        this.item = item;
        this.amount = amount;
    }
}

public class IntFace : MonoBehaviour
{
    [SerializeField] private List<InventorySlot> items = new List<InventorySlot>();
    [SerializeField] private int size = 15;
    [SerializeField] public UnityEvent OnInventoryChanged;
    public GameObject inventoryObject;
    public GameObject flashlight;
    public Button flashlightSwitch;
    public GameObject PassDoor;
    public GameObject DoorWithCode;
    public GameObject Buttons;
    public TMP_InputField codeDoor;
    public GameObject FindPairs;
    public GameObject BackBtn;
    
    void Start()
    {
        inventoryObject.SetActive(false);
    }

    public bool AddItems(Item item, int amount = 1)
    {
        foreach (InventorySlot slot in items)
        {
            if(slot.item.id == item.id)
            {
                slot.amount += amount;
                OnInventoryChanged.Invoke();
                return true;
            }
        }
        
        if (items.Count >= size) return false;

        InventorySlot new_slot = new InventorySlot(item, amount);

        items.Add(new_slot);

        if(item.id == 0)
        {
            flashlight.SetActive(true);
            flashlightSwitch.gameObject.SetActive(true);
        }

        OnInventoryChanged.Invoke();

        return true;
    }

    public Item GetItem(int i)
    {
        return i < items.Count ? items[i].item : null;
    }

    public int GetAmount(int i)
    {
        return i < items.Count ? items[i].amount : 0;
    }

    public int GetSize()
    {
        return items.Count;
    }

    public void OpenInventory()
    {
        if(inventoryObject.activeSelf == false)
        {
            inventoryObject.SetActive(true);
        }
        else
        {
            inventoryObject.SetActive(false);
        }
    }

    public void OpenCodeDoor()
    {
        if (codeDoor.text == "4961")
        {
            Time.timeScale = 1f;
            PassDoor.SetActive(false);
            Quaternion open = Quaternion.Euler(0, -110, 0);
            DoorWithCode.transform.rotation = open;
            Buttons.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            PassDoor.SetActive(false);
            Buttons.SetActive(true);
        }
    }

    public void OpenDoor()
    {
        RaycastHit hit;

        Ray ray = new Ray(transform.position, transform.forward);

        int y = -110;

        Quaternion open = Quaternion.Euler(0, y, 0);
        Quaternion close = Quaternion.Euler(0, 0, 0);

        Quaternion closeV1 = Quaternion.Euler(0, 180, 0);
        Quaternion openV1 = Quaternion.Euler(0, 70, 0);

        Quaternion closeV2 = Quaternion.Euler(0, 90, 0);
        Quaternion openV2 = Quaternion.Euler(0, -20, 0);

        Quaternion closeV3 = Quaternion.Euler(0, -90, 0);
        Quaternion openV3 = Quaternion.Euler(0, -200, 0);

        Quaternion closeV4 = Quaternion.Euler(0, -180, 0);
        Quaternion openV4 = Quaternion.Euler(0, -290, 0);

        if (Physics.Raycast(ray, out hit, 3))
        {
            if (hit.collider.gameObject.tag == "Door")
            {
                if (hit.collider.gameObject.transform.rotation == close)
                {
                    hit.collider.gameObject.transform.rotation = open;
                }
                else if (hit.collider.gameObject.transform.rotation == open)
                {
                    hit.collider.gameObject.transform.rotation = close;
                }
                else if (hit.collider.gameObject.transform.rotation == openV1)
                {
                    hit.collider.gameObject.transform.rotation = closeV1;
                }
                else if (hit.collider.gameObject.transform.rotation == closeV1)
                {
                    hit.collider.gameObject.transform.rotation = openV1;
                }
                else if (hit.collider.gameObject.transform.rotation == openV2)
                {
                    hit.collider.gameObject.transform.rotation = closeV2;
                }
                else if (hit.collider.gameObject.transform.rotation == closeV2)
                {
                    hit.collider.gameObject.transform.rotation = openV2;
                }
                else if (hit.collider.gameObject.transform.rotation == openV3)
                {
                    hit.collider.gameObject.transform.rotation = closeV3;
                }
                else if (hit.collider.gameObject.transform.rotation == closeV3)
                {
                    hit.collider.gameObject.transform.rotation = openV3;
                }
                else if (hit.collider.gameObject.transform.rotation == openV4)
                {
                    hit.collider.gameObject.transform.rotation = closeV4;
                }
                else if (hit.collider.gameObject.transform.rotation == closeV4)
                {
                    hit.collider.gameObject.transform.rotation = openV4;
                }
            }
            else if (hit.collider.gameObject.tag == "Code")
            {
                if (hit.collider.gameObject.transform.rotation == open)
                {
                    //
                }
                else
                {
                    Time.timeScale = 0f;
                    PassDoor.SetActive(true);
                    Buttons.SetActive(false);
                }
            }
            else if (hit.collider.gameObject.tag == "FindPairs")
            {
                if (hit.collider.gameObject.transform.rotation == openV4)
                {
                    //
                }
                else
                {
                    Time.timeScale = 0f;
                    FindPairs.SetActive(true);
                    Buttons.SetActive(false);
                    BackBtn.SetActive(true);
                }
                
            }
        }
    }
    
}
