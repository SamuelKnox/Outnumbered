using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MoveSystem))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private MoveSystem moveSystem;
    private Animator animator;

    void Start()
    {
        moveSystem = GetComponent<MoveSystem>();
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        moveSystem.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        animator.SetFloat("Movement Speed", rigidbody2D.velocity.sqrMagnitude);
    }
}
