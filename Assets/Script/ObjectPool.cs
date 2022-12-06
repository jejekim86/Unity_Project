using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IPoolingObject
{
    void Initialize(object value);
}
[System.Serializable]
public class ObjectPool<T> where T : MonoBehaviour, IPoolingObject
{
    [SerializeField] T targetObject;
    [SerializeField] [Range(1, 100)] int poolingAmount;
    Transform containerObject;
    Queue<T> objectPool;
    object initData = null;

    public bool Initialize(object value)
    {
        if (!targetObject || containerObject) return false;
        if (1 > poolingAmount) poolingAmount = 1;
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("Object Pool Container : ");
        sb.Append(targetObject.name);
        containerObject = new GameObject(sb.ToString()).transform;
        objectPool = new Queue<T>();
        initData = value;
        MakeAndPooling();
        return true;
    }
    bool MakeAndPooling()
    {
        if (!containerObject) return false;
        T poolObject;
        for (int i = 0; poolingAmount > i; i++)
        {
            poolObject = MonoBehaviour.Instantiate(targetObject, containerObject);
            poolObject.name = targetObject.name;
            poolObject.Initialize(initData);
            poolObject.gameObject.SetActive(false);
            objectPool.Enqueue(poolObject);
        }
        return true;
    }

    public bool GetObject(out T item)
    {
        item = null;
        if (!containerObject) return false; if (0 >= objectPool.Count)
        {
            if (!MakeAndPooling()) return false;
        }
        item = objectPool.Dequeue(); item.gameObject.SetActive(false); return true;
    }

    /// <summary> 해당 풀이 가지는 아이템이 맞는지 확인. </summary>
    public bool CheckItem(T item)
    {
        if (!targetObject)
        {
            Debug.Log("잘못된 아이템 들고옴");
            return false;
        }
        return targetObject.name.Equals(item.name);
    }
    // <summary> item을 비활성화 시키고 Pool에 넣는다. </summary>
    public bool PutInPool(T item)
    {
        if (!(item && containerObject)) return false;
        item.gameObject.SetActive(false); objectPool.Enqueue(item);
        return true;
    }

    public bool Destroy()
    {
        if (!containerObject) return false;
        MonoBehaviour.Destroy(containerObject.gameObject);
        containerObject = null;
        objectPool.Clear(); objectPool = null; return true;
    }

    public void ReturnBackPool()
    {
        if (containerObject)
        {
            // 모든 자식을 순회 한다.
            foreach (Transform child in containerObject)
            {
                if (child.gameObject.activeSelf)
                {
                    if (child.TryGetComponent(out T item)) PutInPool(item);
                }
            }
        }
    }
}
