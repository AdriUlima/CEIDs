using UnityEngine;

[CreateAssetMenu(fileName = "SOPersonaje", menuName = "Scriptable Objects/SOPersonaje")]
public class SOPersonaje : ScriptableObject
{
    public string nombre;
    public Sprite sprite;
    public int hp, mov;
    public SOAtk atk1, atk2, atk3;
}
