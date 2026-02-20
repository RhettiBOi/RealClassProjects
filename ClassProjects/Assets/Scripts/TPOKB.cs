using UnityEngine;
using UnityEngine.InputSystem;

public class TPOKB : MonoBehaviour
{
    [SerializeField] private InputActionReference P1Move;
    [SerializeField] private InputActionReference P2Move;
    [SerializeField] private InputActionReference P1Jumping;
    [SerializeField] private InputActionReference P2Jumping;

    [SerializeField] private GameObject P1;
    [SerializeField] private GameObject P2;

    [SerializeField] private float speed = 5f;
    [SerializeField] private float JumpForce = 100f;

    /*public Rigidbody rb1;
    public Rigidbody rb2;*/

    private void OnEnable()
    {
        P1Move.action.Enable();
        P2Move.action.Enable();
        P1Jumping.action.Enable();
        P2Jumping.action.Enable();

       //P1Jumping.action.performed += ctx => P1Jump();
       //P2Jumping.action.performed += ctx => P2Jump();
    }

    private void OnDisable()
    {
        P1Move.action.Disable();
        P2Move.action.Disable();
        P1Jumping.action.Disable();
        P2Jumping.action.Disable();
    }

    private void Update()
    {
        //CharacterController controller = GetComponent<CharacterController>();

        var m1 = P1Move.action.ReadValue<Vector2>();
        var m2 = P2Move.action.ReadValue<Vector2>();

        if (P1) P1.transform.position += new Vector3(m1.x, 0f, m1.y) * speed * Time.deltaTime;
        if (P2) P2.transform.position += new Vector3(m2.x, 0f, m2.y) * speed * Time.deltaTime;

        if (P1Jumping.action.triggered/* && controller.isGrounded*/)
        {
            P1.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }

        if (P2Jumping.action.triggered)
        {
            P2.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }

    }

   /* void P1Jump()
    {
        P1.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * JumpForce);
        Debug.Log("Jump Pressed");
    }

    void P2Jump()
    {
        P2.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * JumpForce);
    }*/
}
