using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetosObtenibles : MonoBehaviour
{
    public bool esObtenible = true;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Manos Personaje"))
        {
            other.GetComponentInParent<DetectorDeObjetos>().objectoAgarado = this.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Manos Personaje"))
        {
            other.GetComponentInParent<DetectorDeObjetos>().objectoAgarado = null;
        }
    }
}
