using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public float MinimumVelocity = 0.1f;

    private Rigidbody2D rigidbodyBlade;
    private Vector3 lastPosition;
    private Collider2D bladeCollider2D;

    private void Awake()
    {
        rigidbodyBlade = GetComponent<Rigidbody2D>();
        bladeCollider2D = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        bladeCollider2D.enabled = IsMouseMoving();
        SetBladeToMouse();
    }

    void SetBladeToMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10;
        rigidbodyBlade.position = Camera.main.ScreenToWorldPoint(mousePosition);
    }

    bool IsMouseMoving()
    {
        Vector3 currentMousePosition = transform.position;
        float travelled = (currentMousePosition - lastPosition).magnitude;
        lastPosition = currentMousePosition;

        if (travelled > MinimumVelocity)
        {
            return true;
        }
        return false;
    }
}
