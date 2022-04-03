using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorDeObjetos : MonoBehaviour
{
    public GameObject objectoAgarado;
    public GameObject OBjetoObtenido;
    public Transform zonaDeInteraccion;
    void Update()
    {
        if (objectoAgarado!=null&& objectoAgarado.GetComponent<ObjetosObtenibles>().esObtenible==true&&OBjetoObtenido==null)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                OBjetoObtenido = objectoAgarado;
                OBjetoObtenido.GetComponent<ObjetosObtenibles>().esObtenible = false;
                OBjetoObtenido.transform.SetParent(zonaDeInteraccion);
                OBjetoObtenido.transform.position = zonaDeInteraccion.position;
                OBjetoObtenido.GetComponent<Rigidbody>().useGravity = false;
                OBjetoObtenido.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
        else if (OBjetoObtenido != null)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                OBjetoObtenido.GetComponent<ObjetosObtenibles>().esObtenible = true;
                OBjetoObtenido.transform.SetParent(null);
                OBjetoObtenido.GetComponent<Rigidbody>().useGravity = true;
                OBjetoObtenido.GetComponent<Rigidbody>().isKinematic = false;
                OBjetoObtenido = null;
            }
        }
    }
}
