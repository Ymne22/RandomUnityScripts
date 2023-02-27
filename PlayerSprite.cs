using UnityEngine;

public class PlayerSprite : MonoBehaviour
{
    public float speed = 5f;
    public float sprintSpeed = 10f;
    public int maxHP = 100;
    public int currentHP = 100;
    public Animator animator;
    private Rigidbody rb;
    private Vector3 moveDirection;
    private CameraController cameraController;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        cameraController = FindObjectOfType<CameraController>();
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : speed;
        rb.MovePosition(transform.position + moveDirection * currentSpeed * Time.fixedDeltaTime);

        if (moveDirection.magnitude > 0.1f)
        {
            float angle = Vector3.SignedAngle(Vector3.forward, moveDirection, Vector3.up);
            if (angle < 0) angle += 360;

            if (angle >= 45 && angle < 135)
            {
                animator.Play("Walk_Backward");
            }
            else if (angle >= 135 && angle < 225)
            {
                animator.Play("Walk_Left");
            }
            else if (angle >= 225 && angle < 315)
            {
                animator.Play("Walk_Forward");
            }
            else
            {
                animator.Play("Walk_Right");
            }
        }
        else
        {
            animator.Play("Idle");
        }
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        if (currentHP <= 0)
        {
            currentHP = 0;
        }
    }

    public void Heal(int amount)
    {
        currentHP += amount;
        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }
    }
}