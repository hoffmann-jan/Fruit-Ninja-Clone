using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Blade blade = collision.gameObject.GetComponent<Blade>();

        if (blade == null)
        {
            return;
        }

        FindObjectOfType<GameManager>().OnBombHit();
    }
}
