using UnityEngine;


public class Celda : MonoBehaviour
{
    private GameManager gameManager;
    private SOCelda tipoCeldaSelected;

    void Start()
    {
        gameManager = GameManager.Instance;
        int suma=0;
        for(int i = 0; i < gameManager.TipoCeldas.Length; i++)
        {
            suma += gameManager.TipoCeldas[i].probabilidad;
        }
        if (suma != 100)
        {
            Debug.LogError("No suma 100");
            Destroy(this.gameObject);
        }
        int ran = Random.Range(1,101);
        suma = 0;
        for (int i = 0; i < gameManager.TipoCeldas.Length; i++)
        {
            suma += gameManager.TipoCeldas[i].probabilidad;
            if (ran <= suma)
            {
                tipoCeldaSelected = gameManager.TipoCeldas[i];
                transform.Find("Tipo").GetComponent<SpriteRenderer>().sprite = tipoCeldaSelected.sprite;
                break;
            }
        }
    }

}
