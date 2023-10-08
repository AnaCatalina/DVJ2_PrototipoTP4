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
        nombres.Add("-Zona de Derrumbes");
        nombres.Add("-Camino Sinuoso");
        nombres.Add("-Escuela");
        nombres.Add("-Animales Sueltos");
        nombres.Add("-Doble Mano");
        nombres.Add("-Rotonda");
        nombres.Add("-Senda Peatonal");
        nombres.Add("-Limite de Velocidad");
        nombres.Add("-Lomo de Burro");
        nombres.Add("-Prohibido Estacionar");
        nombres.Add("-Contramano");
        nombres.Add("-ObrerosTrabajando");
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
