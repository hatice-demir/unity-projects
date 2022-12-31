using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDoorKeypad : MonoBehaviour
{
    public bool inReach;
    public GameObject openText;
    public AudioSource openSound;
    //public Animator fadeAnimator;
    public GameObject player;
    public GameObject fadeObj;
    public GameObject keypadCorrectOB;
    public GameObject missingAnswerText;
    public int levelToLoad = 0;

    // Start is called before the first frame update
    void Start()
    {
        inReach = false;
        openText.SetActive(false);

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
            missingAnswerText.SetActive(false);
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        if (inReach && Input.GetButtonDown("Interact"))
        {
            if(keypadCorrectOB.activeInHierarchy == true)
            {
                openSound.Play();
                Scene scene = SceneManager.GetActiveScene();
                openText.SetActive(false);
                fadeObj.GetComponent<LoadScene>().LoadNextScenePrefs(levelToLoad);
            } else if(keypadCorrectOB.activeInHierarchy == false)
            {
                openText.SetActive(false);
                missingAnswerText.SetActive(true);

            }

        }
    }
}
