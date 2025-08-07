using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlacer : MonoBehaviour
{
    public GameObject buildingPrefab;
    private GameObject previewObj;
    private Building buildingData;
    private BuildingPreview previewScript;
    void Start()
    {
        
    }
    public void StartBuilding(int buildingSIze)
    {
        previewObj = Instantiate(buildingPrefab);
        buildingData = previewObj.GetComponent<Building>();
        buildingData.SetBuildingSize(buildingSIze);
        previewScript = previewObj.AddComponent<BuildingPreview>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GameManager.Instance.isBuilding = !GameManager.Instance.isBuilding;
            if(previewObj == null && GameManager.Instance.isBuilding)
            {
                StartBuilding(1);
            }
            else if(previewObj != null && !GameManager.Instance.isBuilding)
            {
                Destroy(previewObj);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GameManager.Instance.isBuilding = !GameManager.Instance.isBuilding;
            if (previewObj == null && GameManager.Instance.isBuilding)
            {
                StartBuilding(2);
            }
            else if (previewObj != null && !GameManager.Instance.isBuilding)
            {
                Destroy(previewObj);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            GameManager.Instance.isBuilding = !GameManager.Instance.isBuilding;
            if (previewObj == null && GameManager.Instance.isBuilding)
            {
                StartBuilding(3);
            }
            else if (previewObj != null && !GameManager.Instance.isBuilding)
            {
                Destroy(previewObj);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            GameManager.Instance.isBuilding = !GameManager.Instance.isBuilding;
            if (previewObj == null && GameManager.Instance.isBuilding)
            {
                StartBuilding(4);
            }
            else if (previewObj != null && !GameManager.Instance.isBuilding)
            {
                Destroy(previewObj);
            }
        }
        if (GameManager.Instance.isBuilding)
        {
            Ray ray =Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out RaycastHit hit, 100f, LayerMask.GetMask("Floor")))  // camera는 받아와서 쓰는걸 추천      // out은 외부에서 인자에 들어온 것을 계산하고 그대로 배출하고 싶을떄
            {
                Vector3 hitpoint = hit.point;
                Vector2Int gridPos = new Vector2Int(Mathf.FloorToInt(hitpoint.x), Mathf.FloorToInt(hitpoint.z));
                Vector3 displayPos = new Vector3(gridPos.x + buildingData.size.x / 2f, 1, gridPos.y + buildingData.size.y / 2f);
                previewObj. transform.position = displayPos;

                bool canPlace = GameManager.Instance.IsAreaFree(gridPos, buildingData.size);
                previewScript.SetColer(canPlace ? Color.green : Color.red);

                if(Input.GetMouseButtonDown(0) && canPlace)
                {
                    PlaceBuilding(gridPos);
                }
            }
        }
    }
    void PlaceBuilding(Vector2Int gridPos)
    {
        Debug.Log(buildingData.size.x);
        Vector3 spawnPos = new Vector3(gridPos.x + buildingData.size.x / 2f, 1, gridPos.y + buildingData.size.y / 2f);
        GameObject createBuilding = Instantiate(buildingPrefab, spawnPos, Quaternion.identity);
        createBuilding.transform.name = "CreateBuilding";
        createBuilding.GetComponent<Building>().SetBuildingSize(buildingData.size.x);
        GameManager.Instance.OccupyArea(gridPos, buildingData.size);
    }
}
