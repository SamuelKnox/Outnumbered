using UnityEngine;
using System.Collections;

[RequireComponent(typeof(StateMachine))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(MoveSystem))]
[RequireComponent(typeof(BuildSystem))]
[RequireComponent(typeof(ShootSystem))]
public class PlayerController : MonoBehaviour
{
    private StateMachine stateMachine;
    private Animator animator;
    private MoveSystem moveSystem;
    private BuildSystem buildSystem;
    private ShootSystem shootSystem;

    void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        animator = GetComponent<Animator>();
        moveSystem = GetComponent<MoveSystem>();
        buildSystem = GetComponent<BuildSystem>();
        shootSystem = GetComponent<ShootSystem>();
    }
    // Update is called once per frame
    void Update()
    {
        moveSystem.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        animator.SetFloat("Movement Speed", rigidbody2D.velocity.sqrMagnitude);
        if (Input.GetButton("Build Barricade"))
        {
            buildSystem.Build(Resources.Load("Barricade") as GameObject);
            animator.SetTrigger("Building");
        }
        if (Input.GetButton("Build Turret"))
        {
            buildSystem.Build(Resources.Load("Turret") as GameObject);
            animator.SetTrigger("Building");
        }
        if (Input.GetButton("Shoot"))
        {
            shootSystem.Shoot(Resources.Load("Bullet") as GameObject);
            animator.SetTrigger("Shoot");
        }
    }
}
