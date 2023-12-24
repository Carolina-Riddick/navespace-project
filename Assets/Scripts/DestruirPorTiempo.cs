using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirPorTiempo : MonoBehaviour
{

    public float time; //nosotros colocamos el tiempo


    void Start()
    {
        Destroy(gameObject, time); //destruye el objeto que tiene como referencia este script con la variante tiempo
                                   // pasado un tiempo determinado destruye ese objto

    }






}

