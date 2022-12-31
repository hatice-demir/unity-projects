using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public Animator fadeAnimator;
    private int levelToLoad;
    public GameObject player;
    public void LoadNextScene(int levelNo)
    {
        levelToLoad = levelNo;
        fadeAnimator.SetTrigger("FadeOut");

    }

    public void LoadNextScenePrefs(int levelNo)
    {
        savePrefs();
        levelToLoad = levelNo;
        fadeAnimator.SetTrigger("FadeOut");

    }

    void savePrefs()
    {
        //Vector3 playerPos = player.transform.position;
        //Quaternion playerRotation = player.transform.rotation;
        //Debug.Log(player.transform.position.x);
        //PlayerPrefs.SetFloat("posX", player.transform.position.x);
        //PlayerPrefs.SetFloat("posY", player.transform.position.y);
        //PlayerPrefs.SetFloat("posZ", player.transform.position.z);
        //PlayerPrefs.SetFloat("rotX", playerRotation.x);
        //PlayerPrefs.SetFloat("rotY", playerRotation.y);
        //PlayerPrefs.SetFloat("rotZ", playerRotation.z);
        Debug.Log(player.GetComponent<HealthSystem>().currentHealth);
        PlayerPrefs.SetInt("health", player.GetComponent<HealthSystem>().currentHealth);

    }

    public void onFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
