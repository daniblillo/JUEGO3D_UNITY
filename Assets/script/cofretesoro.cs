using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using System.Collections.Generic;
public class cofretesoro : MonoBehaviour
{

int sizeList;
   public Animator animadorganar;
    protected AudioSource audiosource;
    public AudioClip Sonido;
    public GameObject cofre;
    private NavMeshAgent agente;

   // public GameObject[] posiciones;
public List<GameObject> posiciones=new List<GameObject>();
    public Collider m_ObjectCollider;
    // Start is called before the first frame update
    void Start()
    {
        generarcofre();

        audiosource = GetComponent<AudioSource>();
        agente = GetComponent<NavMeshAgent>();
        m_ObjectCollider = GetComponent<Collider>();


    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        audiosource.PlayOneShot(Sonido);
        Destroy(this.gameObject);
         
  animadorganar.SetTrigger("Mostrar"); 

    }
    void generarcofre()
    {
    int aux=0 ;
        sizeList=posiciones.Count;
     
     do{

    
        if(sizeList==0){
            ReiniciarJuego();
        }
           float randomNumber = Random.Range(0, sizeList);
        for (int i = 0; i < sizeList; i++)
        {


            if (i == randomNumber)
            {
             
                if (posiciones[i] != null)
                {
                    cofre.transform.position = posiciones[i].transform.position;
                    posiciones.RemoveAt(i);

                }else{
                    aux=1;
                }




            }
        }

         }while(aux==1);
    }


    void ReiniciarJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        AudioListener.volume = 1f;


    }
}
