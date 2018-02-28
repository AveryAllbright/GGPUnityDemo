using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellManager : MonoBehaviour
{

    public GameObject FireBallPrefab;
    public GameObject MagicMissilePrefab;
    public GameObject RockWallPrefab;
    public GameObject Lifter;

    public GameObject user = null;
    
    public int m_nActiveSpell = 0;
    int m_nSpellCount = 3;

    public float m_fCoolDown = 0f;

    public List<GameObject> LiveSpells;

    void Start()
    {
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

            
            switch (m_nActiveSpell)
            {
                case 0: GameObject tempFire = Instantiate(FireBallPrefab, user.transform.position + (user.GetComponentInChildren<Camera>().transform.forward * 4f), new Quaternion(0, 0, 0, 0)) as GameObject;
                        LiveSpells.Add(tempFire);
                    break;

                case 1:
                    GameObject tempRock = Instantiate(RockWallPrefab, user.transform.position + (user.GetComponentInChildren<Camera>().transform.forward * 2f) + new Vector3(0,-3, 0), new Quaternion(0, 0, 0, 0)) as GameObject;
                    tempRock.transform.LookAt(user.transform.position);
                    tempRock.transform.rotation = (new Quaternion(tempRock.transform.rotation.x, 0, tempRock.transform.rotation.z, 0));
                    LiveSpells.Add(tempRock);
                    break;

                case 2:
                    GameObject tempMiss = Instantiate(MagicMissilePrefab, user.transform.position + (user.GetComponentInChildren<Camera>().transform.forward * 4f), new Quaternion(0, 0, 0, 0)) as GameObject;
                    LiveSpells.Add(tempMiss);
                    break;

                case 3:
                    GameObject tempLift = Instantiate(Lifter, user.transform.position + (user.GetComponentInChildren<Camera>().transform.forward * 4f), new Quaternion(0, 0, 0, 0)) as GameObject;
                    LiveSpells.Add(tempLift);
                    break;                   
            }

            
            LiveSpells[LiveSpells.Count - 1].GetComponent<SpellController>().user = this.user;
            LiveSpells[LiveSpells.Count - 1].GetComponent<SpellController>().lifeSpan = 100;
            LiveSpells[LiveSpells.Count - 1].GetComponent<SpellController>().SetDirection();

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
