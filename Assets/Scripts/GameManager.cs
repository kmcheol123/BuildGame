using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; //싱글톤
    public int width = 10;
    public int height = 10;
    public bool[,] occupied;        // true=타일에 건물 있음
    public bool isBuilding = false; // 건물을 지을 수 있는 상태

    public int[,] map;
    TilemapGenerate tilemapGenerate;
    private void Awake()    
    {
        Instance = this;
        tilemapGenerate = GameObject.FindAnyObjectByType<TilemapGenerate>();
    }
    public void SetMaP(int[,] _map)
    {
        map = _map;
        width = map.GetLength(0);
        height = map.GetLength(1);

        tilemapGenerate.SetTileMap();
        occupied = new bool[weight, height];
        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                if(map[x, y] == 0)
                {
                    occupied[x, y] = false;
                }
                else
                {
                    occupied[x, y] = true;
                }
            }
        }
    }
    public bool IsAreaFree(Vector2Int start, Vector2Int size)
    {
        for(int x  = 0; x < size.x; x++)
        {
            for(int y = 0; y < size.y; y++)
            {
                int checkX = start.x + x;
                int checkY = start.y + y;
                if(checkX < 0 || checkY < 0 || checkX >= width || checkY >= height)
                    return false;
                if(occupied[checkX, checkY])
                    return false;
            }
        }
        return true;
    }

    public void OccupyArea(Vector2Int start, Vector2Int size)
    {
        for(int x = 0;x < size.x; x++)
        {
            for(int y =0; y < size.y;y++)
            {
                occupied[start.x + x, start.y + y] = true;
            }
        }
    }
    public void NOArea(Vector2Int start, Vector2Int size)
    {
        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                occupied[start.x + x, start.y + y] = false;
            }
        }
    }
    void Start()
    {
        tilemapGenerate = GameObject.FindAnyObjectByType<TilemapGenerate>();
    }

    void Update()
    {
        
    }
}
