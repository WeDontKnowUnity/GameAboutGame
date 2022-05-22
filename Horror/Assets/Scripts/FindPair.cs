using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class FindPair : MonoBehaviour
{
    public Image[] imgs;
    private int indexImg;
    private int a = 0;
    private int b = 0;
    private GameObject obj;
    int endGame = 0;
    public GameObject door;
    public GameObject buttons;
    public GameObject backbtn;
    Quaternion close = Quaternion.Euler(0, -180, 0);
    Quaternion open = Quaternion.Euler(0, -290, 0);

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

            if (a != b)
            {
                obj.SetActive(true);
                go.SetActive(true);
            }
            else
            {
                endGame += 1;
                if (endGame == 4)
                {
                    Time.timeScale = 1f;
                    buttons.SetActive(true);
                    this.gameObject.SetActive(false);
                    backbtn.SetActive(false);
                    if (door.transform.rotation == close)
                    {
                        door.transform.rotation = open;
                    }
                }
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

    public void GoBack()
    {
        Time.timeScale = 1f;
        buttons.SetActive(true);
        this.gameObject.SetActive(false);
        backbtn.SetActive(false);
    }
}
