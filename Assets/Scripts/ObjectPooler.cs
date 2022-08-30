using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    private Queue<GameObject> objects = new Queue<GameObject>();

    [SerializeField] private GameObject prefab;

    void AddNewObject()
    {
        GameObject newObj = Instantiate(prefab);
        newObj.SetActive(false);
        objects.Enqueue(newObj);
        newObj.transform.parent = transform;
        newObj.GetComponent<IPooledObject>().Pool = this;
    }

    public GameObject GetObject()
    {
        if (objects.Count == 0) AddNewObject();
        GameObject obj = objects.Dequeue();
        return obj;
    }

    public void ReturnToPool(GameObject obj)
    {
        obj.gameObject.SetActive(false);
        objects.Enqueue(obj);
    }
}
