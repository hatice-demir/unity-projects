using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class LoseScript : MonoBehaviour
{
    public GameObject losePanelUI;

    // Start is called before the first frame update
    async void Start()
    {
        await Task.Delay(5000); //Task.Delay input is in milliseconds
        losePanelUI.SetActive(false);
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(1);
    }
}
