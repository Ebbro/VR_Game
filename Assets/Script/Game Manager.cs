/*using System.Collections.Generic;
/*using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectCheck
{
    public GameObject mainObject;
    public List<GameObject> requiredSubObjects = new List<GameObject>();
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Time Settings")]
    public float maxTime = 300f; // Maximum level time in seconds
    private float elapsedTime = 0f;
    private bool isGameOver = false;

    [Header("Object Checking")]
    public List<ObjectCheck> objectChecks = new List<ObjectCheck>(); // List of objects with required sub-objects

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (!isGameOver)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= maxTime)
            {
                EndGame();
            }
        }
    }

    private void EndGame()
    {
        isGameOver = true;
        Debug.Log("Game Over: Time's up!");
        // Implement additional game over logic here
    }

    public bool CheckObject(GameObject obj)
    {
        foreach (var check in objectChecks)
        {
            if (check.mainObject == obj)
            {
                List<GameObject> containedObjects = GetObjectList(obj);
                if (containedObjects == null) return false;

                foreach (GameObject requiredObj in check.requiredSubObjects)
                {
                    if (!containedObjects.Contains(requiredObj))
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        return false;
    }

    private List<GameObject> GetObjectList(GameObject obj)
    {
        ObjectContainer container = obj.GetComponent<ObjectContainer>();
        return container != null ? container.objectsInside : null;
    }
}

public class ObjectContainer : MonoBehaviour
{
    public List<GameObject> objectsInside = new List<GameObject>();
}
*/