using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class MenuGameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reiniciar(){
        Cursor.lockState = CursorLockMode.None ;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }

    public void Menu(){
        Cursor.lockState = CursorLockMode.None ;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-2);
    }

    public void Salir(){
        Application.Quit();
    }
}
