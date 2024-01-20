using UnityEngine;

public class SceneManager : MonoBehaviour
{
    private GameManager gameManager;
    private static SceneManager instance;
    public static SceneManager Instance { get { return instance; } }
    public SOTablero tableroSelected { get; private set; }
    public Celda[][] tablero { get; private set; }
    [SerializeField] private Celda celdaPrefab;
    [SerializeField] private GameObject celdaVaciaPrefab;
    [SerializeField] private Personaje personaje;
    public Personaje[][] Jugadores; //[n°jugador][n°personaje]
    public int currentId { get; private set; } = 1;
    public int nJugadores = 2, nPersJug = 3;

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
        float hi=CalcularCentro(tableroSelected.horizontal+2), vi=CalcularCentro(tableroSelected.vertical+2);
        for(int i = -1; i < tableroSelected.horizontal + 1; i++)
        {
            if(i == -1 || i == tableroSelected.horizontal)
            {
                for (int j = 0; j < tableroSelected.vertical; j++)
                {
                    Instantiate(celdaVaciaPrefab, new Vector2(hi + 2 * i, vi + 2 * j), Quaternion.identity);
                }
            }
            else
            {
                tablero[i] = new Celda[tableroSelected.vertical];
                for (int j = -1; j < tableroSelected.vertical + 1; j++)
                {
                    if (j == -1 || j == tableroSelected.vertical)
                    {
                        Instantiate(celdaVaciaPrefab, new Vector2(hi + 2 * i, vi + 2 * j), Quaternion.identity);
                    }
                    else
                    {
                        tablero[i][j] = Instantiate(celdaPrefab, new Vector2(hi + 2 * i, vi + 2 * j), Quaternion.identity);
                    }
                }
            }
        }
        for(int i = 0; i< nJugadores; i++)
        {
            for(int j=0; j<nPersJug; j++)
            {
                Personaje per = Instantiate(personaje, new Vector2(hi + 2 * i, vi + 2 * j), Quaternion.identity);
                per.id = j + 1;
                per.personajeSelected = gameManager.TiposPersonajes[j];
            }
        }
    }

    private float CalcularCentro(int num)
    {
        return (1.1f*num+0.1f*(num-1))/-2-1.1f/2;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentId++;
            if (currentId > 2)
            {
                currentId = 1;
            }
        }
    }

}
