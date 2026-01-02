using UnityEngine;

public class HeadBob : MonoBehaviour
{
    [SerializeField] private float speedHeadBob = 5f;
    [SerializeField] private float bobbingAmout = 0.1f;
    public PlayerController playerControllerScript;
    private float _defaultPositionCamera;
    private float _time = 0;

    void Awake()
    {
        _defaultPositionCamera = transform.localPosition.y;
    }

    void Update()
    {
        if (Mathf.Abs(playerControllerScript.rb.linearVelocity.x) > 0.1f || Mathf.Abs(playerControllerScript.rb.linearVelocity.z) > 0.1f)
        {
            _time += Time.deltaTime * speedHeadBob;
            transform.localPosition = new Vector3(transform.localPosition.x, _defaultPositionCamera + Mathf.Sin(_time) * bobbingAmout, transform.localPosition.z);
        }
        else
        {
            _time = 0;
            transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(transform.localPosition.x, _defaultPositionCamera, transform.localPosition.z), Time.deltaTime * speedHeadBob);
        }
    }
}
