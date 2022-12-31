using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    private int maxHealth = 100;
    public HealthBar healthBar;
    public int currentHealth;
    public GameObject deathFade;
    public AudioSource deathSound;
    private bool audioStarted = false;
    public GameObject lightEnemy;


    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("KeyBook", 0) == 1)
        {
            gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
        Debug.Log(PlayerPrefs.GetInt("CameraLight", 0) == 1);
        if (PlayerPrefs.GetInt("KeyEB", 0) == 1)
        {
            gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.SetActive(true);
        }
        if (PlayerPrefs.GetInt("KeyClass", 0) == 1)
        {
            gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(4).gameObject.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Papers", 0) == 1)
        {
            gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(5).gameObject.SetActive(true);
        }
        if (PlayerPrefs.GetInt("KeypadAns", 0) == 1)
        {
            gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(3).gameObject.SetActive(true);
            
        }

        currentHealth = PlayerPrefs.GetInt("health", maxHealth);
        healthBar.SetHealth(currentHealth);
        if ((SceneManager.GetActiveScene().buildIndex) == 0)
        {

            

            //float posx = PlayerPrefs.GetFloat("posX", 99);
            //Debug.Log(posx);
            //float posy, posz, rotx, roty, rotz;
            //if (posx != 99)
            //{
            //    posy = PlayerPrefs.GetFloat("posY");
            //    posz = PlayerPrefs.GetFloat("posZ");
            //    rotx = PlayerPrefs.GetFloat("rotX");
            //    roty = PlayerPrefs.GetFloat("rotY");
            //    rotz = PlayerPrefs.GetFloat("rotZ");
            //    gameObject.transform.position = new Vector3(posx, posy, posz);
            //    gameObject.transform.rotation = Quaternion.Euler(rotx, roty, rotz);

            //}
            if ((PlayerPrefs.GetInt("CameraLight", 0) == 1) && (lightEnemy != null))
            {
                Debug.Log("Light Enemy : " + lightEnemy.name);
                lightEnemy.SetActive(false);
                
            }

        }
        

    }

    public void onDeath()
    {
        if (audioStarted == false)
        {
            audioStarted = true;
            gameObject.GetComponent<FirstPersonController>().enabled = false;

            deathSound.Play();
            
            deathFade.GetComponent<LoadScene>().LoadNextScene(6);
            PlayerPrefs.DeleteAll();
        }

        
    }


}
