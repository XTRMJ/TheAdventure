using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class BarraDeVida : MonoBehaviour
{

    public GameObject[] hearts;
    public int vidas=5;
    public GameObject Personaje;
    public float timer = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<5;i++)
            hearts[i].gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

        timer -= Time.deltaTime;
            if ( vidas < 1){
                hearts[0].gameObject.SetActive(false);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
            }else if (vidas < 2){
                hearts[1].gameObject.SetActive(false);
            }else if (vidas < 3){
                hearts[2].gameObject.SetActive(false);
            }else if (vidas < 4){
                hearts[3].gameObject.SetActive(false);
            }else if (vidas < 5){
                hearts[4].gameObject.SetActive(false);
            }
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Enemigo") && timer < 0){
            vidas -= 1;
            timer=3.0f;
        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.CompareTag("Enemigo") && timer < 0){
            vidas -= 1;
            timer=3.0f;
        }
    }
}
