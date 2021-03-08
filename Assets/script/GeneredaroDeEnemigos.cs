using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneredaroDeEnemigos : MonoBehaviour
{
    public GameObject zombiePrefa;
    public Transform[] puntosDeGeneracion;
    public float TiempoDeGeneracion=5f;

    // Start is called before the first frame update
    void Start()
    {
    puntosDeGeneracion  = new Transform[transform.childCount];
    for(int i=0; i<transform.childCount; i++){
puntosDeGeneracion[i]=transform.GetChild(i);

    }

    StartCoroutine(AparecerEnemigo()); 
    }

    IEnumerator AparecerEnemigo(){
        while(true){
            for(int i=0; i< puntosDeGeneracion.Length; i++){
                Transform puntoDeGeneracion= puntosDeGeneracion[i];
                Instantiate(zombiePrefa, puntoDeGeneracion.position, puntoDeGeneracion.rotation);
            }
            yield return new WaitForSeconds(TiempoDeGeneracion);
        } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
