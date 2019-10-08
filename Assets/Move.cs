using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    //First-Person Controller(For zombie game):
    //-Move
    //	-All 4 Directions
    //	-Jump
    //	-Sprint
    //		-Forward Cone(W, W-A, W-D)
    //		-Stamina
    //			-[1.5x] Speed when Stamina is not empty, [1.3x] Speed When Stamina is empty.
    //			-After[2] seconds of not using Stamina, regenerates[1 / 8] Max Stamina per second. (Takes[10] seconds to fully regenerate stamina from zero).
    //			-Drains[1 / 20] per second.
    //		-Can't use weapons.
    //-Shoot
    //	-Left-Click to Fire, If has ammo
    //	-Right-Click to Aim Down Sights
    //		-Smaller guns like pistols take[.25] seconds to aim down sights.
    //		-Bigger guns like Light Machine Guns take[.5] to aim down sights.

    [SerializeField] private float M_Speed = 20f;
    [SerializeField] private float M_SprintMultiplier = 1.5f;
    [SerializeField] private float M_ExhaustMultiplier = 1.3f;
    [SerializeField] private float M_Jump = 100f;
    [SerializeField] private Vector3 M_Direction = Vector3.zero;

    CharacterController cc;

    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (cc.isGrounded)
        {
            float hInput = Input.GetAxisRaw("Horizontal");
            float vInput = Input.GetAxisRaw("Vertical");

            Vector3 forw = transform.forward * vInput;
            Vector3 side = transform.right * hInput;

            M_Direction = (forw + side).normalized;
            M_Direction *= M_Speed;

            if (Input.GetButton("Jump"))
            {
                M_Direction.y = M_Jump;
            }
        }

        M_Direction.y -= 300.0f * Time.deltaTime;

        cc.Move(M_Direction * Time.deltaTime);
    }
}
