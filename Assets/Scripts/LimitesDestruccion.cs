using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitesDestruccion: MonoBehaviour 
{
    void OnTriggerExit(Collider other) // OnTriggerExit(Collider other) Entre () pongo la referncia al collider que acaba de salir.. en este caso referencia
                                       // lo llamo "other / otro". Cuando detectamos que el collider de "otro / other" objeto haya salido queremos que : sea destruido
                                       // pongo la referncia del collider que vaya a salir, puse como nombre otro porque es otro objeto pero puedo ponerle misil o 
                                       //cualquier cosa
    {

        Destroy(other.gameObject); // con la referencia del collider podemos acceder al GameOject
    }

}
