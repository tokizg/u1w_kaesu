using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class characterControll : MonoBehaviour
{
    CharacterController c_cCon;

    [SerializeField]
    float characterSpeed = 7f;

    Vector2 flickStartPos;
    Vector2 flickEndPos;

    Vector3 direction = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        c_cCon = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = 0;
        float yInput = 0;

        if (Input.GetMouseButtonDown(0))
        {
            flickStartPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            flickEndPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            xInput = flickEndPos.x - flickStartPos.x;
            yInput = flickEndPos.y - flickStartPos.y;
            direction = new Vector3(xInput, 0, yInput).normalized;
        }

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
