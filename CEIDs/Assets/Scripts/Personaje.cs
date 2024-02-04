using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class Personaje : MonoBehaviour
{
    private SceneManager sceneManager;
    public SOPersonaje personajeSelected;
    private Celda pos;
    private sbyte ang;
    [SerializeField] private int vel;
    public int id;
    private Rigidbody2D rb;

    void Start()
    {
        sceneManager = SceneManager.Instance;
        sceneManager.CambiarPersonaje += CambiarPersonaje;
        if (id == 0)
        {
            Debug.LogError("Id 0");
        }
        GetComponent<SpriteRenderer>().sprite = personajeSelected.sprite;
        GetComponent<BoxCollider2D>().size = personajeSelected.sprite.bounds.size;
        rb = GetComponent<Rigidbody2D>();
    }

    private int Direccion(KeyCode dir1, KeyCode dir2)
    {
        if(Input.GetKey(dir1) && !Input.GetKey(dir2))
        {
            return 1;
        }
        else if(Input.GetKey(dir2) && !Input.GetKey(dir1))
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }
    
    void Update()
    {
        if (id == sceneManager.currentId) {
            rb.isKinematic = false;
            switch (Direccion(KeyCode.RightArrow, KeyCode.LeftArrow), Direccion(KeyCode.UpArrow, KeyCode.DownArrow))
            {
                case (1, 0):
                    ang = 0;
                    break;
                case (1, 1):
                    ang = 1;
                    break;
                case (0, 1):
                    ang = 2;
                    break;
                case (-1, 1):
                    ang = 3;
                    break;
                case (-1, 0):
                    ang = 4;
                    break;
                case (-1, -1):
                    ang = 5;
                    break;
                case (0, -1):
                    ang = 6;
                    break;
                case (1, -1):
                    ang = 7;
                    break;
                default:
                    ang = -1;
                    break;
            }
            if (ang >= 0)
            {
                float rad = ang * 45 * Mathf.Deg2Rad;
                transform.Translate(new Vector2(Mathf.Cos(rad), Mathf.Sin(rad)).normalized * vel * Time.deltaTime);
            }
        }
        else
        {
            rb.isKinematic = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        pos = collision.GetComponent<Celda>();
        Debug.Log("celda nueva");
    }

    private void CambiarPersonaje()
    {
        StartCoroutine(CorregirPos());
        if (id == sceneManager.currentId) DibujarMovimiento();
    }
    
    IEnumerator CorregirPos()
    {
        float aux = 0;
        while (aux < 1)
        {
            transform.position = Vector2.Lerp(transform.position, pos.transform.position, aux);
            aux += Time.deltaTime;
            yield return null;
        }
    }

    private void DibujarMovimiento()
    {
        Celda c = pos;
        c.GetComponent<SpriteRenderer>().color = new Color(0, 0, 1);
        for (int i=0; i<personajeSelected.mov; i++)
        {
            c = c.CeldaIzquierda();
            if (c!=null) c.GetComponent<SpriteRenderer>().color = new Color(0, 0, 1);
        }
    }

}