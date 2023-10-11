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
        peatonal.SetActive(false);
        derrumbe.SetActive(true);
        Debug.Log("respeta a los que caminan");
    }

    private void Derrumbe()
    {
        derrumbe.SetActive(false);
        animal.SetActive(true);

        Debug.Log("se te puede caer el cerro");
    }

    private void Rotonda()
    {
        rotonda.SetActive(false);
        peatonal.SetActive(true);
    }

    private void Estacionar()
    {
        estacionar.SetActive(false);
        rotonda.SetActive(true);
        Debug.Log("no estaciones aca ");
    }

    private void Obreros()
    {
       obreros.SetActive(false);
        estacionar.SetActive(true);
        Debug.Log("personas que no le temen a la pala");
    }

    private void Lomada()
    {
       lomada.SetActive(false);
      obreros.SetActive(true);
        Debug.Log("anda despacio que te rompo el auto");
    }

    private void Limite()
    {
        limite.SetActive(false);
        lomada.SetActive(true);
        Debug.Log("respeta la velocidad permitida gil");
    }

    private void Escuela()
    {
       escuela.SetActive(false);
        limite.SetActive(true);
        Debug.Log("cuidado con los pibes");
    }

    private void Doblemano()
    {
        doblemano.SetActive(false);
        escuela.SetActive(true);
        Debug.Log("estoes doblemano");
    }

    private void Contramano()
    {
       doblemano.SetActive(true);
        contramano.SetActive(false);
        Debug.Log("etas en comntramano papu");
    }

    public void Animal()
    {
        animal.SetActive(false);
        camino.SetActive(true);
       // señales[2].SetActive(false);
      
        Debug.Log("animales sueltos");
    }

    private void keywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs commands)
    {   

        img[commands.text].Invoke();
    }



    private void Camino()
    {
       contramano.SetActive(true);
        camino.SetActive(false);
        Debug.Log("tene cuidado con el camino");
    }
}
     