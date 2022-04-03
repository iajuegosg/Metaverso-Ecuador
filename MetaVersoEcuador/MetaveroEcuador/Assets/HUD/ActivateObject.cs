using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObject : MonoBehaviour
{
    public GameObject objectToActive;
    public float tiempo;


    public void Start()
    {
        StartCoroutine(ActivateObjectToTime(tiempo));
    }


    private IEnumerator ActivateObjectToTime(float tiempo)
    {
        Debug.Log("Inicializando corrutina");
        yield return new WaitForSeconds(tiempo);
        objectToActive.SetActive(true);
    }
}