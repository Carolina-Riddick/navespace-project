using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{

    /* Definimos una referencia al rigidbody porque vamos a necesitar esa referencia para indicarle la velocidad a la que queramos que 
     vaya al momento que aparezca en escena */

    private Rigidbody rb;
    public float speed;
    private void Awake() // Esto es para asignarle el VALOR
    {

        rb = GetComponent<Rigidbody>();


    }

    // Start is called before the first frame update
    void Start() // Aca se coloca y aplica la velocidad ni bien el objeto se inice en la escena
    {

        rb.velocity = transform.forward * speed;  // Le damos un Vector de velocidad que es un objeto vector 3 con la velocidad que
                                                  // queramos que tenga en el Eje x, en el Eje y, y en el Eje z

        /* rb.velocity = transform.forward * speed; 
        De esta forma, **el vector de direccion** (transform.forward) --> siempre mide 1 unidad x seg * Velocidad (speed ej: 5) = Dara igual a que el vector de direccion medira 5, entonces es una ***Velocidad de 5 unidades x seg****/
    }


}