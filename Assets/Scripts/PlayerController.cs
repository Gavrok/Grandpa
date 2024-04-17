using UnityEngine;
using System.Collections;
using FMOD.Studio;

public class EnhancedCharacterController2D : MonoBehaviour
{
    [Header("Activation Control")]
    public bool isActive = true;

    // Boy
    [Header("Boy")]
    public GameObject BoySprite;
    public float walkSpeed1 = 5f;
    public float jumpHeight1 = 5f;
    public bool enableState1 = true;
    public Animator animatorBoy;

    // Man
    [Header("Man")]
    public GameObject ManSprite;
    public float walkSpeed2 = 3f;
    public float jumpHeight2 = 7f;
    public float longJumpHeight = 10f; 
    public float runUpTimeRequiredForLongJump = 2f;
    public bool enableState2 = false;
    private GameObject currentTeleporter;
    public bool AllowTeleport = true;
    private bool isTeleporting = false;
    public float teleportTime = 1f;
    public float teleportResetTime = 1f;
    public KeyCode teleportKey = KeyCode.E;
    public Animator animatorMan;

    // Grandad
    [Header("Grandad")]
    public GameObject GrandadSprite;
    public float walkSpeed3 = 4f;
    public float jumpHeight3 = 6f;
    public bool enableState3 = false;
    private float lastDirection;
    public Animator animator;

    // Ground check
    [Header("Ground Check Settings")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    //movement timer
    private float movementTimer = 0f;

    //other
    private Rigidbody2D rb;
    private bool isGrounded;
    private float currentWalkSpeed;
    private float currentJumpHeight;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (!isActive) return; //if not on, rest won't work

        // Update current movement settings based on active state
        if (enableState1)
        {
            currentWalkSpeed = walkSpeed1;
            currentJumpHeight = jumpHeight1;

        }
        else if (enableState2)
        {
            currentWalkSpeed = walkSpeed2;
            currentJumpHeight = jumpHeight2;
        }
        else if (enableState3)
        {
            currentWalkSpeed = walkSpeed3;
            currentJumpHeight = jumpHeight3;
        }

        // check if grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        float moveInput = Input.GetAxisRaw("Horizontal");
        bool isWalking = Mathf.Abs(moveInput) > 0;
        //man jump bool
        if (isGrounded && animatorMan.GetBool("isJumping"))
        {
            animatorMan.SetBool("isJumping", false);
        }
        //boy jump bool
        if (isGrounded && animatorBoy.GetBool("isJumping"))
        {
            animatorBoy.SetBool("isJumping", false);
        }

        // Walking
        if (enableState1 || enableState2 || enableState3)
        {
            if (isWalking)
            {
                // Player is moving
                rb.velocity = new Vector2(moveInput * currentWalkSpeed, rb.velocity.y);
                lastDirection = Mathf.Sign(moveInput);
                if (enableState1)
                {
                    rb.velocity = new Vector2(moveInput * currentWalkSpeed, rb.velocity.y);

                    if (moveInput != 0) // Ensure there is some input to avoid unnecessary flipping
                    {
                        BoySprite.transform.localScale = new Vector3(Mathf.Sign(moveInput) * Mathf.Abs(BoySprite.transform.localScale.x), BoySprite.transform.localScale.y, BoySprite.transform.localScale.z);
                    }
                    //make boy run
                    animatorBoy.SetBool("isWalking", isWalking);
                    animatorBoy.SetFloat("direction", Mathf.Sign(moveInput));

                    //may not need
                    float boyScaleX = Mathf.Abs(BoySprite.transform.localScale.x) * lastDirection;
                    BoySprite.transform.localScale = new Vector3(boyScaleX, BoySprite.transform.localScale.y, BoySprite.transform.localScale.z);
                }

                if (enableState2)
                {
                    rb.velocity = new Vector2(moveInput * currentWalkSpeed, rb.velocity.y);

                    if (moveInput != 0) // Ensure input to avoid unnecessary flipping
                    {
                        ManSprite.transform.localScale = new Vector3(Mathf.Sign(moveInput) * Mathf.Abs(ManSprite.transform.localScale.x), ManSprite.transform.localScale.y, ManSprite.transform.localScale.z);
                    }
                    //make man run
                    animatorMan.SetBool("isWalking", isWalking);
                    animatorMan.SetFloat("direction", Mathf.Sign(moveInput));



                    //need below?
                    float manScaleX = Mathf.Abs(ManSprite.transform.localScale.x) * lastDirection;
                    ManSprite.transform.localScale = new Vector3(manScaleX, ManSprite.transform.localScale.y, ManSprite.transform.localScale.z);
                }
            }
            else
            {
                // Player has stopped moving, maintain vertical velocity for falling/jumping
                rb.velocity = new Vector2(0, rb.velocity.y);
                //set man to idle
                animatorMan.SetBool("isWalking", isWalking);
                animatorMan.SetFloat("direction", Mathf.Sign(moveInput));
                //set boy to idle
                animatorBoy.SetBool("isWalking", isWalking);
                animatorBoy.SetFloat("direction", Mathf.Sign(moveInput));
            }

            animator.SetBool("isWalking", isWalking);
            if (isWalking)
            {
                animator.SetFloat("direction", lastDirection);
            }
        }

        if (enableState2 && isWalking)
        {
            movementTimer += Time.deltaTime; // Increment timer if Man is moving
        }
        else
        {
            movementTimer = 0f; // Reset timer if Man stops moving
        }

        // Jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            if (enableState1)
            {
                animatorBoy.SetBool("isJumping", true);
            }
            if (enableState2)
            {
                animatorMan.SetBool("isJumping", true);
                // Special handling for Man state
                if (movementTimer >= runUpTimeRequiredForLongJump)
                {
                    // Long jump for Man after sufficient run-up
                    rb.velocity = new Vector2(rb.velocity.x, longJumpHeight); // Apply long jump
                    
                }
                else
                {
                    // Normal jump for Man without sufficient run-up
                    rb.velocity = new Vector2(rb.velocity.x, jumpHeight2); // Use Man's normal jump height
                }
            }
            else
            {
                animatorBoy.SetBool("isJumping", true);
                // Handling for other states (Boy and Grandad)
                rb.AddForce(Vector2.up * currentJumpHeight, ForceMode2D.Impulse);
            }
        }

        if (Input.GetKeyDown(teleportKey) && enableState2 && !isTeleporting)
        {
            StartCoroutine(TeleportPlayer());
        }

    }

    IEnumerator TeleportPlayer()
    {
        isTeleporting = true; // Prevent teleportation from being triggered again immediately

        // Wait for a specific duration before teleporting
        yield return new WaitForSeconds(teleportTime);

        if (currentTeleporter != null)
        {
            transform.position = currentTeleporter.GetComponent<Teleporter>().GetDestination().position;
        }

        // Wait for the cooldown period after teleporting before allowing it again
        yield return new WaitForSeconds(teleportResetTime);

        isTeleporting = false; // Allow teleportation again
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            currentTeleporter = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            if (collision.gameObject == currentTeleporter)
            {
                currentTeleporter = null;
            }
        }
    }

    void OnDrawGizmos()
    {
        // Visualize the ground check in the editor
        if (groundCheck == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }

    public void UpdateStateObjects()
    {
        // Update GameObjects based on the active state
        if (BoySprite != null) BoySprite.SetActive(enableState1);
        if (ManSprite != null) ManSprite.SetActive(enableState2);
        if (GrandadSprite != null) GrandadSprite.SetActive(enableState3);
    }

}
