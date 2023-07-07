using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    public GameObject obj;
    public int maxCount = 1;
    public int catCount = 0;
    public bool isPlaced = false;

    private CatManager catManager;

    private void Awake()
    {
        catManager = GameObject.Find("CatManager").GetComponent<CatManager>();
    }

    public Vector3 SetZ(Vector3 vector, float z)
    {
        vector.z = z;
        return vector;
    }

    private void OnMouseDown()
    {
        isPlaced = true;    
        catCount++;
        obj.transform.position = SetZ(obj.transform.position, 2);
        catManager.CheckCats();
    }
}