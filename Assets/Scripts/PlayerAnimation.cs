using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerAnimation : MonoBehaviour
{
    new Rigidbody rigidbody;
    Animator animator;
    [SerializeField] float walkThreshold = 0.2f;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        animator.SetBool("IsWalking", (Mathf.Abs(rigidbody.linearVelocity.x) + Mathf.Abs(rigidbody.linearVelocity.z)) > walkThreshold);

    }
}
