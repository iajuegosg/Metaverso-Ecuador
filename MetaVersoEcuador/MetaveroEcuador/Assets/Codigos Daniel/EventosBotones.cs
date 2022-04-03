using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventosBotones : MonoBehaviour
{
    public ControladorPersonaje controlPersonaje;

    public void BotonCorrer()
    {
        controlPersonaje.correr =true;
        controlPersonaje.velocidadVertical = 1;
    }
    public void BotonDejarDeCorrer()
    {
        controlPersonaje.correr = false;
        controlPersonaje.velocidadVertical = 0;
    }
}
