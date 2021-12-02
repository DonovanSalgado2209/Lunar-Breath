using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGrounded : MonoBehaviour
{
    private DippoloController dippolo;

    // Start is called before the first frame update
    void Start()
    {
        dippolo = GetComponentInParent<DippoloController>();

    }

    // Update is called once per frame
    void OnCollisionStay2D(Collision2D col)
    {
        dippolo.grounded = true;
    }
    void OnCollisionExit2D(Collision2D col)
    {
        dippolo.grounded = false;
    }
}
