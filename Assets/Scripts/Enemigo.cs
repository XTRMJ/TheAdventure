using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    private float hp = 3f;
    private float danioArma = 1f;
    public float rangoDeAlerta;
    public LayerMask capaDelJugador;
    public Transform jugador;
    bool estarAlerta;
    public float velocidadEnemigo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        estarAlerta = Physics.CheckSphere(transform.position, rangoDeAlerta, capaDelJugador);

        if(estarAlerta == true){
            Vector3 posJugador = new Vector3(jugador.position.x, jugador.position.y, jugador.position.z);
            //Vector3 posJugador = new Vector3(jugador.position.x, transform.position.y, jugador.position.z); No se mueve en la posición y
            transform.LookAt(posJugador);
            transform.position = Vector3.MoveTowards(transform.position, posJugador, velocidadEnemigo * Time.deltaTime);
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, rangoDeAlerta);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Sword")
            hp -= danioArma;
        if(hp <= 0)
            Destroy(gameObject);
    }
}
