using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MeteoritFactory<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T prefab1;
    public T GetNewInstance(Vector3 pos)
    {
        return Instantiate(prefab1, pos, Quaternion.identity);
    }
}
