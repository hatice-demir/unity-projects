using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpKey : MonoBehaviour
{
    public GameObject keyOB;
    public GameObject invOB;
    public GameObject pickUpText;
    public AudioSource keySound;

    public bool inReach;


    void Start()
    {
        inReach = false;
        pickUpText.SetActive(false);
        invOB.SetActive(false);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            pickUpText.SetActive(true);
            Debug.Log("Trigger Entered");

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            pickUpText.SetActive(false);
            Debug.Log("Trigger Out of Reach");

        }
    }


    void Update()
    {
        if (inReach && Input.GetButtonDown("Interact"))
        {

            keySound.Play();
            keyOB.SetActive(false);
            invOB.SetActive(true);
            PlayerPrefs.SetInt(keyOB.name, 1);
            Debug.Log(keyOB.name);
            pickUpText.SetActive(false);
        }

        
    }
}
