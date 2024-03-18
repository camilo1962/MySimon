using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorJuego2 : MonoBehaviour
{
    public Colores[] Hexagonos;
    public List<int> ListaAleatoria2 = new List<int>();

    public bool ListaLlena2;
    public bool turnoPc2;
    public bool turnoPrigao2;

    public int Contador2;
    public int ContadorPringao2;
    public int NivelActual2;

    [Range(0.1f, 2f)]
    public float Velocidad2;

    public GameObject panelGameOver2;
    public Slider SliderVelocidad2;
    public Text sliderText2;
    public Text gameOverText2;
    public Text Nivel2;
    public Text Record2;

    //public AudioSource incorrecto2;



    private void Start()
    {
        LlenarListaAleatoria();
        turnoPc2 = true;
        Invoke("TurnoPc", 0.5f);
        Record2.text = PlayerPrefs.GetInt("RecordText2", 0).ToString("Record: " + NivelActual2);

    }

    void LlenarListaAleatoria()
    {
        for (int i = 0; i < 100; i++)
        {
            ListaAleatoria2.Add(Random.Range(0, 8));
        }
        ListaLlena2 = true;
    }

    public void TurnoPc()
    {
        if (ListaLlena2 && turnoPc2)
        {
            Hexagonos[ListaAleatoria2[Contador2]].ActivarCubo();

            if (Contador2 >= NivelActual2)
            {
                NivelActual2++;
                CambiarEstado();
            }
            else
            {
                Contador2++;
            }
            Invoke("TurnoPc", Velocidad2);
        }
    }

    public void ClickPringao(int idHexagono)
    {

        if (idHexagono != ListaAleatoria2[ContadorPringao2])
        {
            GameOver();
            return;
        }

        if (ContadorPringao2 == Contador2)
        {

            CambiarEstado();
            Nivel2.text = "Nivel: " + NivelActual2;
            if (NivelActual2 > PlayerPrefs.GetInt("RecordText2", 0))
            {
                PlayerPrefs.SetInt("RecordText2", NivelActual2);
                Record2.text = "Record: " + NivelActual2;
            }            
        }
        else
        {
            ContadorPringao2++;
        }

       
    }

    public void CambiarEstado()
    {
        if (turnoPc2)
        {
            turnoPc2 = false;
            turnoPrigao2 = true;
        }
        else
        {
            turnoPc2 = true;
            turnoPrigao2 = false;
            Contador2 = 0;
            ContadorPringao2 = 0;
            Invoke("TurnoPc", 1.2f);
        }
    }

    public void GameOver()
    {
        panelGameOver2.SetActive(true);
       
        turnoPc2 = false;
        turnoPrigao2 = false;
        return;
    }

    public void Reiniciar()
    {
        panelGameOver2.SetActive(false);
        Contador2 = 0;
        ContadorPringao2 = 0;
        NivelActual2 = 0;
        ListaAleatoria2.Clear();
        LlenarListaAleatoria();
        turnoPc2 = true;
        Invoke("TurnoPc", 2f);
    }

    public void CambiarVelocidad()
    {
        Velocidad2 = SliderVelocidad2.value / 16;
        sliderText2.text = "Velocidad: " + (SliderVelocidad2.value / 16).ToString("F2");
    }
}
