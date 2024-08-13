using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class characterControll : MonoBehaviour
{
    CharacterController c_cCon;

    [SerializeField]
    float characterSpeed = 7f;

    // Start is called before the first frame update
    void Start()
    {
        c_cCon = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(xInput, 0, yInput).normalized;

        if (direction.magnitude != 0f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            Vector3 moveDir =
                Quaternion.Euler(0f, targetAngle, 0f)
                    * Vector3.forward
                    * direction.magnitude
                    * characterSpeed
                    * Time.deltaTime
                + Physics.gravity;

            c_cCon.Move(moveDir);
        }
    }
}
