using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletFury;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] BulletManager bulletManager;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        LookAtMouse();
        HandleFiring();
        HandleMovement();
    }

    void HandleFiring()
    {
        if (Input.GetButton("Fire1"))
        {
            bulletManager.Spawn(transform.position, transform.up);
        }
    }

    void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 direction = new Vector2(horizontal, vertical);
        transform.Translate(direction * Time.deltaTime * moveSpeed, Space.World);
    }

    void LookAtMouse()
    {
        var mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Quaternion rotation = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);
        transform.rotation = rotation;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
    }
}
