using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Windows.Speech;
using System.Collections.Generic;
using System.Linq;

public class CodigoCortina : MonoBehaviour
{

    public bool ayuda;
    public Image cortina;

    KeywordRecognizer keywordRecognizer; // creo mi reconocedor de comandode voz
    Dictionary<string, Action> actions = new Dictionary<string, Action>(); // creo los comando

    private float tiempo;
    private void Start()
    {
        ayuda = false;
        //Create keywords for keyword recognizer
        actions.Add("ayuda", RevisarSiPideAyuda);

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
        keywordRecognizer.Start();
    }

    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        actions[args.text].Invoke();
    }
    public void RevisarSiPideAyuda()
    {
        if (ayuda == false)
        {
            cortina.enabled = false;
            ayuda = true;

        }
        tiempo = 0;
    }
    private void Update()
    {
        if (ayuda)
        {
            cronometrar();
        }

    }
    public void cronometrar()
    {
        if (tiempo <= 5)
        {

            tiempo += 1 * Time.deltaTime;
            print(tiempo);
        }
        else
        {
            cortina.enabled = true;
            ayuda = false;
            tiempo = 0;
        }

    }
}
