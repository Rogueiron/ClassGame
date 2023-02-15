using System.Threading;
using Unity.Netcode;
using UnityEngine;

public class Player_Controller1 : NetworkBehaviour
{
    public float speed = 5.0f;
    public float turnSpeed;
    public float horizontalInput;
    public float forwardInput;
    public float cameraYoffset = 2f;
    public Quaternion to = new Quaternion(0, 0, 0, 0);
    private float timeCount = 1.0f;
    private Camera playerCamera;
    // Start is called before the first frame update

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        if(base.IsOwner)
        {
            playerCamera = Camera.main;
            playerCamera.transform.position = new Vector3(transform.position.x, transform.position.y + cameraYoffset, transform.position.z);
            playerCamera.transform.rotation = new Quaternion(0,0,0,0);
            playerCamera.transform.SetParent(transform);
        }
        else
        {
            gameObject.GetComponent<Player_Controller1>().enabled = false;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);
        if (Input.GetKey(KeyCode.H))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, to, timeCount);
            timeCount = timeCount + Time.deltaTime;
        }


    }
}
