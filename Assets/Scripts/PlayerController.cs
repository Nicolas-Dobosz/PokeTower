using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] InputActionAsset inputActions;

    InputAction moveAction;
    InputAction attackAction;
    Rigidbody2D body;
    Vector2 moveDirection;

    private Weapon currentWeapon;

    public float speed;

    void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        attackAction = InputSystem.actions.FindAction("Attack");
        body = GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        moveAction.Enable();
        attackAction.Enable();
    }

    void OnDisable()
    {
        moveAction.Disable();
        attackAction.Disable();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Weapon groundWeapon = other.GetComponent<Weapon>();

        if (groundWeapon != null)
        {
            EquipWeapon(groundWeapon);
        }
    }

    public void EquipWeapon(Weapon newWeapon)
{
    if (currentWeapon != null) Destroy(currentWeapon.gameObject);

    currentWeapon = newWeapon;

    newWeapon.transform.SetParent(this.transform);

    newWeapon.transform.localPosition = new Vector3(0.5f, -0.2f, 0f); 
    newWeapon.transform.localRotation = Quaternion.identity;

    if (newWeapon.TryGetComponent<Collider2D>(out var col)) col.enabled = false;
    if (newWeapon.TryGetComponent<Rigidbody2D>(out var rb)) rb.simulated = false;
}

    void Update()
    {
        if (attackAction.WasPressedThisFrame() && currentWeapon != null)
        {
            currentWeapon.Shoot();
        }
    }

    void FixedUpdate()
    {
        moveDirection = moveAction.ReadValue<Vector2>();
        body.linearVelocity = speed * Time.deltaTime * moveDirection;

        if (moveDirection.x > 0.1f)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if (moveDirection.x < -0.1f)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
    }
}
