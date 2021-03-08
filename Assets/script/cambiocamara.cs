using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cambiocamara : MonoBehaviour
{
       public Camera firstPersonCamera;
    public Camera terceraCamera;

    public GameObject jugador1;
    public GameObject jugador3;
    // Start is called before the first frame update
    void Start()
    {
        firstPersonCamera.enabled=true;
        terceraCamera.enabled=false;
        jugador1.SetActive(true);
       jugador3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("1")){
            firstPersonCamera.enabled=true;
            terceraCamera.enabled=false;
            jugador1.SetActive(true);
                jugador3.SetActive(false);
                jugador1.transform.position= jugador3.transform.position;
        }
            if(Input.GetButtonDown("2")){
            firstPersonCamera.enabled=false;
            terceraCamera.enabled=true;
              jugador1.SetActive(false);
              jugador3.SetActive(true);
                jugador3.transform.position= jugador1.transform.position;
        }
          jugador1.transform.position= jugador3.transform.position;
           jugador3.transform.position= jugador1.transform.position;
    }
}
