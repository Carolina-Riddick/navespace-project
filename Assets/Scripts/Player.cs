using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO.Ports;

[System.Serializable]
public class Frontera
{
    public float xMin, xMax, zMin, zMax; // esta public class va a contener los limites de la frontera

}
public class Player : MonoBehaviour
{

    static SerialPort puerto; //nuestro puerto se va a llamar puerto y lo vamos a inicializar en alguna parte de neustro codigo..en este caso en el Start
    int valor;
    bool fire;



    private Rigidbody rb;
    float Move_x, Move_z;
    Vector3 input; //Es la variable con el valor de la velocidad en cada uno de nuestros ejes que aplicaremos al rigidbody
    public float speed;
    public float inclinacion; //tilt es inclinacion. Incorporo el valor desde unity
    public Frontera limites; //esta variable hara uso de los limites de la clase frontera 

    [Header("Disparos / Shooting:")]
    public GameObject shot; // para el prefabs es GameObject
    public Transform posicionDisparo;
    public float fireRate; //fireRtae: Tasa de disparo, es decir cada cuanto tiempo minimo vamos a poder disparar. Si pusieramos 1 seg seria 1 disparo x seg, si fireRAte fuese 
                           //2 seria 1 disparo cada 2 segundos, y si ponemos 0.5 serian 2 disparos por cada segundo o 1 disparo cada medio seg.

    private float proximoDisparo; //Inicialmente es 1. Esta variable significa en que momento, una vez iniciado el juego, podremos volver a disparar. En que momento podremos volver a disparar 

    private AudioSource audioSource;



    void Awake ()
    {

        audioSource = GetComponent<AudioSource>(); //Con la referencia a este componente, cada vez que dispare se ejecutara...

    }


    // Start is called before the first frame update
    void Start()
    {
       /* puerto = new SerialPort("COM3", 115200); // nombre del puerto COM, velocidad de 115200 baudios tiene que ser el mismo tanto en arduino como en VS
        puerto.Open(); // abrimos el puerto
        puerto.ReadTimeout = 1; // establecemos tiempo de 1 seg para que espeere entre abrir el puerto o nos diga si se ha establecido la comunicacion
       */
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        Move_x = Input.GetAxis("Horizontal");
        Move_z = Input.GetAxis("Vertical");
        
        if (Input.GetButton("Fire1") && Time.time > proximoDisparo) // edit --> project setting --> clase Input --> fire1 (el boton que equivale al boton fire1 es tal
        {                             // si ocurre esto..entonces dara verdader

        proximoDisparo = Time.time + fireRate; // si no pongo esta condicion...la nave va a seguir disparando como loca, ya que necesitamos que se cumpla el tiempo entre 
        // disparos, por eso hacemos que el proximo disparo sea disparado en : tiempo real + la tasa de disparo que pongamos (Ej: si son las 10 pm + tasa de 
        //disparo de 1 seg ...el proximo disparo  tendra que ser a las 10 pm y 1 seg, la variable va a tener que "esperar" que pase 1 seg
        Instantiate(shot, posicionDisparo.position, Quaternion.identity); // Quaternion.identity: Esto hace que tengamos siempre una posicion de CERO de la rotacion, asi no afecta la posicion del player en el disparo 
            audioSource.Play();


        }
        
        /*if (puerto.IsOpen) // verificamos el si abrio nuestra puerto serial. Si el puerto serial se abrio..entonces Verdadero
        {
            try
            {
                string s;
                s = puerto.ReadLine(); //leemos lo que mande arduino por el puerto serial y lo guardamos en la variable s
                Int32.TryParse(s, out valor); //transofrmamos el str a un entero
                if (valor == 1)
                { fire = true; }
                else
                    if (valor == 0)
                { fire = false; }
                // Esto es para que cada vez que disparamos tenemos datos..1 si se dispara y 0  si no dispara
            }

            catch (System.Exception) { }
        }
        if (fire && Time.time > proximoDisparo)
        {
            proximoDisparo = Time.time + fireRate;
            Instantiate(shot, posicionDisparo.position, Quaternion.identity);
        }*/
    }

    void FixedUpdate() //Siempre que haya algo que vaya con la fisica lo ponemos aca 
    {

        input = new Vector3(Move_x, 0.0f, Move_z); //Tiene 3 parametros: la X, la Y, y la Z
        rb.velocity = input * speed; //gracias a la referencia del rigidBody accedemos a su velocdad (rb.velocity) y le asignamos
                                     // la velocidad que hemos calculamos arriba. el input que va a ser el movimiento dado por los ejes X y Z
                                     // se van a multiplicar por Speed (Move_x * speed y Move_z * speed
        rb.position = new Vector3(Mathf.Clamp(rb.position.x, limites.xMin, limites.xMax), 0f, Mathf.Clamp(rb.position.z, limites.zMin, limites.zMax));

        /* Agregaremos que la nave se gire tanto velocidad tenga...cuanta mas velocidad tenga en el eje X tenga (cuanto mas hacia la derecha vaya o cuanto mas hacia la izquierda vaya) mas rotacion tendra.
        mas Velocidad X = mas girada tendra*/
        rb.rotation = Quaternion.Euler(0f,0f,rb.velocity.x * - inclinacion);

    }

    public void CerrarPuerto()
    { // Una funcion publica de tipo vacio que se llama "cerrar puerto" que funciona para cerrar el puerto
        //de comunicacion serial una vez que choquemos contra algo o cuando se temrine el juego y podamos cerrar el puerto. 

        puerto.Close(); //Es importante esta funcion porque sino el puerto seguira abierto y estara corriendo, no se podria ejecutar otro programa
    }

}
