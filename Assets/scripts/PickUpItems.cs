using Unity.VisualScripting;
using UnityEngine;

public class PickUpItems : MonoBehaviour
{
    public Transform pointObject;
    public float moveSpeed = 10f;
    public float rotationSpeed = 10f;
    private Rigidbody _rb;
    private bool _isPicked = false; 
    private Collider _colliderItems;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _colliderItems = GetComponent<Collider>();
    }

    void Update()
    {
        if (_isPicked)
        {
            AnimationObject();
        }
    }

    public void PickUp()
    {
        _isPicked = true;
        _rb.isKinematic = true;
        _colliderItems.enabled = false;

        // transform.position = pointObject.position;
        // transform.rotation = pointObject.rotation;
        // transform.SetParent(pointObject);
    }

    public void Drop()
    {
        _isPicked = false;
        _rb.isKinematic = false;
        _colliderItems.enabled = true;

        transform.SetParent(null);
    }

    public void AnimationObject()
    {
        transform.position = Vector3.MoveTowards(transform.position, pointObject.position, moveSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, pointObject.rotation, rotationSpeed * Time.deltaTime);
    }
}
