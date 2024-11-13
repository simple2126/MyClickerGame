using UnityEngine;

[CreateAssetMenu(fileName = "DefaultEnemySO", menuName = "ScriptableObject/EnemySO", order = 0)]

public class EnemySO : ScriptableObject
{
    public float maxHP;
    public Sprite sprite;
    public int minGold;
    public int maxGold;
}