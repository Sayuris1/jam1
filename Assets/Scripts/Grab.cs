using UnityEngine;

[RequireComponent(typeof(HingeJoint2D))]
public class Grab : MonoBehaviour
{
    private HingeJoint2D _hinge;
    private bool _isGrab;
    private Vector3 point;
    
    private void Start()
    {
        _hinge = GetComponent<HingeJoint2D>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _isGrab = false;
            _hinge.enabled = false;
            PlayerController.Instance.isGrabbing = false;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
            _isGrab = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Stickable") && _isGrab)
        {
            PlayerController.Instance.isGrabbing = true;
            _hinge.enabled = true;
            Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
            _hinge.connectedBody = rb;
            _hinge.anchor = transform.InverseTransformPoint(rb.position);
            _isGrab = false;
        }
    }
}
