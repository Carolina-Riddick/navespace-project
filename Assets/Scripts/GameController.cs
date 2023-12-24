using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GameController : MonoBehaviour
{
    public GameObject peligro; //hazard
    public Vector3 spawnValues;
    public int contadorPeligro; //Contador de peligro. Numero y total de Asteroides
    public float spawnWait; // Tiempo que habra entre la aparicion de uno y otro
    public float startWait;
    public float waveWait; // espera a la siguiente ola

    //Para la puntuacion:
    private int score;
    public Text scoreText;

    // Texto agregado del diplomado de P4h para la programacion del sensor
    public Text gameOverText;
    private bool gameOver;
    public Text restartText;
    private bool restart;


    void Start() //esta funcion va a llamar cuando se inicia el objeto en la escena. Esta funcion
                 //llama a la de abajo.
    {
        restart = false;
        restartText.gameObject.SetActive(false);
        gameOver = false;
        gameOverText.gameObject.SetActive(false);
        score = 0;
        UpdateScore(); //llamamos al metodo para que aumente el score
        StartCoroutine(spawnWaves());
    }


    void Update()
    {
        if (restart && Input.GetKeyDown(KeyCode.R)) 
        {
           SceneManager.LoadScene(0); // o nombre "Main"

        }
    }


    // Corrutinas : son metodos donde podemos aplazar su ejecucion hasta su proximo fotograma o hasta que pase 1 seg, hasta dentro de un 
    //tiempo determinado, o hasta el fixupdate..etc
    //Convertimos el metodo en corrutinas con IEnumerator

    IEnumerator spawnWaves()
    //void spawnWaves() //Esto se ejecuta cuando la funcion (void start) la llama  

    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {

            for (int i = 0; i < contadorPeligro; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Instantiate(peligro, spawnPosition, Quaternion.identity);

                yield return new WaitForSeconds(spawnWait); // aca se pospondra la ejecucion..se quedara en espera hasta que pase el tiempo de spawnWait
            }

            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.gameObject.SetActive(true);
                restart = true;
                break;
            }
        }
    }
    
    public void AddScore(int value)
    {
        score += value;
        UpdateScore();

    }

    void UpdateScore() // Actualizar marcador - puntuacion
    {
        scoreText.text = "Score: " + score;

    }

    public void GameOver() //publico porque queremos que este accesible a otros scripts 
    {
        gameOverText.gameObject.SetActive(true);
        gameOver= true; //esto sirve para romper el ciclo while


    }
}