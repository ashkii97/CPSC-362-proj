using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleBuild : MonoBehaviour
{
    public PlaceTower1Test buildTower1;
    public bool toggle;

    void Start()
    {
        buildTower1 = this.GetComponent<PlaceTower1Test>();
        buildTower1.enabled = false;
    }

    public void toggleBuild()
    {
        Debug.Log("Tower 1 Purchased");
        buildTower1.enabled = !buildTower1.enabled;
    }
}
