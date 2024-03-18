using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public void Salir()
    {
        Application.Quit();
    }
    public void Cambiar(string name)
    {
        SceneManager.LoadScene(name);
    }
}
