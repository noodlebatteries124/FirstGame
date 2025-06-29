using System.Collections.Generic;
using UnityEngine;

public class Lootbag : MonoBehaviour
{
    public GameObject lootPrefab;
    public List<Loots> lootList = new List<Loots>();
    Loots GetDroppedItem()
    {
        int randomNumber = Random.Range(1, 101);
        List<Loots> possibleItems = new List<Loots>();
        foreach (Loots item in lootList)
        {
            if(randomNumber <= item.dropChance)
            {
                possibleItems.Add(item);
            }
        }
        if(possibleItems.Count > 0)
        {
            Loots droppedItem = possibleItems[Random.Range(0, possibleItems.Count)];
            return droppedItem;
        }
        Debug.Log("No items dropped");
        return null;
    }
    public void InstantiateLoot(Vector3 spawnPosition)
    {
        Loots droppedItem = GetDroppedItem();
        if(droppedItem != null) 
        {
            GameObject lootGameObject = Instantiate(lootPrefab, spawnPosition, Quaternion.identity);
            lootGameObject.GetComponent<SpriteRenderer>().sprite = droppedItem.lootSprite;
            float dropForce = 300f;
            Vector2 dropDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            lootGameObject.GetComponent<Rigidbody2D>().AddForce(dropDirection.normalized * dropForce, ForceMode2D.Impulse);
            if (droppedItem.lootName is "HealSpriteAnim")
            {
                lootGameObject.tag = "HealSpriteAnim";
            }
        }

         
    }
}
