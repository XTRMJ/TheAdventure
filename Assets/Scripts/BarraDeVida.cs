using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{

    public GameObject[] hearts;
    private int vidas=5;
    public GameObject Personaje;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( vidas < 1)
        {
            hearts[0].gameObject.SetActive(false);
        }

        if (vidas < 2)
        {
            hearts[1].gameObject.SetActive(false);
        }

        if (vidas < 3)
        {
            hearts[2].gameObject.SetActive(false);
        }
        if (vidas < 4)
        {
            hearts[3].gameObject.SetActive(false);
        }
        if (vidas < 5)
        {
            hearts[4].gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemigo")
            vidas -= 1;
    }
}
