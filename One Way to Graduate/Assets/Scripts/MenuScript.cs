using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class MenuScript : MonoBehaviour
{

    public static bool AboutBool = false;
    public GameObject menuPanelUI;
    public GameObject aboutPanelUI;
    public GameObject startPanelUI;
    public GameObject fadeObject;

    async void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        await Task.Delay(4000); //Task.Delay input is in milliseconds
        PlayerPrefs.DeleteAll();
        startPanelUI.SetActive(false);
        aboutPanelUI.SetActive(false);
        menuPanelUI.SetActive(true);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(AboutBool)
            {
                aboutPanelUI.SetActive(false);
                menuPanelUI.SetActive(true);
            }
        }
    }

    public void NewGame()
    {
        fadeObject.GetComponent<LoadScene>().LoadNextScene(1);
    }

    public void About()
    {
        AboutBool = true;
        menuPanelUI.SetActive(false);
        aboutPanelUI.SetActive(true);
    }

    public void MainMenu()
    {
        menuPanelUI.SetActive(true);
        aboutPanelUI.SetActive(false);
    }

    public void QuitGame()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
}
