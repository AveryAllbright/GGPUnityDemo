using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellManager : MonoBehaviour
{

    public GameObject FireBallPrefab;
    public GameObject MagicMissilePrefab;
    public GameObject RockWallPrefab;
    public GameObject Lifter;

    public GameObject user;

    GameObject fireBall;
    GameObject magicMissile;
    GameObject rockWall;


   public int m_nActiveSpell = 0;
    int m_nSpellCount = 3;

    public float m_fCoolDown = 0f;

    public List<GameObject> LiveSpells;
    public List<GameObject> SpellBook;

    void Start()
    {
        /*
        fireBall = Instantiate(FireBallPrefab);
        fireBall.transform.position = new Vector3(0, -100, 0);

        magicMissile = Instantiate(MagicMissilePrefab);
        magicMissile.transform.position = new Vector3(0, -100, 0);

        rockWall = Instantiate(RockWallPrefab);
        rockWall.transform.position = new Vector3(0, -100, 0);

        Lifter = Instantiate(Lifter);

        SpellBook.Add(fireBall);
        SpellBook.Add(magicMissile);
        SpellBook.Add(rockWall);
        SpellBook.Add(Lifter);
        */
        user = GameObject.Find("FPSController");
        LiveSpells = new List<GameObject>();

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
            //GameObject temp = Instantiate(SpellBook[m_nActiveSpell]);
            // LiveSpells.Add(Instantiate(SpellBook[m_nActiveSpell]));
            // LiveSpells[LiveSpells.Count - 1].GetComponent<SpellController>().SetUser(user);

            GameObject temp = null;
            switch (m_nActiveSpell)
            {
                case 0: temp = Instantiate(FireBallPrefab); break;
                case 1: LiveSpells.Add(Instantiate(RockWallPrefab)); break;
                case 2: LiveSpells.Add(Instantiate(MagicMissilePrefab)); break;
                case 3: LiveSpells.Add(Instantiate(Lifter)); break;                   
            }

            temp.transform.position = user.transform.position;
            LiveSpells.Add((GameObject)Instantiate(temp, user.transform.position + user.GetComponentInChildren<Camera>().transform.forward, new Quaternion(0,0,0,0)));
            LiveSpells[LiveSpells.Count - 1].GetComponent<SpellController>().SetUser(user);


        }

        foreach (GameObject spell in LiveSpells)
        {
            SpellController con = spell.GetComponent<SpellController>();
            if (con.lifeSpan <= 0)
            {
                Destroy(spell);
                LiveSpells.Remove(spell);
                break;
            }
        }


        if (m_fCoolDown > 0)
        {
            m_fCoolDown -= Time.deltaTime;
            if (m_fCoolDown < 0) { m_fCoolDown = 0; }
        }

    }
}
