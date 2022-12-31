using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour
{
    public bool inReach;
    public GameObject openText;
    public AudioSource openSound;
    //public Animator fadeAnimator;
    public GameObject fadeObj;
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
        }
    }

    void LoadNextScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        int nextScene = (scene.buildIndex + 1) % 2;
        //fadeAnimator.SetTrigger("FadeOut");
        SceneManager.LoadScene(nextScene);
    }

    // Update is called once per frame
    void Update()
    {
        if (inReach && Input.GetButtonDown("Interact"))
        {
            openSound.Play();
            openText.SetActive(false);
            Scene scene = SceneManager.GetActiveScene();
            
            
            fadeObj.GetComponent<LoadScene>().LoadNextScene(levelToLoad);
        }
    }
}
