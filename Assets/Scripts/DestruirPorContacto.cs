using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirPorContacto : MonoBehaviour
{

    public GameObject explosion;
    public GameObject playerExplosion;

    public int scoreValue;
   
    //exportamos propiedades del Script(funciones, etc)
    private GameController JuegoControlador;
    public Player Jugador; 


    void Start()
    {
        GameObject JuegoControladorObject = GameObject.FindWithTag("GameController");
        JuegoControlador = JuegoControladorObject.GetComponent<GameController>();
        
        //llamamos a las funciones que estan en otro archivo ya que algunas funciones o estan declaradas en ste archivo
        //entonces mando a llamarla funcion cerrar puerto y game over, cada vez que nuestro player se destruye con algo 

        GameObject JugadorObject = GameObject.FindWithTag("Player");
        Jugador = JugadorObject.GetComponent<Player>();
    }

    

    void OnTriggerEnter(Collider other) // other : laser
    {

        if (other.tag == "Frontera") return; // si el collider que acaba de entrar en colision / contacto con el asteroide es la "frontera" entonces "volver / fin de la ejecucion"
                                             // Si es la frontera lo que toca el asteroide..entonces que no se destruya.
                                             // Otra forma de hacerlo es:                                       
                                             // if (other.CompareTag("Frontera")) return; Si el if es verdadero...entonces return 

        Instantiate(explosion, transform.position, transform.rotation);
        if (other.CompareTag("Player"))
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            JuegoControlador.GameOver();
            
        }
        JuegoControlador.AddScore(scoreValue);

        Destroy(other.gameObject); // destruimos el game object donde esta el collider que entro en el asteroide
                                   // va a ser el collider del laser

        Destroy(gameObject); // hace referencia al asteroide ya que este script va a estar en el asteroide

        /*
        // Entra el laser al asteroide entonces se destruye el laser Y el asteroide. Para el laser se pone (other.gameOject),
        // es decir se destruye el laser como objeto. y para el asteroide es: Destroy(gameObject)
        // gameObject = Va a haer referencia al objeto que estemos colocando este script "public class **DestruirPorContacto** : MonoBehaviour"

        if (other.CompareTag("Player"))
        {
            JuegoControlador.GameOver(); // estas son las funciones que mando a llamar 
            Jugador.CerrarPuerto();

        }*/
    }
}
