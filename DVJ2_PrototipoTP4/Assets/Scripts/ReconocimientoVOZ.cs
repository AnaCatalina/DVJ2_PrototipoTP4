using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;
using System;
using Unity.VisualScripting;

public class ReconocimientoVOZ : MonoBehaviour
{
   // public GeneradorDeImagenes gen;
  //  public GameObject[] señales;
    public GameObject animal;
    public GameObject camino;
    public GameObject contramano;
    public GameObject doblemano;
    public GameObject escuela;
    public GameObject limite;
    public GameObject lomada;
    public GameObject obreros;
    public GameObject estacionar;
    public GameObject rotonda;
    public GameObject peatonal;
    public GameObject derrumbe;

    KeywordRecognizer keywordRecognizer;

    Dictionary<string, Action> img = new Dictionary<string, Action>();
   
    private void Start()
    {
       
       
         
        img.Add( "Animales Suelto",Animal);
        img.Add("Camino Sinuoso", Camino);
        img.Add("Contramano", Contramano);
        img.Add("Doble Mano", Doblemano);
        img.Add("Escuela", Escuela);
        img.Add("Limite de Velocidad", Limite);
        img.Add("Lomada de burro", Lomada);
        img.Add("Obreros Trabajando", Obreros);
        img.Add("Prohibido Estacionar", Estacionar);
        img.Add("Rotonda", Rotonda);
        img.Add("Senda Peatonal", Peatonal);
        img.Add("Zona de Derrumbe", Derrumbe);
       
        keywordRecognizer = new KeywordRecognizer(img.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += keywordRecognizer_OnPhraseRecognized;
        keywordRecognizer.Start();
      
    }

    private void Peatonal()
    {
        if (peatonal.activeSelf == true)
        {
            peatonal.SetActive(false);
            derrumbe.SetActive(true);
            Debug.Log("Respeta a los que cruzan la calle");
        }        
    }

    private void Derrumbe()
    {
        if (derrumbe.activeSelf == true)
        {
            derrumbe.SetActive(false);
            animal.SetActive(true);
            Debug.Log("Se te puede caer el cerro");
        }        
    }

    private void Rotonda()
    {
        if (rotonda.activeSelf == true)
        {
            rotonda.SetActive(false);
            peatonal.SetActive(true);
            Debug.Log("Respeta a los que caminan");
        }        
    }

    private void Estacionar()
    {
        if (estacionar.activeSelf == true)
        {
            estacionar.SetActive(false);
            rotonda.SetActive(true);
            Debug.Log("¡No estaciones aquí!");
        }        
    }

    private void Obreros()
    {
        if (obreros.activeSelf == true)
        {
            obreros.SetActive(false);
            estacionar.SetActive(true);
            Debug.Log("Personas que no le temen a la pala");
        }        
    }

    private void Lomada()
    {
        if (lomada.activeSelf == true)
        {
            lomada.SetActive(false);
            obreros.SetActive(true);
            Debug.Log("anda despacio que te rompo el auto");
        }        
    }

    private void Limite()
    {
        if (limite.activeSelf == true)
        {
            limite.SetActive(false);
            lomada.SetActive(true);
            Debug.Log("respeta la velocidad permitida gil");
        }
    }

    private void Escuela()
    {
        if (escuela.activeSelf == true)
        {
            escuela.SetActive(false);
            limite.SetActive(true);
            Debug.Log("cuidado con los pibes");
        }        
    }

    private void Doblemano()
    {
        if (doblemano.activeSelf == true)
        {
            doblemano.SetActive(false);
            escuela.SetActive(true);
            Debug.Log("Esto es doblemano");
        }
    }

    private void Contramano()
    {
        if (contramano.activeSelf == true)
        {
            contramano.SetActive(false);
            doblemano.SetActive(true);            
            Debug.Log("Estas en comntramano papu");
        }
    }

    public void Animal()
    {
        if (animal.activeSelf == true)
        {
            animal.SetActive(false);
            camino.SetActive(true);
            Debug.Log("Animales Sueltos");
        }
        // señales[2].SetActive(false);
             
    }

    private void Camino()
    {
        if (camino.activeSelf == true)
        {
            camino.SetActive(false);
            contramano.SetActive(true);
            Debug.Log("Ten cuidado con el camino");
        }
        
    }

    private void keywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs commands)
    {

        img[commands.text].Invoke();
    }
}
     