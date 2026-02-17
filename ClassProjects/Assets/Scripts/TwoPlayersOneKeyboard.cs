using UnityEngine;
using UnityEngine.InputSystem;

public class TwoPlayersOneKeyboard
{
    [SerializeField] private InputActionReference P1Move;
    [SerializeField] private InputActionReference P2Move;

    [SerializeField] private Transform P1;
    [SerializeField] private Transform P2;

    [SerializeField] private float speed = 5f;

    private void OnEnable()
    {
        P1Move.action.Enable();
        P2Move.action.Enable();
    }

    private void OnDisable()
    {
        P1Move.action.Disable();
        P2Move.action.Disable();
    }

    private void Update()
    {
       var m1 = P1Move.action.ReadValue<Vector2>();
       var m2 = P2Move.action.ReadValue<Vector2>();

        if (P1) P1.position += new Vector3(m1.x, 0f, m1.y) * speed * Time.deltaTime;
        if (P2) P2.position += new Vector3(m2.x, 0f, m2.y) * speed * Time.deltaTime;
    }
    
}
