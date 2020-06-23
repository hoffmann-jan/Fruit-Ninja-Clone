using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    private Rigidbody2D rigidbodyBlade;

    private void Awake()
    {
        rigidbodyBlade = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        SetBladeToMouse();
    }

    void SetBladeToMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10;
        rigidbodyBlade.position = Camera.main.ScreenToWorldPoint(mousePosition);
    }
}
