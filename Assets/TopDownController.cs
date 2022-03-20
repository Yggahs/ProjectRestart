using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownController : MonoBehaviour,IDamageable<int>
{
    public int health = 5;
    public int attackPower = 2;
    private Camera mainCamera;
    public float moveSpeed = 15f;
    private Rigidbody thisRigidbody;
    private Vector3 moveInput;
    private Vector3 moveVelocity;
    public Transform bulletHole;
    public GameObject bulletInstance;
   
    // Start is called before the first frame update
    void Start()
    {
        thisRigidbody = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();

    }

    // Update is called once per frame
    void Update()
    {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"),0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * moveSpeed;
        FaceMouse();

        if (Input.GetMouseButtonDown(0))
        {
            GameObject shotInstance = Instantiate(bulletInstance, bulletHole.position, Quaternion.identity);
            shotInstance.GetComponent<Bullet>().bulletPower = attackPower;
            shotInstance.GetComponent<Rigidbody>().velocity = transform.forward * 8;

        }
          
    }

    private void FixedUpdate()
    {
        thisRigidbody.velocity = moveVelocity;
    }

    private void FaceMouse()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;
        if (groundPlane.Raycast(ray, out rayLength))
        {
            Vector3 pointToLook = ray.GetPoint(rayLength);
            transform.LookAt(new Vector3 (pointToLook.x,transform.position.y,pointToLook.z));
        }
        
    }

    public void Damage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
    
}
