using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] FruitsToSpawnPrefab;
    public GameObject BombPrefab;
    public Transform[] SpawnPlaces;
    public float MiniumWait = 0.3f;
    public float MaximumWait = 1.0f;
    public float SpawnForceMin = 10;
    public float SpawnForceMax = 20;
    public float BombChance = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(nameof(SpawnFruits));
    }

    IEnumerator SpawnFruits()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(MiniumWait, MaximumWait));

            Transform rndTransform = SpawnPlaces[Random.Range(0, SpawnPlaces.Length)];

            GameObject rndGameObject = null;

            float rnd = Random.value;

            if (rnd <= BombChance)
            {
                rndGameObject = BombPrefab;
            }
            else
            {
                rndGameObject = FruitsToSpawnPrefab[Random.Range(0, FruitsToSpawnPrefab.Length)];
            }

            GameObject friut = Instantiate<GameObject>(rndGameObject, rndTransform.position, rndTransform.rotation);
            friut.GetComponent<Rigidbody2D>().AddForce(rndTransform.up * Random.Range(SpawnForceMin, SpawnForceMax), ForceMode2D.Impulse);

            Debug.Log("Fruit Created");

            Destroy(friut, GlobalVariables.FRUIT_REMOVE_TIME_SEC);
        }
    }
}
