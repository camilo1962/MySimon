using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.Rendering.Universal;

public class Colores : MonoBehaviour
{
    public int idHexagono;
    public float intensidadLuz2;
    public Light2D Luz2;
    public bool Desactivando2;
    public bool Desactivado2;
    public AudioClip Sonido2;
    public ControladorJuego2 controlador2;


    //Color baseColor;
    //Renderer renderer_;

    private void Start()
    {
        intensidadLuz2 = Luz2.intensity;
    }

    public void ActivarCubo()
    {
        Desactivado2 = false;
        Desactivado2 = false;
        Luz2.intensity = intensidadLuz2;
        Luz2.gameObject.SetActive(true);

        //Llamar al controlador he hecho click en el cubo
        if (controlador2.turnoPrigao2)
        {
            controlador2.ClickPringao(idHexagono);
        }

        AudioSource.PlayClipAtPoint(Sonido2, Vector3.zero, 1.0f);

        Invoke("DesactivarCubo()", 0.1f);
    }


    public void DesactivarCubo()
    {
        Desactivando2 = true;
    }


    private void Update()
    {
        if (Desactivando2 && !Desactivado2)
        {
            Luz2.intensity = Mathf.Lerp(Luz2.intensity, 0, 0.065f);
        }

        if (Luz2.intensity <= 0.02)
        {
            Luz2.intensity = 0;
            Desactivado2 = true;
        }
    }

    private void OnMouseDown()
    {
        ActivarCubo();
    }
}
