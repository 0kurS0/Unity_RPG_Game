using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController m_chrCont;
    public Transform m_camTransform;
    public Animator m_playerAnim;

    public float m_speed = 5f;
    public float m_turnSmoothTime = 0.1f;
    public float m_gravity = -9.81f;

    public Transform m_groundChecker;
    public float m_groundDistance = 0.4f;
    public LayerMask m_groundMask;

    float _turnSmoothVel;
    bool _isGrounded;

    Vector3 _vel;

    void Update(){
        _isGrounded = Physics.CheckSphere(m_groundChecker.position, m_groundDistance, m_groundMask);

        float _hor = Input.GetAxisRaw("Horizontal");
        float _ver = Input.GetAxisRaw("Vertical");
        Vector3 _dir = new Vector3(_hor, 0f, _ver).normalized;

        if(_dir.magnitude >= 0.1f){
            float _targetAngle = Mathf.Atan2(_dir.x, _dir.z) * Mathf.Rad2Deg + m_camTransform.eulerAngles.y;
            float _angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetAngle, ref _turnSmoothVel, m_turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, _angle, 0f);

            Vector3 _moveDir = Quaternion.Euler(0f, _targetAngle, 0f) * Vector3.forward;
            m_chrCont.Move(_moveDir.normalized * m_speed * Time.deltaTime);

            float _velZ = Vector3.Dot(_dir.normalized, transform.right);

            m_playerAnim.SetBool("isRunning", true);

            _vel.y += m_gravity * Time.deltaTime;
            m_chrCont.Move(_vel * Time.deltaTime);
        }
        else{
            m_playerAnim.SetBool("isRunning", false);
        }
    }
}