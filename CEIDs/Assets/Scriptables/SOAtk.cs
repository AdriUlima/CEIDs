using UnityEngine;

[CreateAssetMenu(fileName = "SOAtk", menuName = "Scriptable Objects/SOAtk")]
public class SOAtk : ScriptableObject
{
    public string nombre;
    public int alcance, nObj, dmgIns, dmgPer, recarga;
    public string descripcion;
}
