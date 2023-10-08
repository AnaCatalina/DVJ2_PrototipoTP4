using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListaDeImagenes : MonoBehaviour
{
    public List<Texture> imagenes = new List<Texture>(); // Lista de texturas (imágenes) originales
    public RawImage mostrarImagen; // Componente RawImage
    private List<Texture> imagenesAleatorias = new List<Texture>(); // Lista de texturas en orden aleatorio
    private int indiceActual = 0; // Índice de la imagen actual

    void Start()
    {
        // Mezcla las imágenes en orden aleatorio al inicio del juego
        AleatorizarImagenes();

        // Muestra la primera imagen
        MostrarImagenes();
    }

    void AleatorizarImagenes()
    {
        // Copia las imágenes originales a la lista de imágenes aleatorias
        imagenesAleatorias.AddRange(imagenes);

        // Pone las imágenes en orden aleatorio
        for (int i = 0; i < imagenesAleatorias.Count; i++)
        {
            int indiceAletorio = Random.Range(i, imagenesAleatorias.Count);
            Texture imagenTemp = imagenesAleatorias[i];
            imagenesAleatorias[i] = imagenesAleatorias[indiceAletorio];
            imagenesAleatorias[indiceAletorio] = imagenTemp;
        }
    }

    void MostrarImagenes()
    {
        // Actualiza RawImage con la imagen actual
        mostrarImagen.texture = imagenesAleatorias[indiceActual];
    }

    void Update()
    {
        // Verifica si se presiona la tecla "K"
        if (Input.GetKeyDown(KeyCode.K))
        {
            // Cambia a la siguiente imagen
            SiguienteImagen();
        }
    }

    // Método para cambiar la imagen al siguiente
    private void SiguienteImagen()
    {
        // Aumenta el índice
        indiceActual++;

        // Verifica si hemos llegado al final de la lista de imágenes
        if (indiceActual >= imagenesAleatorias.Count)
        {
            //En realidad se termina el juego
            indiceActual = 0; // Reinicia al principio si estamos al final
        }

        // Actualiza la imagen por una nueva
        MostrarImagenes();
    }
}