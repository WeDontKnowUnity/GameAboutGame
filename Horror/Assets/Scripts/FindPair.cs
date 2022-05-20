using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class FindPair : MonoBehaviour
{
    public GameObject canvas;
    public Image[] imgs;
    private int indexImg;
    private int a = 0;
    private int b = 0;
    private GameObject obj;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canvas.SetActive(true);
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.5f);
    }

    public void OnCLicked(GameObject go)
    {
        indexImg = go.GetComponent<OneClick>().index;


        if (a == 0 && b==0)
        {
            a = indexImg;
            go.SetActive(false);
            obj = go;
        }
        else if(a !=0 && b == 0)
        {
            b = indexImg;
            go.SetActive(false);
            StopCoroutine(Wait());
            if (a != b)
            {
                obj.SetActive(true);
                go.SetActive(true);
            }
        }
        else if(a != 0 && b != 0)
        {
            a = indexImg;
            b = 0;
            go.SetActive(false);
            obj = go;
        }
       
    }
}
