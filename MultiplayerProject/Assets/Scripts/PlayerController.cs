using Unity.Netcode;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    public float speed = 5f;

    private NetworkVariable<Vector3> netPosition = new NetworkVariable<Vector3>(
        writePerm: NetworkVariableWritePermission.Owner
    );

    void Update()
    {
        if (IsOwner)
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveY = Input.GetAxis("Vertical");

            Vector3 move = new Vector3(moveX, moveY) * speed * Time.deltaTime;
            transform.position += move;

            netPosition.Value = transform.position; // Update the synced position
        }
        else
        {
            // Apply synced position from the owner
            transform.position = netPosition.Value;
        }
    }
}
