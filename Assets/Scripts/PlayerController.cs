using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float moveSpeed;
    private bool isMoving;
    private Vector2 input;
    private Animator animator;
    [SerializeField] private LayerMask solidObjectsLayer;
    private Rigidbody2D playerRigidBody;
    public LayerMask interactableLayer;
    private AudioSource audioSource;

    private void Awake()
    {
        if (GameManager.Instance.ShouldReturnToMainScene)
        {
            transform.position = GameManager.Instance.PlayerPosition;
            transform.rotation = GameManager.Instance.PlayerRotation;

            GameManager.Instance.ShouldReturnToMainScene = false;
        }
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    public void HandleUpdate()
    {

        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");
            if (input.x != 0) input.y = 0;

            if (input != Vector2.zero)
            {
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);
                var targetPos = transform.position;
                targetPos.x += input.x * moveSpeed * Time.deltaTime;
                targetPos.y += input.y * moveSpeed * Time.deltaTime;

                if (IsWalkable(targetPos))
                {
                    StartCoroutine(Move(targetPos));

                    if(!audioSource.isPlaying) {
                        audioSource.Play();
                    }
                }
            }
            else
            {
                audioSource.Stop();
            }
        }

        animator.SetBool("isMoving", isMoving);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Interact();
        }
    }

    void Interact()
    {
        var facingDir = new Vector3(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
        var interactPos = transform.position + facingDir;
        var collider = Physics2D.OverlapCircle(interactPos, 0.2f, interactableLayer);
        if (collider != null)
        {
            collider.GetComponent<Interactable>()?.Interact();
        }
    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            playerRigidBody.MovePosition(targetPos);
            yield return null;
        }
        transform.position = targetPos;
        isMoving = false;
    }

    private bool IsWalkable(Vector3 targetPos)
    {
        if (Physics2D.OverlapCircle(targetPos, 0.2f, solidObjectsLayer | interactableLayer) != null)
        {
            return false;
        }
        return true;
    }
}