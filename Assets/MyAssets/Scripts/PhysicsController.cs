using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsController : MonoBehaviour {

  
    [SerializeField] private Animator m_animator;
    [SerializeField] private Rigidbody m_rb;

    public float speed = 5.0f;
    private float m_turnSpeed = 100f;
    private float m_jumpForce = 3;
    private float m_jumpTimeStamp = 0;
    private float m_minJumpInterval = 0.25f;
    private bool m_isGrounded;
    private bool m_wasGrounded;
    private List<Collider> m_collisions = new List<Collider>();


    void Update () {
        m_animator.SetBool("Grounded", m_isGrounded);
        m_wasGrounded = m_isGrounded;
    }

    void ForcesMovement()
    {
        float forwardSpeed = Input.GetAxis("Vertical") * speed;
         float strafeSpeed = Input.GetAxis("Horizontal") * speed;
        Vector3 forwardAcceleration = forwardSpeed * transform.forward;
        Vector3 strafeforwarAcceleration = strafeSpeed * transform.right;

        //m_rb.AddForce(forwardAcceleration + strafeforwarAcceleration, ForceMode.Acceleration);
        m_rb.AddForce(forwardAcceleration, ForceMode.Acceleration);
        transform.Rotate(0, Input.GetAxis("Horizontal") * m_turnSpeed * Time.deltaTime, 0);
        m_animator.SetFloat("MoveSpeed", forwardSpeed);


    }

    void FixedUpdate()
    {
        ForcesMovement();
        JumpingAndLanding();
    }

    private void JumpingAndLanding()
    {
        bool jumpCooldownOver = (Time.time - m_jumpTimeStamp) >= m_minJumpInterval;

        if (jumpCooldownOver && m_isGrounded && Input.GetKey(KeyCode.Space))
        {
            m_jumpTimeStamp = Time.time;
            m_rb.AddForce(Vector3.up * m_jumpForce, ForceMode.Impulse);

        }

        if (!m_wasGrounded && m_isGrounded)
        {
            m_animator.SetTrigger("Land");
        }

        if (!m_isGrounded && m_wasGrounded)
        {
            m_animator.SetTrigger("Jump");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint[] contactPoints = collision.contacts;
        for (int i = 0; i < contactPoints.Length; i++)
        {
            if (Vector3.Dot(contactPoints[i].normal, Vector3.up) > 0.5f)
            {
                if (!m_collisions.Contains(collision.collider))
                {
                    m_collisions.Add(collision.collider);
                }
                m_isGrounded = true;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (m_collisions.Contains(collision.collider))
        {
            m_collisions.Remove(collision.collider);
        }
        if (m_collisions.Count == 0) { m_isGrounded = false; }
    }



}
