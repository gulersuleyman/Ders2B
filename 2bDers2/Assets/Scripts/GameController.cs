using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    [SerializeField] GameObject hazard;
    float spawnDelay = 0.5f;
    void Start()
    {
      StartCoroutine(  SpawnValues());
    }

    IEnumerator SpawnValues()
    {
        yield return new WaitForSeconds(1f);

        while (true)
        {
            for (int i = 0; i < 10; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-3, 3), 8, 0f);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);

                yield return new WaitForSeconds(spawnDelay);
            }
            yield return new WaitForSeconds(4f);
        }
        
    }

}
