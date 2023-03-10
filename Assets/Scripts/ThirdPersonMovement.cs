using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{

    public CharacterController  controller;
    public Transform cam; 
    public float speed = 6f;
    private Animator animator;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public AudioSource robotsound;
    public AudioSource walk;

    void Start()
    {
        animator = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
        StartCoroutine(PlaySoundEvery30Seconds());
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.enabled)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

            if (direction.magnitude >= 0.1f)
            {
                if (!walk.isPlaying)
                {
                    walk.Play();
                }
                animator.SetBool("Walking", true);
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                controller.Move(moveDir.normalized * speed * Time.deltaTime);
            } 
            else
            {
                animator.SetBool("Walking", false);
                walk.Stop();
            }
        }
    }
    private IEnumerator PlaySoundEvery30Seconds()
    {
        while (true)
        {
            yield return new WaitForSeconds(20);
            robotsound.Play();
        }
    }
}
