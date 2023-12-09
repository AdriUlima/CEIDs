using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }
    public SOTablero[] SizeTablero { private set; get; }
    public SOCelda[] TipoCeldas { private set; get; }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            SizeTablero = Resources.LoadAll<SOTablero>("Parameters/Tablero");
            TipoCeldas = Resources.LoadAll<SOCelda>("Parameters/TipoCeldas");
        }
    }

}
