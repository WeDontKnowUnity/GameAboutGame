using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    public Button doorOpen;

    private void OnTriggerEnter(Collider other)
    {
        var inventory = other.GetComponent<IntFace>();

        if(inventory)
        {
            doorOpen.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var inventory = other.GetComponent<IntFace>();

        if(inventory)
        {
            doorOpen.gameObject.SetActive(false);
        }
    }

}
