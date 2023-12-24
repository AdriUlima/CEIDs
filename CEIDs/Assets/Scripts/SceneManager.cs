using UnityEngine;

public class SceneManager : MonoBehaviour
{
    private GameManager gameManager;
    private static SceneManager instance;
    public static SceneManager Instance { get { return instance; } }
    public SOTablero tableroSelected { get; private set; }
    public Celda[][] tablero { get; private set; }
    [SerializeField] private Celda celdaPrefab;
    public Personaje[][] Jugadores; //[n°jugador][n°personaje]

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        gameManager = GameManager.Instance;
        tableroSelected = gameManager.SizesTablero[Random.Range(0, gameManager.SizesTablero.Length)];
        tablero = new Celda[tableroSelected.horizontal][];
        float hi=CalcularCentro(tableroSelected.horizontal), vi=CalcularCentro(tableroSelected.vertical);
        for(int i = 0; i < tableroSelected.horizontal; i++)
        {
            tablero[i] = new Celda[tableroSelected.vertical];
            for(int j=0; j < tableroSelected.vertical; j++)
            {
                tablero[i][j] = Instantiate(celdaPrefab, new Vector2(hi+2*i, vi+2*j), Quaternion.identity);
            }
        }
    }

    private float CalcularCentro(int num)
    {
        return (1.1f*num+0.1f*(num-1))/-2-1.1f/2;
    }

}
