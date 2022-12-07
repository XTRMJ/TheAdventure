using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class MovesBoss : MonoBehaviour
{   
    public GameObject credits;
    private enum State {
        Idle,
        ChaseTarget,
        AttackingTarget,
        GoingBackToStart,
        TakingDamage,
        Dead
    }

    public NavMeshAgent boss;

    public GameObject player;

    private Animator bossAnim;

    public float visDist = 10.0f;
    public float visAngle = 360.0f;
    public float shortAttack = 3.3f;
    float tiempo;
    private float LP = 10;

    private State state;
    private AudioSource bossAudio;
    public AudioClip rugido;
    public AudioClip molestia;
    public AudioClip muriendo;


    

    Vector3 posInicial = new Vector3 (39f,112f,236f);
    Vector3 area = new Vector3 (4f,4f,4f);

    public bool golpeado; //quitar public, no seas imbecil
    private bool sonido = true;

    // Start is called before the first frame update
    void Start()
    {
    	bossAnim = GetComponent<Animator>();
        bossAudio = GetComponent<AudioSource>();
        state = State.Idle;
    }

    // Update is called once per frame
    void Update()
    {   
        switch(state){
            default:
                break;

            case State.Idle:
                boss.SetDestination(transform.position);
                if(CanSeePlayer(player)) state = State.ChaseTarget;
                break;

            case State.ChaseTarget:
                if(sonido){
                    bossAudio.PlayOneShot(rugido, 1.0f);
                    sonido = false;
                }
                boss.SetDestination(player.transform.position);
        	    bossAnim.SetBool("Walk Forward", true);
                if(CanAttackPlayer(player)){ 
                    bossAnim.SetBool("Walk Forward", false); 
                    state = State.AttackingTarget;
                }
                if(!CanSeePlayer(player)){
                    state = State.GoingBackToStart;
                } 
                break;

            case State.AttackingTarget:
                boss.SetDestination(transform.position);
                if(golpeado){
                    tiempo = tiempoAnim(1.0f); 
                    bossAudio.PlayOneShot(molestia, 1.0f);
                    bossAnim.ResetTrigger("Stab Attack");
                    state = State.TakingDamage;
                    break;
                }
                if(!CanAttackPlayer(player)){ 
                    bossAnim.ResetTrigger("Stab Attack"); 
                    state = State.ChaseTarget;
                    break;
                } else  bossAnim.SetTrigger("Stab Attack");
                break;

            case State.TakingDamage:
                bossAnim.SetTrigger("Take Damage");
                if(Time.time > tiempo){
                    bossAnim.ResetTrigger("Take Damage"); 
                    state = State.AttackingTarget;
                    golpeado = false;
                    LP -= 1;
                    if(LP == 0.0f){
                        tiempo = tiempoAnim(1.0f);
                        bossAnim.SetTrigger("Die");
                        bossAudio.PlayOneShot(muriendo, 1.0f);
                        state = State.Dead;
                    }
                }
                break;

            case State.GoingBackToStart:
                boss.SetDestination(posInicial);
        	    bossAnim.SetBool("Walk Forward", true);
                if(transform.position.magnitude - posInicial.magnitude < 2f){
                    bossAnim.SetBool("Walk Forward", false); 
                    state = State.Idle;
                }
                break;

            case State.Dead:
                if(Time.time > tiempo){
                    Destroy(gameObject);
                    credits.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                }
                break;
        }
    }

    public bool CanSeePlayer(GameObject player)
    {
        Vector3 direction = player.transform.position - transform.position;
        float angle = Vector3.Angle(direction, transform.forward);

        if (direction.magnitude < visDist && angle < visAngle)
        {
            return true;
        }
        return false;
    }
   
    public bool CanAttackPlayer(GameObject player)
    {
        Vector3 direction = player.transform.position - transform.position;
        if (direction.magnitude < shortAttack)
        {
            return true;
        }
        return false;
    }

    private float tiempoAnim(float sec){
        return Time.time + sec;
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Sword")){
            golpeado = true;    
        }
    }
}


