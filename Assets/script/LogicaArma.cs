using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ModoDeDisparo{
    SemiAuto, FullAuto
}


public class LogicaArma : MonoBehaviour
{

      protected Animator animator;
    protected AudioSource audiosource;
    public bool tiempodeNoDisparo =false;
    public bool puedeDisparar= false;
    public bool recargando= false; 
 [Header("Referencia de Objetos")]
    //public ParticlesSystem fuegoDeArma;
    public Camera camaraPrincipal;
  public Transform puntoDeDisparo;
      [Header("Referencia de Sonidos")]
    public AudioClip SonidoDisparo;
    public AudioClip SonidoSinBalas;
    public AudioClip SonidoCartuchoEntra;
    public AudioClip SonidoCartuchoSale;
    public AudioClip SonidoVacio;
    public AudioClip SonidoDesenfundar;

    [Header("Atributos de Arma")]

    public ModoDeDisparo mododedisparo= ModoDeDisparo.FullAuto;
    public float daño= 20f;
    public float ritmoDeDisparo= 0.3f;
    public int balasRestantes;
    public int balasenCartucho;
    public int tamañodecartucho=12;
    public int maximodeBalas=100;
  


    // Start is called before the first frame update
    void Start()
    {
        audiosource= GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        balasenCartucho= tamañodecartucho;
        balasRestantes= maximodeBalas;
        Invoke("HabilitarArma",0.5f);
    }

    // Update is called once per frame
    void Update(){
    
        if(mododedisparo==ModoDeDisparo.FullAuto && Input.GetButton("Fire1")){
            RevisarDisparo();

        }else if(mododedisparo==ModoDeDisparo.SemiAuto && Input.GetButtonDown("Fire1")){
               RevisarDisparo();
        }
        if(Input.GetButtonDown("Reload")){
            RevisarRecarga();
        }

    }

    void HabilitarArma(){
        puedeDisparar=true;
    }

    void RevisarDisparo(){
        if(!puedeDisparar) return ;
        if(tiempodeNoDisparo) return ;
        if(recargando) return;
        if(balasenCartucho>0){
                Disparar();
        }else{
            SinBalas();

        }
    }

    void Disparar(){
    audiosource.PlayOneShot(SonidoDisparo);
    tiempodeNoDisparo=true;
    //fuegoDeArma.Stop();
   // fuegoDeArma.play();
   ReproducirAnimacionDisparo();
   balasenCartucho--;
  StartCoroutine(ReiniciarTiempoNoDisparo());
    DisparoDirecto();
    }

    void DisparoDirecto(){
        RaycastHit hit;
        if(Physics.Raycast(puntoDeDisparo.position, puntoDeDisparo.forward, out hit)){
            if(hit.transform.CompareTag("Enemigo")){
            Vida vida = hit.transform.GetComponent<Vida>();
            if(vida==null){
                throw new System.Exception("No se encontro el componente vida del enemigo");

            }else{
                vida.recibirdaño(daño);
                
            }
            }
        }
    }

    public virtual void ReproducirAnimacionDisparo(){
        if(gameObject.name=="Police9mm"){
            if(balasenCartucho>1){
                animator.CrossFadeInFixedTime("Fire", 0.1f);
            }else{
                animator.CrossFadeInFixedTime("FireLast", 0.1f);
            }
             
        }
    else{
        animator.CrossFadeInFixedTime("Fire",0.1f);

    }
    }

    void SinBalas(){
    audiosource.PlayOneShot(SonidoSinBalas);
    tiempodeNoDisparo= true;
    StartCoroutine(ReiniciarTiempoNoDisparo());

}

IEnumerator ReiniciarTiempoNoDisparo(){
    yield return new WaitForSeconds(ritmoDeDisparo);
    tiempodeNoDisparo=false;

}

void RevisarRecarga(){
    if(balasRestantes>0 && balasenCartucho<tamañodecartucho){
        Recargar();

    }
}

void Recargar(){
    if(recargando) return ;
    recargando= true;
    animator.CrossFadeInFixedTime("Reload", 0.1f);


}


void RecargarMuniciones(){
    int balasParaRecargar= tamañodecartucho-balasenCartucho;
    int restarBalas= (balasRestantes>=balasParaRecargar)? balasParaRecargar:balasRestantes;
    balasRestantes-= restarBalas;

    balasenCartucho+=balasParaRecargar;
}

public void desenfundarON(){
    audiosource.PlayOneShot(SonidoDesenfundar);
}

public void CartuchoentraON(){
    audiosource.PlayOneShot(SonidoCartuchoEntra);
    RecargarMuniciones();
}

public void VacioON(){
    audiosource.PlayOneShot(SonidoVacio);
    Invoke("ReiniciarRecargar", 0.1f);
}

void ReiniciarRecargar(){
    recargando=false;
}

}



