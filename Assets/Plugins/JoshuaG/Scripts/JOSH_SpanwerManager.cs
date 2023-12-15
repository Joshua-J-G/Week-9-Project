using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpawnType
{
    SpawnPoints,
    RandomSpawn
}


public class JOSH_SpanwerManager : MonoBehaviour
{
    public SpawnType spawnType = SpawnType.SpawnPoints;
    public GameObject SpawnPoints;
    [SerializeField] public List<JOSH_Spawnpoint> SPinList = new List<JOSH_Spawnpoint>();

    [SerializeField] public List<ISpawnable> SpawnableEnemies = new List<ISpawnable>();

    public bool maxAmountofEnimiesatonetime = false;
    public int Amount = 10;

    List<GameObject> amountofEnimesSpawned = new List<GameObject>();
    

    public Vector3 SpawnArea;
    public Vector3 DeadZone;
    // Start is called before the first frame update
    void Start()
    {
        foreach(ISpawnable si in SpawnableEnemies)
        {
            si.isabletospawn = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        amountofEnimesSpawned.RemoveAll(x => x == null);

        if (maxAmountofEnimiesatonetime)
        {
            if (amountofEnimesSpawned.Count < Amount)
            {
                foreach (ISpawnable s in SpawnableEnemies)
                {
                    if(s.completlydisable)
                    {
                        return;
                    }
                    if (s.isabletospawn)
                    {
                        switch (spawnType)
                        {
                            case SpawnType.SpawnPoints:
                                if (SPinList.Count != 0)
                                {
                                    GameObject tmp2 = Instantiate(s.gameObject);
                                    tmp2.transform.position = SPinList[Random.Range(0, SPinList.Count)].gameObject.transform.position;
                                    amountofEnimesSpawned.Add(tmp2);

                                }

                                break;
                            case SpawnType.RandomSpawn:
                                Vector3 pos = new Vector3();
                                pos.x = Random.Range(-SpawnArea.x, SpawnArea.x);
                                pos.y = Random.Range(-SpawnArea.y, SpawnArea.y);
                                pos.z = Random.Range(-SpawnArea.z, SpawnArea.z);
                                GameObject tmp = Instantiate(s.gameObject);
                                tmp.transform.position = pos;
                                amountofEnimesSpawned.Add(tmp);
                                StartCoroutine(s.Timer());
                                break;
                        }

                    }
                }
            }else
            {
                Debug.Log("Full Right Now");
            }
        }
        else
        {
            foreach (ISpawnable s in SpawnableEnemies)
            {
                if (s.completlydisable)
                {
                    return;
                }
                if (s.isabletospawn)
                {
                    switch (spawnType)
                    {
                        case SpawnType.SpawnPoints:
                            if (SPinList.Count != 0)
                            {
                                GameObject tmp2 = Instantiate(s.gameObject);
                                tmp2.transform.position = SPinList[Random.Range(0, SPinList.Count)].gameObject.transform.position;
                                //amountofEnimesSpawned.Add(tmp2);
                                StartCoroutine(s.Timer());
                            }
                            break;
                        case SpawnType.RandomSpawn:
                            Debug.Log("Spawning Enemy");
                            Vector3 pos = new Vector3();
                            pos.x = Random.Range(-SpawnArea.x, SpawnArea.x);
                            pos.y = Random.Range(-SpawnArea.y, SpawnArea.y);
                            pos.z = Random.Range(-SpawnArea.z, SpawnArea.z);
                            GameObject tmp = Instantiate(s.gameObject);
                            tmp.transform.position = pos;
                            StartCoroutine(s.Timer());
                            break;
                    }

                }else
                {
                    //Debug.Log("unabletospawn");
                }
            }
        }
    }

        public void OnDrawGizmos()
    {

        if (spawnType == SpawnType.RandomSpawn)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawCube(transform.position, SpawnArea);
            Gizmos.color = Color.white;
            Gizmos.DrawCube(transform.position, DeadZone);
        }
    }
}
