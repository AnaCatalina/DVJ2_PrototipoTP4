using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;

public class CommandVoice : MonoBehaviour
{
    // Start is called before the first frame update
    KeywordRecognizer keywordRecognizer; // creo mi reconocedor de comandode voz

    Dictionary<string, Action> actions = new Dictionary<string, Action>(); // creo las comando

    void Start()
    {
        //creo las acciones segun el comandod e voz
        actions.Add("abajo",MoverAbajo);
        actions.Add("derecha",MoverDerecha);
        actions.Add("salto",Saltar);
        //


        //seteo el ronocedor de voz y lo inicio
        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
        keywordRecognizer.Start();

        WindowsVoice.speak("Hola a los alumnos y alumnas de diseño de videojuegos 2");
    }

    private void Saltar()
    {
        Debug.Log("el personaje debe saltar");
        WindowsVoice.speak("he dicho saltar");
    }

    private void MoverDerecha()
    {
        Debug.Log("el personaje debe moverse a la derecha");
        WindowsVoice.speak("he dicho derecha");

    }

    private void MoverAbajo()
    {
        Debug.Log("el personaje debe moverse hacia abajo");
        WindowsVoice.speak("he dicho aba");


    }

    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs command)
    {
       // Debug.Log(command.text);
        actions[command.text].Invoke();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K)) {
            WindowsVoice.speak("tecla k");
        }
    }
}
