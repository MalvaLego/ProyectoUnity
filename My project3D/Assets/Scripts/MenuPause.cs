using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    public GameObject pauseMenu;
  
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            Time.timeScale=0;
            pauseMenu.SetActive(true);
            Cursor.visible = true; // Muestra el cursor
            Cursor.lockState = CursorLockMode.None; // Desbloquea el cursor
        }
    }


    public void Resume(){
        Time.timeScale=1;
        pauseMenu.SetActive(false);
        Cursor.visible = false; // Oculta el cursor
        Cursor.lockState = CursorLockMode.Locked; // Bloquea el cursor
    }

    public void Settings(){
        
    }

    public void BackMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
}
