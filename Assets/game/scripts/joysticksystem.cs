using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joysticksystem : MonoBehaviour
{
    public VariableJoystick movejoystick;
  
    [SerializeField] public float moveh, movev, speedmove = 7;
    public Rigidbody rb;
    public bool isrunning;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        joystickmove();
    }
    public void joystickmove()
    {
        moveh = movejoystick.Horizontal;
        movev = movejoystick.Vertical;
        Vector3 dir = new Vector3(moveh, 0, movev);
        rb.velocity = new Vector3(moveh * speedmove, rb.velocity.y, movev * speedmove);
        if (dir != Vector3.zero)
        {
            transform.LookAt(transform.position + dir);
            isrunning = true;
        }
        else
            isrunning = false;


    }
}
