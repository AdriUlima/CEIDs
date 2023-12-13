using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public int num;
    public SOPersonaje personajeSelected;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(personajeSelected.atk1?.descripcion);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
