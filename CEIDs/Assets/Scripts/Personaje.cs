using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class Personaje : MonoBehaviour
{
    public SOPersonaje personajeSelected;
    private Celda pos;
    private sbyte ang;
    [SerializeField] private int vel;

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = personajeSelected.sprite;
        GetComponent<BoxCollider2D>().size = personajeSelected.sprite.bounds.size;
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
        switch(Direccion(KeyCode.RightArrow, KeyCode.LeftArrow), Direccion(KeyCode.UpArrow, KeyCode.DownArrow))
        {
            case (1,0):
                ang = 0;
                break;
            case (1,1):
                ang = 1;
                break;
            case (0,1):
                ang = 2;
                break;
            case (-1,1):
                ang = 3;
                break;
            case (-1,0):
                ang = 4;
                break;
            case (-1,-1):
                ang = 5;
                break;
            case (0,-1):
                ang = 6;
                break;
            case (1,-1):
                ang = 7;
                break;
            default:
                ang = -1;
                break;
        }
        if (ang >= 0)
        {
            float rad = ang*45 * Mathf.Deg2Rad;
            transform.Translate(new Vector2(Mathf.Cos(rad),Mathf.Sin(rad)).normalized * vel*Time.deltaTime);
        }

    }

}
