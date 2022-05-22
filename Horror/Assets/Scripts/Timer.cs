using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    private int sec;
    private int min;
    public TextMeshProUGUI text; 


    void Start()
    {
       StartCoroutine(TimeFlow());
    }

    IEnumerator TimeFlow()
    {
        while(true)
        {   
            if(sec == 59)
            {
                min += 1;
                sec = -1;
            }
            text.text = min.ToString("D2") + ":" + sec.ToString("D2");
            sec++;
            yield return new WaitForSeconds(1);
        }
    }

}
