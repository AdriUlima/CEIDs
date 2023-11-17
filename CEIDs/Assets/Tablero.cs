using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tablero : MonoBehaviour
{
    [SerializeField]
    private int filas=5, columnas=5;
    private GameObject[][] tablero;
    void Awake()
    {
        tablero = new GameObject[filas][];
        float fi=CalcularCentro(filas), ci=CalcularCentro(columnas);
        for(int i = 0; i < filas; i++)
        {
            tablero[i] = new GameObject[columnas];
            for(int j=0; j < columnas; j++)
            {
                Instantiate(Resources.Load("Prefabs/Celda"), new Vector2(fi+2*i, ci+2*j), Quaternion.identity);
            }
        }
    }

    private float CalcularCentro(int num)
    {
        return (1.1f*num+0.1f*(num-1))/-2-1.1f/2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
