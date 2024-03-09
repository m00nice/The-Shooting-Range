using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float gravity = -9.8f;
    [SerializeField] private float gravMult = 1f;
    [SerializeField] private float jumpForce;
    [SerializeField] private float height;
    [SerializeField] private LayerMask ground;
    [SerializeField] private GameObject gunHolder;
    private PlayerWeapon playerWeapon;
    private float velocityVertical;
    private bool isGrounded;
    private bool canJump;
    private bool canDoubleJump;
    
    
    void Update()
    {
        GroundCheck(Physics.Raycast(transform.position, Vector3.down, height, ground));
        Gravity();
    }

    public void ShootGun()
    {
        gunHolder.GetComponentInChildren<PlayerWeapon>().Shoot();
    }

    public void Move(Vector2 input)
    {
        Vector3 direction = new Vector3(input.x, 0, input.y);
        characterController.Move(transform.TransformDirection(direction) * (movementSpeed * Time.fixedDeltaTime));
    }

    public void Jump()
    {
        if (isGrounded && canJump)
        {
            velocityVertical = jumpForce;
            canJump = false;
            StartCoroutine(JumpCooldown(0.3f));
        }
        else if(canDoubleJump && !isGrounded && canJump)
        {
            velocityVertical = jumpForce;
            canDoubleJump = false;
            canJump = false;
            StartCoroutine(JumpCooldown(0.3f));
        }
    }

    private void Gravity()
    {
        if (isGrounded && velocityVertical < 0.0f)
        {
            velocityVertical = -1.0f;
        }
        else
        {
            velocityVertical += gravity * gravMult * Time.deltaTime;
        }

        characterController.Move(new Vector3(0f, velocityVertical, 0f) * Time.deltaTime);

    }

    private void GroundCheck(bool check)
    {
        if (check)
        {
            canDoubleJump = true;
            isGrounded = true;
            canJump = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    private IEnumerator JumpCooldown(float num)
    {
        yield return new WaitForSeconds(num);
        canJump = true;
    }
    
}
