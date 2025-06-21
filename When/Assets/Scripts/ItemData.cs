// ItemData - Хранит все необходимые данные предмета
using UnityEngine;

public class ItemData : ScriptableObject
{
    public new string name;
    public Vector2Int size;
    public float weight;
    public int maxStack;
    public Sprite icon;
}