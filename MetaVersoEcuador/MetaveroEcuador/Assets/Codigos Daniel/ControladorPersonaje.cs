using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorPersonaje : MonoBehaviour
{
    public float velocidadVertical, velocidadHorizontal;
    public CharacterController CharacterController;
    public FixedJoystick joystick;
    public float velocidadDeMovimiento;
    public Vector3 inputJugador;

    public Camera camara;
    public Vector3 camaraDeFrente;
    public Vector3 camaraDerecha;
    public Vector3 direccionJugador;
    public float gravedad = 9.8f;
    public float velocidadDeCaida;
    public float fuerzaDeSalto;
    public bool estamoEnRampa=false;
    public Vector3 golpeNormal;
    public float velocidadDeslizamiento;
    public float fuerzaDeslizamiento;
    public bool saltar=false;
    void Start()
    {
        CharacterController = GetComponent<CharacterController>();
        camara = Camera.main;
    }


    // Update is called once per frame
    void Update()
    {
        CalcularMovimiento();

        inputJugador = new Vector3(velocidadHorizontal, 0, velocidadVertical);
        inputJugador = Vector3.ClampMagnitude(inputJugador, 1);
        DireccionDeCamara();

        direccionJugador = inputJugador.x * camaraDerecha + inputJugador.z * camaraDeFrente;
        direccionJugador = direccionJugador * velocidadDeMovimiento;
        CharacterController.transform.LookAt(CharacterController.transform.position + direccionJugador);
        Gravedad();
        ActividadesJugador();

        CharacterController.Move(direccionJugador*Time.deltaTime);

    }
    void CalcularMovimiento()
    {
#if UNITY_ANDROID
        velocidadHorizontal = joystick.Horizontal;
        velocidadVertical = joystick.Vertical;

#endif
#if UNITY_STANDALONE
        velocidadHorizontal = Input.GetAxis("Horizontal");
        velocidadVertical = Input.GetAxis("Vertical");

#endif
    }
    void DireccionDeCamara()
    {
        camaraDeFrente = camara.transform.forward;
        camaraDerecha = camara.transform.right;
        camaraDeFrente.y = 0;
        camaraDerecha.y = 0;
        camaraDeFrente = camaraDeFrente.normalized;
        camaraDerecha = camaraDerecha.normalized;
    }
    void Gravedad()
    {
        if (CharacterController.isGrounded)
        {
            velocidadDeCaida = -gravedad * Time.deltaTime;
            direccionJugador.y = velocidadDeCaida;
        }
        else
        {
            velocidadDeCaida -= gravedad * Time.deltaTime;
            direccionJugador.y = velocidadDeCaida;
        }
        Deslizar();
    }
    public void ActividadesJugador()
    {
        if (CharacterController.isGrounded&&saltar)
        {
            velocidadDeCaida = fuerzaDeSalto;
            direccionJugador.y = velocidadDeCaida;
            saltar = false;
        }
    }
    public void Salto()
    {
        saltar = true;
    }
    public void Deslizar()
    {
        estamoEnRampa = Vector3.Angle(Vector3.up, golpeNormal) >= CharacterController.slopeLimit;
        if (estamoEnRampa)
        {
            direccionJugador.x += ((1f-golpeNormal.y)* golpeNormal.x) * velocidadDeslizamiento;
            direccionJugador.z += ((1f - golpeNormal.y) * golpeNormal.z) * velocidadDeslizamiento;
            direccionJugador.y += fuerzaDeslizamiento;
        }
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        golpeNormal = hit.normal;
    }
}
