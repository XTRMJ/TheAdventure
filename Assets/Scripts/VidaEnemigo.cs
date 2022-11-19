using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemigo : MonoBehaviour
{
    private int vida=3;
    public GameObject Enemigo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (vida <= 0){
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player"){
            vida -= 1;
        }
    }
}
