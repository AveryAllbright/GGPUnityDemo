using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellManager : MonoBehaviour
{

    public GameObject FireBallPrefab;
    public GameObject MagicMissilePrefab;
    public GameObject RockWallPrefab;

   public  GameObject user;

    GameObject fireBall;
    GameObject magicMissile;
    GameObject rockWall;


    int m_nActiveSpell = 0;
    int m_nSpellCount = 2;

    public List<GameObject> LiveSpells;
    public List<GameObject> SpellBook;

    void Start()
    {
         fireBall = Instantiate(FireBallPrefab);
         magicMissile = Instantiate(MagicMissilePrefab);
         rockWall = Instantiate(RockWallPrefab);

        SpellBook.Add(fireBall);
        SpellBook.Add(magicMissile);
        SpellBook.Add(rockWall);

        user = GameObject.Find("FPSController");
       
    }


    void Update()
    {
        var input = (Input.GetAxis("Mouse ScrollWheel"));
        if (input > 0f)
        {
            m_nActiveSpell++;
            {
                if (m_nActiveSpell > m_nSpellCount) { m_nActiveSpell = 0; }
            }
        }
        else if (input < 0f)
        {
            m_nActiveSpell--;
            if (m_nActiveSpell < 0) { m_nActiveSpell = m_nSpellCount; }
        }

        if (Input.GetButtonUp("Fire1")) 
        {
            LiveSpells.Add(Instantiate(SpellBook[m_nActiveSpell]));
            LiveSpells[LiveSpells.Count - 1].GetComponent<SpellController>().SetUser(user);
        }

        foreach (GameObject spell in LiveSpells)
        {
            SpellController con = spell.GetComponent<SpellController>();
            if(con.lifeSpan <=0)
            {
                Destroy(spell);
            }
        }

        

    }
}
