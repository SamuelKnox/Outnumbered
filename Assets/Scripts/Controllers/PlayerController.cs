using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Mobility))]
[RequireComponent(typeof(Builder))]
[RequireComponent(typeof(Shooter))]
public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private Mobility mobility;
    private Builder builder;
    private Shooter shooter;

    void Start()
    {
        animator = GetComponent<Animator>();
        mobility = GetComponent<Mobility>();
        builder = GetComponent<Builder>();
        shooter = GetComponent<Shooter>();
    }
    // Update is called once per frame
    void Update()
    {
        mobility.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        animator.SetFloat("Movement Speed", rigidbody2D.velocity.sqrMagnitude);
        if (Input.GetButton("Build Barricade"))
        {
            builder.Build(Resources.Load("Barricade") as GameObject);
            animator.SetTrigger("Building");
        }
        if (Input.GetButton("Build Turret"))
        {
            builder.Build(Resources.Load("Turret") as GameObject);
            animator.SetTrigger("Building");
        }
        if (Input.GetButton("Shoot"))
        {
            shooter.Shoot(Resources.Load("Bullet") as GameObject);
            animator.SetTrigger("Shoot");
        }
        if (Input.GetButton("Destroy Structure"))
        {
            builder.DestroyStructure();
            animator.SetTrigger("Building");
        }
    }
}
