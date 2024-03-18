using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.Rendering.Universal;

public class Cubo : MonoBehaviour
{
    public int idCubo;
    public float intensidadLuz;
    public Light2D Luz;
    public bool Desactivando;
    public bool Desactivado;
    public AudioClip Sonido;
    public ControladorJuego controlador;


    //Color baseColor;
    //Renderer renderer_;

    private void Start()
    {
        intensidadLuz = Luz.intensity;
    }

    public void ActivarCubo()
    {
        Desactivado = false;
        Desactivado = false;
        Luz.intensity = intensidadLuz;
        Luz.gameObject.SetActive(true);

        //Llamar al controlador he hecho click en el cubo
        if (controlador.turnoPrigao)
        {
            controlador.ClickPringao(idCubo);
        }
        
        AudioSource.PlayClipAtPoint(Sonido, Vector3.zero, 1.0f);

        Invoke("DesactivarCubo()", 0.1f);
    }


    public void DesactivarCubo()
    {
        Desactivando = true;
    }


    private void Update()
    {
        if(Desactivando && !Desactivado)
        {
            Luz.intensity = Mathf.Lerp(Luz.intensity, 0, 0.065f);
        }

        if(Luz.intensity <= 0.02)
        {
            Luz.intensity = 0;
            Desactivado = true;
        }
    }

    private void OnMouseDown()
    {
        ActivarCubo();
    }
}
