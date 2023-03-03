using UnityEngine;

public class CarController : MonoBehaviour {
    private float defloaltSpeed;
    private float maxSpeed = 200;
    private float minSpeed = 100;
    private float rayLong = 50;
    private Rigidbody rb;
    private Renderer renderer;
    private bool isStop;
    [SerializeField] float magnitude;
    private void Start() {
        renderer = GetComponent<Renderer>();
        rb = this.gameObject.GetComponent<Rigidbody>();
        defloaltSpeed = Random.RandomRange(minSpeed, maxSpeed);
    }
    private void Update() {
        if (transform.position.y < -10)
            Destroy(this.gameObject);
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * rayLong, Color.green);

        if (Physics.Raycast(transform.position, transform.forward, out hit, rayLong)) {
            isStop = hit.collider.tag == "barier" || hit.collider.tag == tag ? true : false;
        } else {
            isStop = false;
        }

        if (isStop == true)
            Stop();
        else
            MoveForward();
        magnitude = rb.velocity.magnitude;
    }
    private bool isCrashed = false;
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == 3) {
            GetComponent<Renderer>().material.color = Color.red;
            isCrashed = true;
            Destroy(this.gameObject, 3);
        }
    }

    private void MoveForward() {
        if (!isCrashed) {

        renderer.material.color = Color.blue;
        float deltaTime = Time.fixedDeltaTime;
        if (rb.velocity.magnitude < 70)
            deltaTime *= 10;

        rb.AddForce(transform.forward * defloaltSpeed * deltaTime);
        }
    }
    private void Stop() {
        if(!isCrashed)
            renderer.material.color = Color.yellow;
        if (rb.velocity.magnitude > 1) {
            rb.velocity -= rb.velocity * Time.fixedDeltaTime;
        }
    }
}