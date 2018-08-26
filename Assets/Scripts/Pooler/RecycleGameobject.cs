using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IRecycle
{
    void Restart();
    void ShutDown();

}
public class RecycleGameobject : MonoBehaviour {
    private List<IRecycle> recycleCompomonents;
    void Awake()
    {
        var components = GetComponents<MonoBehaviour>();
        recycleCompomonents = new List<IRecycle>();
        foreach (var component in components)
        {
            if (component is IRecycle)
            {
                recycleCompomonents.Add(component as IRecycle);
            }
        }
    }

    public void Restart()
    {
        gameObject.SetActive(true);
        foreach (var component in recycleCompomonents)
        {
            component.Restart();
        }

    }
    public void Shutdown()
    {
        gameObject.SetActive(false);
        foreach (var component in recycleCompomonents)
        {
            component.ShutDown();
        }
    }
}
