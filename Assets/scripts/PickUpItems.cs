using Unity.VisualScripting;
using UnityEngine;

public class PickUpItems : MonoBehaviour
{
    private Rigidbody _rb;
    public Transform pointObject;
    private Collider _colliderItems;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _colliderItems = GetComponent<Collider>();
    }

    public void PickUp()
    {
        _rb.isKinematic = true;
        _colliderItems.enabled = false;

        transform.position = pointObject.position;
        transform.rotation = pointObject.rotation;
        transform.SetParent(pointObject);
    }

    public void Drop()
    {
        _rb.isKinematic = false;
        _colliderItems.enabled = true;

        transform.SetParent(null);
    }
}
