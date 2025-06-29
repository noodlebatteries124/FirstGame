using UnityEngine;

[CreateAssetMenu(fileName = "Loot", menuName = "Scriptable Objects/Loot")]
public class Loots: ScriptableObject
{
    public Sprite lootSprite;
    public string lootName;
    public int dropChance;

    public Loots(string lootName, int dropChance)
    {
        this.lootName = lootName;
        this.dropChance = dropChance;
    }
}
