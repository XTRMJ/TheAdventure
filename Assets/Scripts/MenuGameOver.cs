using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reiniciar(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }

    public void Menu(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-2);
    }

    public void Salir(){
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
