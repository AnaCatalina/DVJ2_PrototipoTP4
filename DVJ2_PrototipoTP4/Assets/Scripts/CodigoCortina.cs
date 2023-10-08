using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodigoCortina : MonoBehaviour
{
    public bool ayuda;
    public Image cortina;

    void Update ()
    {
        RevisarSiPideAyuda();
    }
    public void RevisarSiPideAyuda()
    {
        if (ayuda)
        {
            cortina.enabled = false;
        }
        else
        {
            cortina.enabled = true;
        }
    }
}
