using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolling : MonoBehaviour
{
    public static ObjectPoolling Instance;

    [Header("Configuracion del Poolling")]
    [SerializeField] private List<PoolItem> itemsPool;
    private Dictionary<string, Queue<GameObject>> dictionaryPool;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        dictionaryPool = new Dictionary<string, Queue<GameObject>>();

        foreach (PoolItem item in itemsPool)
        {
            Queue<GameObject> objPool = new Queue<GameObject>();

            for (int i = 0; i < item.amount; i++)
            {
                int iRandom = Random.Range(0, item.listPrefab.Count);
                GameObject obj = CreareNewObj(item.listPrefab[iRandom], false);
                objPool.Enqueue(obj);
            }

            dictionaryPool.Add(item.tag, objPool);
        }
    }

    private GameObject CreareNewObj(GameObject prefab, bool value)
    {
        GameObject obj = Instantiate(prefab);
        obj.transform.SetParent(this.transform);
        obj.SetActive(value);
        return obj;
    }

    public GameObject GetPoolObject(string tag)
    {
        if (!dictionaryPool.ContainsKey(tag))
        {
            Debug.Log($"Revisar el tag {tag}");
            return null;
        }

        if (dictionaryPool[tag].Count == 0)
        {
            PoolItem itemData = itemsPool.Find(item => item.tag == tag);
            Debug.Log("NUEVO - ACTIVADO");
            int iRandom = Random.Range(0, itemData.listPrefab.Count);
            return CreareNewObj(itemData.listPrefab[iRandom], true);
        }

        GameObject obj = dictionaryPool[tag].Dequeue();
        obj.SetActive(true);
        obj.transform.SetParent(null);
        Debug.Log("ACTIVADO");
        return obj;
    }

    public void ReturnPoolObject(string tag, GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.SetParent(this.transform);
        dictionaryPool[tag].Enqueue(obj);
        Debug.Log("DESACTIVADO");
    }

}

[System.Serializable]
public class PoolItem
{
    public string tag;
    public List<GameObject> listPrefab;
    public int amount;
}