using System;
using UnityEngine;

public class CarView : MonoBehaviour, ICarView {
    private const int MIN_Y = -5;
    public event Action Crash;
    public event Action Finish;
    private Rigidbody _rb;
    private bool _isEngineTurnedOn = true;
    private bool _isCrashed;
    public float AdditaionSpeedForStarting { get; set; }
    public float MaxMagnitudeForAdditionalSpeed { get; set; }
    public float RayLong { get; set; }
    public float Speed { get; set; }
    [SerializeField] float speed;

    private void Start() {
        _rb = this.gameObject.GetComponent<Rigidbody>();
        speed = Speed;
    }

    private void Update() {
        bool isRoadFree = CheckIfRoadFree();

        _isEngineTurnedOn = isRoadFree ? true : false;
        Move();
        if (transform.position.y < MIN_Y)
            Destroy(this.gameObject, 3);
    }
    private bool CheckIfRoadFree() {
        bool res;
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * RayLong, Color.green);

        if (Physics.Raycast(transform.position, transform.forward, out hit, RayLong)) {
            res = hit.collider.tag == "barier" || hit.collider.tag == tag ? false : true;
        } else {
            res = true;
        }
        return res;
    }
    private void Move() {
        if (_isCrashed || !_isEngineTurnedOn)
            return;
        var tmp = (_rb.velocity.magnitude < MaxMagnitudeForAdditionalSpeed) ? AdditaionSpeedForStarting : 1;
        _rb.AddForce(transform.forward * Speed * tmp * Time.fixedDeltaTime);
    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == 3) {
            GetComponent<Renderer>().material.color = Color.red;
            _isCrashed = true;
            Crash?.Invoke();
        }
        if(other.gameObject.tag == "finish") {
            Finish?.Invoke();
            Destroy(this.gameObject);
        }
    }
    public void EnableMoving() => _isEngineTurnedOn = true;
    public void DisableMoving() => _isEngineTurnedOn = false;
}