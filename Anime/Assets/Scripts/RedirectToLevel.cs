using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RedirectToLevel : MonoBehaviour
{
    public static int redirectToLevel;
    public static int nextLevel;

    // Update is called once per frame
    void Update()
    {
        if(redirectToLevel == 3)
        {
            SceneManager.LoadScene(redirectToLevel);
        }
    }
}
