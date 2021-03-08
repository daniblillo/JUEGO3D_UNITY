using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaTerceraPersona : MonoBehaviour
{

  public Transform puntoDeDisparo;
     public float daño= 20f;
    private Transform myTransform;
    public Animator anim;
    
  public float spped;
    // Start is called before the first frame update
    void Start()
    {
        anim=GetComponent<Animator>();
        myTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
   /*     x=Input.GetAxis("Horizontal");
        y=Input.GetAxis("Vertical");

      transform.Rotate(0,x*Time.deltaTime*valocidadRotacion,0);
      transform.Translate(0,0,y*Time.deltaTime*velocidadMovimiento);
      anim.SetFloat("VelX",x);
      anim.SetFloat("VelY",y);
**/

if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.LeftShift) )
{
    anim.SetBool("walk", true);
myTransform.Translate(Vector3.forward * spped * Time.deltaTime);
}else{
       anim.SetBool("walk", false);
}

      if(Input.GetKey(KeyCode.Space)){
       anim.SetBool("attack", true);
                      


      }else{
            anim.SetBool("attack", false);
      }

         if(Input.GetKey(KeyCode.S)){
       anim.SetBool("runback", true);
                      


      }else{
            anim.SetBool("runback", false);
      }
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
   
           
                anim.CrossFadeInFixedTime("mixamo_com",0.5f);
      
    }
    }

