using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Building : MonoBehaviour
{
    public Vector2Int size = new Vector2Int(2, 2);

    void Start()
    {
        this.gameObject.transform.localScale = new Vector3(size.x, 1, size.y);
    }

    void Update()
    {
        
    }
    public void SetBuildingSize(int buildingSIze)
    {
        size = new Vector2Int(buildingSIze, buildingSIze);
        this.gameObject.transform.localScale = new Vector3(buildingSIze, 1, buildingSIze);
    }
}
