using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ListaDeAyuda : MonoBehaviour
{
    public TMP_Text listaDePalabras; // Declaración de la variable pública de tipo TMP_Text
    public List<string> nombres = new List<string>(); // Lista de palabras en orden original
    private List<string> nombresAleatorios = new List<string>(); // Lista de palabras en orden aleatorio
    void Start()
    {
        // Genera una lista de palabras
        GenerarListaDePalabras();

        // Mezcla las palabras en orden aleatorio
        AleatorizarLista();

        // Muestra la lista completa en orden aleatorio
        MostrarLista();
    }

    void GenerarListaDePalabras()
    {
        // Agrega palabras a la lista
        nombres.Add("-ZONA DE DERRUMBES");
        nombres.Add("-CAMINO SINUOSO");
        nombres.Add("-ESCUELA");
        nombres.Add("-ANIMALES SUELTOS");
        nombres.Add("-DOBLE MANO");
        nombres.Add("-ROTONDA");
        nombres.Add("-SENDA PEATONAL");
        nombres.Add("-LÍMITE DE VELOCIDAD");
        nombres.Add("-LOMO DE BURRO");
        nombres.Add("-PROHIBIDO ESTACIONAR");
        nombres.Add("-CONTRAMANO");
        nombres.Add("-OBREROS TRABAJANDO");
    }

    void AleatorizarLista()
    {
        // Copia las palabras originales a la lista de palabras aleatorias
        nombresAleatorios.AddRange(nombres);

        // Mezcla las palabras en orden aleatorio
        for (int i = 0; i < nombresAleatorios.Count; i++)
        {
            int indiceRND = Random.Range(i, nombresAleatorios.Count);
            string IndiceTemp = nombresAleatorios[i];//se almacena temporalmente el valor del elemento en la posición i en una variable temporal IndiceTemp, para que no se pierda el valor original cuando se realice el intercambio.
            nombresAleatorios[i] = nombresAleatorios[indiceRND];
            nombresAleatorios[indiceRND] = IndiceTemp;
        }
    }

    void MostrarLista()
    {
        // Convierte la lista de palabras aleatorias en una cadena
        string ListaDePalabras = string.Join("\n", nombresAleatorios);

        // Asigna la cadena al objeto TMP_Text en el Canvas
        listaDePalabras.text = ListaDePalabras;
    }
}
