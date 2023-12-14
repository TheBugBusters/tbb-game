using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    

    public float moveSpeed = 5.0f; // Adjust this to control the character's speed.
    private Vector3 targetPosition;
    private bool isMoving = false;
    Animator myAnimator;

    public string nomeDesafio;

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Raycast from the mouse click position to the ground or terrain.
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Get the target position from the raycast hit.
                targetPosition = hit.point;
                isMoving = true;
            }
        }
          // Rotate the character to face the target.
              if (isMoving)
        {    
            myAnimator.SetBool("moveFwd", true);

            Vector3 direction = targetPosition - transform.position;
            direction.y = 0; // Make sure the character doesn't tilt upwards.
            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10.0f); // Adjust the rotation speed here.
            }

            // Move the character towards the target position.
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // Check if the character has reached the target position.
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                isMoving = false;
                myAnimator.SetBool("moveFwd", false);
            }
        }
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.transform.CompareTag("professor1"))
        {
            isMoving = false;
            SceneManager.LoadScene(nomeDesafio);
        }
    }
}
