using UnityEngine;

public class RopeSwing : MonoBehaviour
{
    public HingeJoint2D hingeJoint; // Assign in Inspector
    private Rigidbody2D rb;
    public EnhancedCharacterController2D PlayerControls;
    private bool canAttach = true;
    private float attachCooldown = 1f;
    public GameObject BoySpecifics;
    public GameObject ManSpecifics;
    public GameObject GrandpaSpecifics;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (PlayerControls.enableState1)
        {
            BoySpecifics.SetActive(true);
        }
        else
        {
            BoySpecifics.SetActive(false);
        }

    }

    void Update()
    {
        if (PlayerControls.enableState1)
        {
            BoySpecifics.SetActive(true);
        }
        else
        {
            BoySpecifics.SetActive(false);
        }

        if (hingeJoint.enabled && PlayerControls.enableState1)
        {
            PlayerControls.animatorBoy.SetBool("isSwinging", true);
            float swingInput = Input.GetAxis("Horizontal");
            rb.AddForce(new Vector2(swingInput * PlayerControls.walkSpeed1, 0)); // Adjust the force value (10f) as needed
        }


        if (Input.GetButtonDown("Jump") && hingeJoint.enabled && PlayerControls.enableState1)
        {
            // Disable the HingeJoint2D to detach from the rope
            hingeJoint.enabled = false;
            hingeJoint.connectedBody = null; // Disconnect the rope
            PlayerControls.animatorBoy.SetBool("isSwinging", false);

            // Optional: Apply a jumping force
            rb.AddForce(Vector2.up * PlayerControls.jumpHeight1, ForceMode2D.Impulse);

            //renable script
            if (PlayerControls != null) PlayerControls.enabled = true;

            canAttach = false;
            Invoke("EnableAttachment", attachCooldown);
        }
    }

    void EnableAttachment()
    {
        canAttach = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Rope") && !hingeJoint.enabled && canAttach && PlayerControls.enableState1)
        {
            // Enable the HingeJoint2D and connect to the rope's Rigidbody2D
            hingeJoint.enabled = true;
            hingeJoint.connectedBody = collision.attachedRigidbody;
            if (PlayerControls != null) PlayerControls.enabled = false;
        }
    }
}