using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    /// <summary>
    /// 最高速を決める変数(km/h)
    /// </summary>
    private float maxSpped = 60f;
    
    /// <summary>
    /// 加速度を決める変数(km/h*s)
    /// </summary>
    private float accelPerSecond = 5f;
    
    /// <summary>
    /// 旋回力を決める変数(deg/s)
    /// </summary>
    private float rotatePerSecond = 50f;

    private float speed;
    private Rigidbody rb = null;
    [SerializeField] private Text speedMeter = null;


    void Start()
    {
        speed = 0;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // スペースキーによる加速度の調整
        if (Input.GetKey(KeyCode.Space))
        {
            speed += accelPerSecond * Time.deltaTime;
            if (speed > maxSpped) speed = maxSpped;
        }
        else
        {
            speed -= accelPerSecond * Time.deltaTime;
            if (speed < 0) speed = 0;
        }
        rb.velocity = transform.forward * speed;
        speedMeter.text = $"<color=white>{speed.ToString("f2")} m/s</color>";

        var deltaHorizontal = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, rotatePerSecond * deltaHorizontal * Time.deltaTime);
    }
}
