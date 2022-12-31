using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullBook : MonoBehaviour
{
    public Animator bookOB;
    public GameObject keyOB;
    public GameObject bookGOB;
    public GameObject openText;

    public AudioSource openSound;

    public bool inReach;
    public bool isOpen;



    void Start()
    {
        inReach = false;
        openText.SetActive(false);
        keyOB.GetComponent<BoxCollider>().enabled = false;

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            openText.SetActive(true);

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            openText.SetActive(false);
        }
    }


    void Update()
    {
        if (inReach && Input.GetButtonDown("Interact"))
        {
            openSound.Play();
            bookOB.SetBool("open", true);
            openText.SetActive(false);
            isOpen = true;
        }

        if (isOpen)
        {
            bookOB.GetComponent<BoxCollider>().enabled = false;
            bookOB.GetComponent<PullBook>().enabled = false;

        }


    }
    public void onBookOpened()
    {
        keyOB.GetComponent<BoxCollider>().enabled = true;
        bookGOB.SetActive(false);
    }
}
