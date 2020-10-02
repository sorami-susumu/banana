using UnityEngine;
using UnityEngine.UI;

namespace Banana {
    public class Controller : MonoBehaviour
    {
        /// <summary>
        /// 最高速を決める変数(km/h)
        /// </summary>
        private float maxSpped = 60f;

        /// <summary>
        /// 最高速を決める変数(km/h)
        /// </summary>
        private float maxBrakeSpped = -5f;
    
        /// <summary>
        /// 加速度を決める変数(km/h*s)
        /// </summary>
        private float accelPerSecond = 5f;

        /// <summary>
        /// 加速度を決める変数(km/h*s)
        /// </summary>
        private float brakePerSecond = 10f;
    
        /// <summary>
        /// 旋回力を決める変数(deg/s)
        /// </summary>
        private float rotatePerSecond = 50f;

        private float speed;
        private Rigidbody rb = null;
        [SerializeField] private Text speedMeter = null;
        [SerializeField] private Text collisionPower = null;
        [SerializeField] private Camera mainCamera = null;
        private Vector3 forewardCameraPosition;
        private Quaternion forewardCameraRotation;
        private Vector3 backwardCameraPosition;
        private Quaternion backwardCameraRotation;

        void Start()
        {
            speed = 0;
            rb = GetComponent<Rigidbody>();
            PrepareCameraAngle();
        }

        private void PrepareCameraAngle()
        {
            forewardCameraPosition = new Vector3(0, 2f, -4.5f);
            forewardCameraRotation = Quaternion.Euler(0, 0, 0);
            backwardCameraPosition = new Vector3(0, 2f, 4.5f);
            backwardCameraRotation = Quaternion.Euler(0, 180f, 0);
        }

        // Update is called once per frame
        void Update()
        {
            Vecolity();
            Rotate();
            CameraAngle();
        }

        private void Vecolity()
        {
            // スペースキーによる加速度の調整
            if (Input.GetKey(KeyCode.Space))
            {
                speed += accelPerSecond * Time.deltaTime;
                if (speed > maxSpped) speed = maxSpped;
            } else if(Input.GetKey(KeyCode.B)){
                speed -= brakePerSecond * Time.deltaTime;
                if (speed < maxBrakeSpped) speed = maxBrakeSpped;
            } else
            {
                speed -= accelPerSecond * Time.deltaTime;
                if (speed < 0) speed = 0;
            }
            rb.velocity = transform.forward * speed;
            speedMeter.text = $"<color=white>{speed.ToString("f2")} m/s</color>";
        }

        private void Rotate()
        {
            var deltaHorizontal = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.up, rotatePerSecond * deltaHorizontal * Time.deltaTime);
        }

        private void CameraAngle()
        {
            if (Input.GetKey(KeyCode.M))
            {
                mainCamera.transform.localPosition = backwardCameraPosition;
                mainCamera.transform.localRotation = backwardCameraRotation;
                return;
            }
            mainCamera.transform.localPosition = forewardCameraPosition;
            mainCamera.transform.localRotation = forewardCameraRotation;
        }

        private void OnCollisionEnter(Collision collision)
        {
            var length = collision.relativeVelocity.magnitude;
            collisionPower.text = $"<color=white>{length.ToString("f2")} m/s^2?</color>";
        }
    }
}