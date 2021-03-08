using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Puntuacion : MonoBehaviour
{

    public float valor;
    public Puntuacion puntuacion;
    public Text texto;
    // Start is called before the first frame update
    void Start()
    {
        valor=0;
        
    }

    // Update is called once per frame
    void Update()
    {
        texto.text="Puntuacion "+puntuacion.valor;
        
    }
}
