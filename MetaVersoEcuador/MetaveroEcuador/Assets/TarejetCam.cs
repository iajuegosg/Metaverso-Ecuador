using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TarejetCam : MonoBehaviour
{
    
    public ControladorPersonaje tarjet;
    // Start is called before the first frame update
    void Start()
    {
        tarjet = GetComponentInParent<ControladorPersonaje>();
        tarjet.tarjetCam = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
