using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ControlCamara3Persona : MonoBehaviour
{
    public Vector3 distanciaCamara;
    public Transform jugador;
    public float valorLerp;
    public FixedJoystick joystick;
    public float sencibilidad;
    public float cam;
    public float rotacionCamara;
    public CinemachineFreeLook camaraCineMachine;

    private void LateUpdate()
    {
        /* cam = joystick.Horizontal;
         transform.position = Vector3.Lerp(transform.position, jugador.position + distanciaCamara, valorLerp);
         MovimientoCamara();
         distanciaCamara = Quaternion.AngleAxis(rotacionCamara * sencibilidad, Vector3.up) * distanciaCamara;
         transform.LookAt(jugador);*/
        camaraCineMachine.m_YAxis.Value = joystick.Vertical+0.5f;
        camaraCineMachine.m_XAxis.Value = joystick.Horizontal;
    }
    void MovimientoCamara()
    {
#if UNITY_ANDROID
        rotacionCamara = joystick.Horizontal;

#endif
#if UNITY_STANDALONE
        rotacionCamara = Input.GetAxis("Mouse X");

#endif
    }
}
