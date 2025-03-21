using Mono.Cecil;
using UnityEngine;

public class GameObjectPrefab : MonoBehaviour
{
    private static GameObjectPrefab instace;
    public static GameObjectPrefab Intance 
    {  
        get {
            
            if (instace == null)
            {
                instace = (Instantiate(Resources.Load("GameObjectPrefab")) as GameObject).GetComponent<GameObjectPrefab>();
            }

            return instace;
        } 
    }

    public Sprite sprite;


}
