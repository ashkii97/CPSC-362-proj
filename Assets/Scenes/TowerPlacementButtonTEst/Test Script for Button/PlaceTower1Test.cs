using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;
 
public class PlaceTower1Test : MonoBehaviour {

    public static PlaceTower1Test buildTower1;

    void Awake()
    {
        if(buildTower1 != null)
        {
            return;
        }
        buildTower1 = this;
    }

    private Tilemap tilemap;
    public Tile normalTile;
    public Tile highlightTile;
    public Tile pathTile;
 
    //private Ray ray;
    private Vector3Int newMousePos;
    private Vector3Int oldMousePos;

    bool[] validTiles;

    public GameObject tower;
    private TowerMovement towerScript;

    private void OnMouseOver() {
 
        if (oldMousePos != newMousePos) {
            if (tilemap.GetTile<Tile>(oldMousePos) == highlightTile) {
                tilemap.SetTile(oldMousePos, normalTile);
            }
            oldMousePos = newMousePos;
        }
 
        if (tilemap.GetTile<Tile>(newMousePos) == normalTile && tilemap.HasTile(newMousePos)) {
            tilemap.SetTile(newMousePos, highlightTile);
        }
    }

     private void OnMouseDown() {

        int relativeX = newMousePos[0] - tilemap.cellBounds.xMin;
        int relativeY = newMousePos[1] - tilemap.cellBounds.yMin;
        int tileIndex = relativeX + (tilemap.cellBounds.size[0] * relativeY);
        
        if (validTiles[tileIndex]) {
            Instantiate(tower, new Vector3Int(relativeX, relativeY, 0) , Quaternion.identity);
            validTiles[tileIndex] = false;
        }
    }
    
    private void Start() {
        tilemap = gameObject.GetComponent<Tilemap>();
        oldMousePos = new Vector3Int(0, 0, 0);

        BoundsInt bounds = tilemap.cellBounds;
        TileBase[] tileArray = tilemap.GetTilesBlock(bounds);
        validTiles = new bool[tileArray.Length];

        for (int i = 0; i < tileArray.Length; i++) {
            if (tileArray[i] == normalTile) {
                validTiles[i] = true;
            }
        }

        towerScript = tower.GetComponent<TowerMovement>();
    }

    private void Update() {
        //ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Vector3 worldPoint = ray.GetPoint(-ray.origin.z / ray.direction.z);
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newMousePos = tilemap.WorldToCell(worldPoint);
    }
}