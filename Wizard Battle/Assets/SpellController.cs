using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellController : MonoBehaviour {

    GameObject target;
    GameObject user;
    Vector3 direction;
    public int lifeSpan;
    float speed;
    int damage;

    public string Tag;

	// Use this for initialization
	void Start ()
    {

        switch (Tag)
        {
            case "FireBall": lifeSpan = 100; speed = 12f; damage = 8; direction = user.transform.forward; transform.position = user.transform.position + user.transform.forward; break;
            case "MagicMissile": lifeSpan = 250; speed = 8f; damage = 3; break;
            case "RockWall": lifeSpan = 500; break;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		switch(Tag)
            {
            case "FireBall": Fireball(); break;
            case "MagicMissile": MagicMissile(); break;
            case "RockWall": RockWall(); break;
        }
	}

    void Fireball()
    {
        transform.position += direction / speed;
        lifeSpan--;
        
    }

    void MagicMissile()
    {

    }

    void RockWall()
    {

    }

    public void SetUser(GameObject a_user)
    {
        user = a_user;
    }
}
