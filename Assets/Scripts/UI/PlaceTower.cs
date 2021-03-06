﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;
 
public class PlaceTower : MonoBehaviour {
    private Tilemap tilemap;                                    
    public Tile normalTile;                             // tile where towers can be placed
    public Tile highlightTile;                          // tile when player hovers over a valid tile for tower placement
    public Tile pathTile;                               // tile where enemies travel
 
    private Vector3Int newMousePos;                     // most updated mouse position relative to Tilemap grid
    private Vector3Int oldMousePos;                     // previous mouse position relative to Tilemap grid

    bool[] validTiles;                                  // 1D represenation of valid placement tiles in Tilemap

    public GameObject tower;
    private TowerMovement towerScript;
    
    // Method for when mouse hovers over Tilemap GameObject
    private void OnMouseOver() {  
        if (oldMousePos != newMousePos) {
            // When the mouse is over a new tile and if the previous tile was highlighted, 
            // revert it to a normal tile
            if (tilemap.GetTile<Tile>(oldMousePos) == highlightTile) {
                tilemap.SetTile(oldMousePos, normalTile);
            }
            // Update previous mouse location to current location
            oldMousePos = newMousePos;
        }
        // When the mouse hovers over a new valid tile for tower placement, highlight it
        if (tilemap.GetTile<Tile>(newMousePos) == normalTile && tilemap.HasTile(newMousePos)) {
            tilemap.SetTile(newMousePos, highlightTile);
        }
    }

    // Method for when mouse is not hovering over Tilemap Gameobject
    private void OnMouseExit() {
        // If the previous tile was highlighted, revert it to a normal tile
        if (tilemap.GetTile<Tile>(oldMousePos) == highlightTile) {
            tilemap.SetTile(oldMousePos, normalTile);
        }
    }
    
    // Method for when left mouse button is pressed
    private void OnMouseDown() {
        // Get the x,y coordinates of the grid as if the bottom left cell is (0,0)
        int relativeX = newMousePos[0] - tilemap.cellBounds.xMin;
        int relativeY = newMousePos[1] - tilemap.cellBounds.yMin;
        
        // Get the index of a tile as if it were a 1D array
        int tileIndex = relativeX + (tilemap.cellBounds.size[0] * relativeY);
        
        // If the current location is a valid tile, create a tower at that location and set
        // the location to no longer be valid for additional tower placement
        if (validTiles[tileIndex]) {
            Instantiate(tower, new Vector3Int(relativeX, relativeY, 0) , Quaternion.identity);
            validTiles[tileIndex] = false;
        }
    }

    private void Start() {
        tilemap = gameObject.GetComponent<Tilemap>();

        // Set oldMousePos to a default position
        oldMousePos = new Vector3Int(0, 0, 0);

        // Get the bounds of the Tilemap grid
        BoundsInt bounds = tilemap.cellBounds;
        // Create an 1D array of all the tiles in the Tilemap
        TileBase[] tileArray = tilemap.GetTilesBlock(bounds);

        // Establish valid tower placement tiles 
        validTiles = new bool[tileArray.Length];
        for (int i = 0; i < tileArray.Length; i++) {
            if (tileArray[i] == normalTile) {
                validTiles[i] = true;
            }
        }

        towerScript = tower.GetComponent<TowerMovement>();
    }
 
    private void Update() {
        // When the game advances one frame, update location of mouse
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newMousePos = tilemap.WorldToCell(worldPoint);
    }
}