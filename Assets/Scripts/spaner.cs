using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaner : MonoBehaviour
{
    [SerializeField] GameObject[] Prefab;
    [SerializeField] float secondSpawn = 0.5f;
    [SerializeField] float minTras;
    [SerializeField] float maxTras;

    void Start()
    {
        StartCoroutine(FruitSpawn());
    }


        IEnumerator FruitSpawn()
        {
            while(true)
            {
                var wanted = Random.Range(minTras, maxTras);
                var position = new Vector3(wanted, transform.position.y);
                GameObject gameObject = Instantiate(Prefab[Random.Range(0, Prefab.Length)], 
                    position, Quaternion.identity);
                yield return new WaitForSeconds(secondSpawn);
                Destroy(gameObject, 5f);
            }
        }
}
