using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    #region Singleton
    public static ObjectPool instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Object Pool found!");
            return;
        }

        instance = this;
    }
    #endregion

    List<GameObject> pooledObjects = new List<GameObject>();

    public GameObject Create(GameObject objectName, Vector3 spawnPoint, Quaternion rotation)
    {
        string objName = objectName.name;

        if (pooledObjects.Find(x => x.name == objName))
        {
            int selectedPooledObj = pooledObjects.FindIndex(x => x.name == objName);
            GameObject newObj = pooledObjects[selectedPooledObj];
            newObj.transform.position = spawnPoint;
            newObj.transform.rotation = rotation;
            newObj.SetActive(true);
            pooledObjects.RemoveAt(selectedPooledObj);
            return newObj;
        }
        else
        {
            GameObject newObj = Instantiate(objectName, spawnPoint, rotation);
            newObj.name = objName;
            return newObj;
        }
    }

    public GameObject Remove(GameObject gameObj)
    {
        if (gameObj != null)
        {
            gameObj.transform.position = Vector3.zero;
            pooledObjects.Add(gameObj);
            gameObj.SetActive(false);
        }

        return gameObj;
    }
}
