using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject SlicedFruitPrefab;
    public float ExplosionRadius = 5;
    public float ExplosionForceMin = 500;
    public float ExplosionForceMax = 1000;


    private void CreateSlicedFruit()
    {
        GameObject slicedFruit = Instantiate<GameObject>(SlicedFruitPrefab, transform.position, transform.rotation);
        Rigidbody[] rigidBodies = slicedFruit.GetComponentsInChildren<Rigidbody>();

        foreach(Rigidbody rigidbodyPart in rigidBodies)
        {
            rigidbodyPart.transform.rotation = Random.rotation;
            rigidbodyPart.AddExplosionForce(Random.Range(ExplosionForceMin, ExplosionForceMax), transform.position, ExplosionRadius);
        }

        FindObjectOfType<GameManager>()?.IncrementScore(3);

        Destroy(gameObject);
        Destroy(slicedFruit, GlobalVariables.FRUIT_REMOVE_TIME_SEC);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Blade>())
        {
            CreateSlicedFruit();
        }
    }
}
