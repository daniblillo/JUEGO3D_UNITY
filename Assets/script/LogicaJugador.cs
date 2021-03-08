using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement ;

public class LogicaJugador : MonoBehaviour
{
    public Vida vida;
    public bool Vida0=false;
    [SerializeField] 
    private Animator animadorPerder;
    // Start is called before the first frame update
    public Puntuacion puntuacion;

    void Start()
    {  
        vida= GetComponent<Vida>(); 
         puntuacion.valor=0;
        
    }

    // Update is called once per frame
    void Update()
    {
        Revisarvida();
    }

    void Revisarvida(){
        if(Vida0) return ;
        if (vida.valor <=0){
            AudioListener.volume=0f;
     
        Vida0=true;
                 Invoke("ReiniciarJuego", 2f);

                animadorPerder.SetTrigger("Mostrar"); 
  
        }
    }

    void ReiniciarJuego(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        puntuacion.valor=0;
                    AudioListener.volume=1f;


    }
}
