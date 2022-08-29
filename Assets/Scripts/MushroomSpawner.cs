using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomSpawner : MonoBehaviour
{
    public GameObject objPrefab;

    [SerializeField]
    private List<GameObject> deactivedPool;
    [SerializeField]
    private Transform mushroomPool;

    void FixedUpdate(){

        SpawnMushroom();
    }

    private void SpawnMushroom()
    {
        if(deactivedPool.Count > 0)
        {
            GameObject actMushroom = deactivedPool[0];
            deactivedPool.RemoveAt(0);
            actMushroom.transform.position = gameObject.transform.position;
            Mushroom mScript = actMushroom.GetComponent<Mushroom>();
            mScript.SetStart();
        }
        if (deactivedPool.Count <= 0)
        {
            GameObject mushroom = Instantiate(objPrefab, transform.position, Quaternion.identity, mushroomPool);
            Mushroom mScript = mushroom.GetComponent<Mushroom>();
            mScript.SetSpawner(gameObject);
        }
    }

    public void AddDead(GameObject obj)
    {
        deactivedPool.Add(obj);
    }

}
