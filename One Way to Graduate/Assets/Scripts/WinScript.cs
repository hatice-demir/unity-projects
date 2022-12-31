using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class WinScript : MonoBehaviour
{
    public GameObject winPanelUI;

    // Start is called before the first frame update
    async void Start()
    {
        await Task.Delay(7000); //Task.Delay input is in milliseconds
        winPanelUI.SetActive(false);
        SceneManager.LoadScene(0);
    }
}
