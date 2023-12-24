using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }
    public SOTablero[] SizesTablero { private set; get; }
    public SOCelda[] TiposCelda { private set; get; }

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
            SizesTablero = Resources.LoadAll<SOTablero>("Parameters/SizesTablero");
            TiposCelda = Resources.LoadAll<SOCelda>("Parameters/TiposCelda");
        }
    }

}
