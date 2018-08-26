using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GameObjectUtil {


    private static Dictionary<RecycleGameobject, ObjectPool> pools = new Dictionary<RecycleGameobject, ObjectPool>();

    public static GameObject Instantiate(GameObject prefarb, Vector3 position)
    {
        GameObject instance = null;

        var recycleScipt = prefarb.GetComponent<RecycleGameobject>();
        if (recycleScipt != null)
        {
            ObjectPool pool = GetObjectPool(recycleScipt);

            instance = pool.NextObject(position).gameObject;
        }
        else
        {
            instance = GameObject.Instantiate(prefarb);
            instance.transform.position = position;
        }

        return instance;
    }
    public static void Destroy(GameObject gameobject)
    {
        var recycleGameObject = gameobject.GetComponent<RecycleGameobject>();
        if (recycleGameObject != null)
        {
            recycleGameObject.Shutdown();
        }
        else
        {
            GameObject.Destroy(gameobject);
        }
    }
    private static ObjectPool GetObjectPool(RecycleGameobject reference)
    {
        ObjectPool pool = null;

        if (pools.ContainsKey(reference))
        {
            pool = pools[reference];
        }
        //If object pool is null then we create object pool
        else
        {
            //Create object pool called container
            var poolContainer = new GameObject(reference.gameObject.name + " ObjectPool");
            //Ad object pool script in to it
            pool = poolContainer.AddComponent<ObjectPool>();
            pool.prefarb = reference;

            //Add to pool container
            pools.Add(reference, pool);

        }
        return pool;
    }

}
