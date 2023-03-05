using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    // which target the camer should follow
    public Transform target;
    // the amount player moves
    public Vector3 offset;

    // For example if you had a moving character in a game you could add damping to its speed to slowly increase it, in a smooth but reactive way.
    public float damping;

    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movePosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position,movePosition,ref velocity,damping);
    }
}
