using UnityEngine;

public class Celda : MonoBehaviour
{
    private GameManager gameManager;
    private SceneManager sceneManager;
    private SOCelda tipoCeldaSelected;

    void Start()
    {
        gameManager = GameManager.Instance;
        sceneManager = SceneManager.Instance;
        int suma=0;
        for(int i = 0; i < gameManager.TiposCelda.Length; i++)
        {
            suma += gameManager.TiposCelda[i].probabilidad;
        }
        if (suma != 100)
        {
            Debug.LogError("No suma 100");
            Destroy(this.gameObject);
        }
        int ran = Random.Range(1,101);
        suma = 0;
        for (int i = 0; i < gameManager.TiposCelda.Length; i++)
        {
            suma += gameManager.TiposCelda[i].probabilidad;
            if (ran <= suma)
            {
                tipoCeldaSelected = gameManager.TiposCelda[i];
                transform.Find("Tipo").GetComponent<SpriteRenderer>().sprite = tipoCeldaSelected.sprite;
                break;
            }
        }
    }

    public Celda CeldaIzquierda()
    {
        return sceneManager.CeldaPos(this, Vector2Int.left);
    }

}
