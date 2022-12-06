using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanioRecibido : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Enemigo")){
            Debug.Log("El enemigo a atacado al jugador");
        }
    }
}
