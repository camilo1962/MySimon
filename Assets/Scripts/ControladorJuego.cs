using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorJuego : MonoBehaviour
{
    public Cubo[] Cubos;
    public List<int> ListaAleatoria = new List<int>();

    public bool ListaLlena;
    public bool turnoPc;
    public bool turnoPrigao;

    public int Contador;
    public int ContadorPringao;
    public int NivelActual;

    [Range(0.1f, 2f)]
    public float Velocidad;

    public GameObject panelGameOver;
    public Slider sliderVelocidad;
    public Text sliderText;
    public Text gameOverText;
    public Text Nivel;
    public Text Record;

    //public AudioSource incorrecto;



    private void Start()
    {
        LlenarListaAleatoria();
        turnoPc = true;
        Invoke("TurnoPc", 0.5f);
        Record.text = PlayerPrefs.GetInt("RecordText", 0).ToString("Record: " + NivelActual);
        
    }

    void LlenarListaAleatoria()
    {
        for(int i = 0; i < 1000; i++)
        {
            ListaAleatoria.Add(Random.Range(0, 4));
        }
        ListaLlena = true;
    }

    public void TurnoPc()
    {
        if(ListaLlena && turnoPc)
        {
            Cubos[ListaAleatoria[Contador]].ActivarCubo();                  

            if(Contador >= NivelActual)
            {
                NivelActual++;
                CambiarEstado();
            }
            else
            {
                Contador++;
            }
            Invoke("TurnoPc", Velocidad);
        }
    }

    public void ClickPringao(int idCubo)
    {
        if(idCubo != ListaAleatoria[ContadorPringao])
        {
            GameOver();
            return;
        }

        if(ContadorPringao == Contador)
        {
            Nivel.text = "Nivel: " + NivelActual;
            if(NivelActual > PlayerPrefs.GetInt("RecordText", 0))
            {
                PlayerPrefs.SetInt("RecordText", NivelActual);
                Record.text = "Record: " + NivelActual;
            }
            
            CambiarEstado();
        }
        else
        {
            ContadorPringao++;
        }
    }

    public void CambiarEstado()
    {
        if (turnoPc)
        {
            turnoPc = false;
            turnoPrigao = true;
        }
        else
        {
            turnoPc = true;
            turnoPrigao = false;
            Contador = 0;
            ContadorPringao = 0;
            Invoke("TurnoPc", 1.2f);
        }
    }

    public void GameOver()
    {
        panelGameOver.SetActive(true);
        //incorrecto.Play();
        turnoPc = false;
        turnoPrigao = false;
    }

    public void Reiniciar()
    {
        panelGameOver.SetActive(false);
        Contador = 0;
        ContadorPringao = 0;
        NivelActual = 0;
        ListaAleatoria.Clear();
        LlenarListaAleatoria();
        turnoPc = true;
        Invoke("TurnoPc", 1f);
    }

    public void CambiarVelocidad()
    {
        Velocidad = sliderVelocidad.value / 16;
        sliderText.text = "Velocidad: " + (sliderVelocidad.value / 16).ToString("F2");
    }
}
