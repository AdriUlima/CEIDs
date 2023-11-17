using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Prob
{
    public string nombre;
    public int prob;
}

public class Celda : MonoBehaviour
{

    [SerializeField]
    private Prob[] probabilidades;
    private string tipo;
    
    // Start is called before the first frame update
    void Start()
    {
        int suma=0;
        for(int i = 0; i < probabilidades.Length; i++)
        {
            suma += probabilidades[i].prob;
        }
        if (suma != 100)
        {
            Debug.LogError("No suma 100");
            Destroy(this.gameObject);
        }
        int n = Random.Range(1,101);
        suma = 0;
        for(int i = 0; i < probabilidades.Length; i++)
        {
            suma += probabilidades[i].prob;
            if (n < suma)
            {
                tipo = probabilidades[i].nombre;
                if (tipo!="")
                {
                    Transform hijo = transform.Find("Tipo");
                    hijo.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load("Sprites/" + tipo+".png");
                }
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
