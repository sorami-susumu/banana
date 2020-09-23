using UnityEngine;

public class Controller : MonoBehaviour
{
    private Vector3 deltaObjectPosition;
    private const float SPEED = 5f;
    private const float ANGLE_SPEED = 50f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var deltaHorizontal = Input.GetAxis("Horizontal");
        if (deltaHorizontal != 0) {
            var rot = Quaternion.AngleAxis(Time.deltaTime * deltaHorizontal * ANGLE_SPEED, Vector3.up);
            transform.rotation = transform.rotation * rot; 
        }
        if (Input.GetKey(KeyCode.Space)) {
            transform.position += new Vector3(
                Time.deltaTime * SPEED * Mathf.Sin(transform.rotation.eulerAngles.y * Mathf.Deg2Rad),
                0,
                Time.deltaTime * SPEED * Mathf.Cos(transform.rotation.eulerAngles.y * Mathf.Deg2Rad)
            );
        }
    }
}
