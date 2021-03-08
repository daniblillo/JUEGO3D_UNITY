using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Vida : MonoBehaviour
{
    public float valor=100;
    public Vida padreRef;
    public float multiplicadorDeDaño=1.0f;
    //public GameObject textoFlotantePre;
    public float dañototal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void recibirdaño(float daño){
        daño*=multiplicadorDeDaño;
        if(padreRef!=null){
            padreRef.recibirdaño(daño);
            return;
        }

        valor-=daño;
        dañototal=daño;

        if(valor<0){
            valor=0;

        } 

    }

  
}
