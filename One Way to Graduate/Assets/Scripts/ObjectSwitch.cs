using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSwitch : MonoBehaviour
{
    public GameObject object01;
    public GameObject object02;
    public GameObject object03;
    //public GameObject object04;



    void Start()
    {
        object01.SetActive(false);
        object02.SetActive(false);
        object03.SetActive(false);
        //object04.SetActive(false);
    }




    void Update()
    {

        if (Input.GetButtonDown("1"))
        {
            object01.SetActive(true);
            object02.SetActive(false);
            object03.SetActive(false);
            //object04.SetActive(false);
        }

        if (Input.GetButtonDown("2"))
        {
            object01.SetActive(false);
            object02.SetActive(true);
            object03.SetActive(false);
            //object04.SetActive(false);
        }

        if (Input.GetButtonDown("3"))
        {
            object01.SetActive(false);
            object02.SetActive(false);
            object03.SetActive(true);
            //object04.SetActive(false);
        }

        //if (Input.GetButtonDown("4"))
        //{
        //    object01.SetActive(false);
        //    object02.SetActive(false);
        //    object03.SetActive(false);
        //    object04.SetActive(true);
        //}
    }
}
