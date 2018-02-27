using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    public List<GameObject> Targets;
    public GameObject standeePrefab;
    public GameObject Player;
    public int level;

	// Use this for initialization
	void Start ()
    {
        Player = GameObject.Find("FPSController");
        Player.transform.position = new Vector3(0, 1, 0);
        level = 1;
        SpawnLevel();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    foreach(GameObject spell in Player.GetComponent<SpellManager>().LiveSpells)
        {
           foreach(GameObject standee in Targets)
            {
                
            }
        }
	}

    void SpawnLevel()
    {
        Vector3 playerLoc = Player.transform.position;
        for(int i = 0; i < level * 2.5; i++)
        {
            
            Targets.Add(Instantiate(standeePrefab));
            Vector2 pos = (Random.onUnitSphere * (12 + (level * 2)));
            Vector3 toPos = new Vector3(pos.x, 0, pos.y);
            Targets[i].transform.position = playerLoc + toPos;
            Vector3 tempBullshit = Targets[i].transform.position;
            tempBullshit.y = 0;
            Targets[i].transform.position = tempBullshit;
            Targets[i].transform.LookAt(playerLoc);
        }


    }
}
