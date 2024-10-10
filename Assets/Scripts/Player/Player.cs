using UnityEngine;

[RequireComponent (typeof(CharacterController))]
public class Player : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        CharacterController characterController = GetComponent<CharacterController> ();
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, Vector3.right + Vector3.forward + Vector3.up * characterController.height);        
    }
}