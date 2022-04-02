using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamara3Persona : MonoBehaviour
{
    public Vector3 distanciaCamara;
    public Transform jugador;
    public float valorLerp;
    public FixedJoystick joystick;
    public float sencibilidad;
    public float cam;

    private void LateUpdate()
    {
        cam = joystick.Horizontal;
        transform.position = Vector3.Lerp(transform.position, jugador.position + distanciaCamara, valorLerp);
        distanciaCamara = Quaternion.AngleAxis(-joystick.Horizontal * sencibilidad, Vector3.up) * distanciaCamara;
        transform.LookAt(jugador);
    }
}
