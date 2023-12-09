using UnityEngine;

public class Tablero : MonoBehaviour
{
    private GameManager gameManager;
    private GameObject[][] tablero;
    private SOTablero tableroSelected;

    void Start()
    {
        gameManager = GameManager.Instance;
        tableroSelected = gameManager.SizeTablero[Random.Range(0, gameManager.SizeTablero.Length)];
        tablero = new GameObject[tableroSelected.horizontal][];
        float fi=CalcularCentro(tableroSelected.horizontal), ci=CalcularCentro(tableroSelected.vertical);
        for(int i = 0; i < tableroSelected.horizontal; i++)
        {
            tablero[i] = new GameObject[tableroSelected.vertical];
            for(int j=0; j < tableroSelected.vertical; j++)
            {
                Instantiate(Resources.Load("Prefabs/Celda"), new Vector2(fi+2*i, ci+2*j), Quaternion.identity);
            }
        }
    }

    private float CalcularCentro(int num)
    {
        return (1.1f*num+0.1f*(num-1))/-2-1.1f/2;
    }

}
