using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class LookAtMouse : MonoBehaviour
{
    [SerializeField] InputActionAsset inputActions;
    InputAction lookAction;

    void Start()
    {
        lookAction = InputSystem.actions.FindAction("Look");
    }

    void Update()
    {
        Vector2 mouseScreenPos = lookAction.ReadValue<Vector2>();

        float distanceZ = Mathf.Abs(Camera.main.transform.position.z);
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(mouseScreenPos.x, mouseScreenPos.y, distanceZ));

        Vector2 direction = mouseWorldPos - transform.position;

        float angleZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 45;

        transform.rotation = Quaternion.Euler(0, 0, angleZ);
    }
}