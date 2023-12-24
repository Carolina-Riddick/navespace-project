using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoRotacion : MonoBehaviour
{
    public float velocidadGiro; // creamos variable publica para definir la velocidad de rotacion desde el inspector
    private Rigidbody rb; //Voy a necesitar la variable que referencia al rigidbody

    void Awake() {// Referencia de los componentes en el Awake
        rb = GetComponent<Rigidbody>();// ya tengo la referencia al rigidbody aca. Ahora le puedo dar
                                        // la velocidad angular al rigidbody en el start
    }

// No voy a usar el "Void Update" porque lo que quiero darle es solamente una  
//Fuerza de empuje, una velocidad de giro angular e  inicial. Para todo esto necesito solamente
//el " Void Start.

    void Start(){


        //rb.angularVelocity = new Vector3(); => establecemos la velocidad angular

    Vector3 angularVelocity = new Vector3(Random.Range(-1,1), Random.Range(-1,1), Random.Range(-1,1)).normalized;
//a la X le vamos a dar un valor aleatorio entre -1 y 1 , en la Y lo mismo y la Z lo mismo
// De esta forma tenemos un vector 3 donde x y z tenemos valor entre -1 y 1.
    

 // angular.Velocity : es la velocidad de giro que afecta solo a la rotacion del objet
 // Requiere un Vector 3 (una velocidad en x, una velocidad en Y, una vlocidad en Z)
 
    rb.angularVelocity  = angularVelocity * velocidadGiro; // Vector de velocidad angular con una magnitud de 1 (seguro es una velocidad lenta)
}


}
