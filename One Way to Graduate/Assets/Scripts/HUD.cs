using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public GameObject flashLightON;
    public GameObject flashLightOFF;
    public GameObject flashLightOB;
    //public GameObject keyOB;





    void Start()
    {
        flashLightON.SetActive(false);
        
    }




    void Update()
    {
        if(flashLightOB.activeInHierarchy)
        {
            flashLightON.SetActive(true);
            flashLightOFF.SetActive(false);
        }
        
        else
        {
            flashLightON.SetActive(false);
            flashLightOFF.SetActive(true);
        }

        //if (keyOB.activeInHierarchy)
        //{
        //    keyOB.SetActive(true);
        //}

        //else
        //{
        //    keyOB.SetActive(false);
        //}

    }
}
