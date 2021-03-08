using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class LogicaEnemigo : MonoBehaviour
{
    public GameObject target;
    private NavMeshAgent agente;
    private Vida vida;
    public Animator animator;
    private Collider collider;
    private Vida vidajugador;
    private LogicaJugador logicaJugador;
     public bool Vida0 = false;
    public bool estaatancando=false;
    public float speed=1.0f;
    public float angularSpeed=120;
    public float daño=25;

    public bool mirando;

    public bool sumarpuntos=false;
    public GameObject puntuacionPantalla;



    // Start is called before the first frame update
    void Start()
    {
        
        target= GameObject.Find("");
        vidajugador= target.GetComponent<Vida>();
        if(vidajugador== null){
            throw new System.Exception("El objeto Jugador no tiene componente Vida");

        }
        logicaJugador= target.GetComponent<LogicaJugador>();
        if(logicaJugador== null){
            throw new System.Exception("El objeto Jugador no tiene componente LogicaJugador");

        }
        agente= GetComponent<NavMeshAgent>();
    vida = GetComponent<Vida>();
        animator= GetComponent<Animator>();
        collider= GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        RevisarVida();
        Perseguir();
        RevisarAtaque();
        estadefrenteAljugador();
    }

    void estadefrenteAljugador(){
        Vector3 adelante= transform.forward;
        Vector3 targetjugador= (target.transform.position - transform.position).normalized;
        if(Vector3.Dot(adelante, targetjugador)<0.6f){
            mirando=false;
        }else{
            mirando=true;
        }
    }

   void RevisarVida()
    {
        if (Vida0) return;
        if(vida.valor <= 0)
        {
            sumarpuntos=true;
            if(sumarpuntos){
                puntuacionPantalla.GetComponent<Puntuacion>().valor+=20;
                sumarpuntos= false;
                
            }
            Vida0 = true;
            agente.isStopped = true;
            collider.enabled = false;
            animator.CrossFadeInFixedTime("Vida0", 0.1f);
            Destroy(gameObject, 3f);
        }

    }

  void Perseguir()
    {
        if (Vida0) return;
        if (logicaJugador.Vida0) return;
        agente.destination = target.transform.position;
    }

    void RevisarAtaque()
    {
        if (Vida0) return;
        if (estaatancando) return;
        if (logicaJugador.Vida0) return;
        float distanciaDelBlanco = Vector3.Distance(target.transform.position, transform.position);

        if(distanciaDelBlanco <= 2.0 && mirando)
        {
            Atacar();
        }
    }

    
        void Atacar(){
            vidajugador.recibirdaño(daño);
            agente.speed=0;
            agente.angularSpeed=0;
            animator.SetTrigger("DebeAtacar");
            Invoke("ReiniciarAtaque",1.5f);

        }

        void ReiniciarAtaque(){
            estaatancando=false;
            agente.speed= speed;
            agente.angularSpeed= angularSpeed;
        }
}
