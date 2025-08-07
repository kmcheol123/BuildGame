using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPreview : MonoBehaviour
{
    private Renderer[] rendrers;

    void Awake()
    {
        
        rendrers = GetComponentsInChildren<Renderer>();
    }

    public void SetColer(Color color)
    {
        foreach(var r in rendrers)
        {
            if (r.material.HasProperty("_Color"))
            {
                r.material.color = color;
            }
            else
            {
                Debug.LogError("err");
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
