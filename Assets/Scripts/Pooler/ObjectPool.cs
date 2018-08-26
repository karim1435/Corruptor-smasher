using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour {
    public RecycleGameobject prefarb;

    private List<RecycleGameobject> poolInstances = new List<RecycleGameobject>();

    private RecycleGameobject CreateInstance(Vector3 pos)
    {
        var clone = GameObject.Instantiate(prefarb);
        clone.transform.position = pos;
        clone.transform.parent = transform;
        //Add all instatiate prefarb to poolInstance list
        poolInstances.Add(clone);

        return clone;
    }
    public RecycleGameobject NextObject(Vector3 pos)
    {
        RecycleGameobject instance = null;
        //For through in poolInstances (recyclegameObject)
        foreach (var go in poolInstances)
        {
            //check if the gameobject has already shutdown
            if (go.gameObject.activeSelf != true)
            {
                //set recycl
                instance = go;
                instance.transform.position = pos;
            }
        }
        //If instance is null then we create first recycleObject attach to object pool parent
        if (instance == null)
        {
            instance = CreateInstance(pos);
        }
        instance.Restart();

        return instance;
    }
}
