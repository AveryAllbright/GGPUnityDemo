using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTerrain : MonoBehaviour {

    public Terrain terrain;
    private float[,] heights;

	// Use this for initialization
	void Start () {
        this.heights = this.terrain.terrainData.GetHeights(0, 0, this.terrain.terrainData.heightmapWidth, this.terrain.terrainData.heightmapHeight);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnDestroy()
    {
        this.terrain.terrainData.SetHeights(0, 0, this.heights);
    }
}
