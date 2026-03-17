using UnityEngine;
using Unity.Netcode;
using UnityEngine.InputSystem;

public class NetworkPlayer : NetworkBehaviour
{
    private float speed = 5f;
    private PlayerInput PlayerInput;
    private InputAction moveAction;

    public override void OnNetworkSpawn()
    {
        if (!IsOwner) return;

        PlayerInput = GetComponent<PlayerInput>();

        moveAction = PlayerInput.actions["Move"];

        PlayerInput.enabled = true;
        moveAction.Enable();
    }

    public override void OnNetworkDespawn()
    {
        if (!IsOwner) return;

        moveAction?.Disable();
    }

    private void Update()
    {
        if (!IsOwner || !IsSpawned) return;

        Vector2 move = moveAction.ReadValue<Vector2>();
        Vector3 move3 = new Vector3(move.x, 0f, move.y) * speed * Time.deltaTime;
        transform.position += move3;
    }
}
