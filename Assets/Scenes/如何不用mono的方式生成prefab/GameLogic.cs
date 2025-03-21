using UnityEngine;

public class GameLogic
{
    public static void Init()
    {
        Debug.Log("test");

        Create(GameObjectPrefab.Intance.sprite);
    }

    public static void Create(Sprite sprite)
    {
        GameObject newObject = new GameObject("NewObject"); // 會在scene上 生成一個GameObject
        newObject.transform.position = new Vector3(2, 2);
        SpriteRenderer renderer = newObject.AddComponent<SpriteRenderer>();
        renderer.sprite = sprite;

    }
}
