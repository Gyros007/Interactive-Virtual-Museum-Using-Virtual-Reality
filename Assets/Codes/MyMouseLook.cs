using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VIDE_Data;


public class MyMouseLook : MonoBehaviour
{

    public float mouseSensitivity;
	public Transform playerBody;
	
	float xRotation = 0f;
	Camera cam;
    Text messageText;
    Outline messageOutline;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
		cam = Camera.main;
        messageText = GameObject.Find("Canvas/Text").GetComponent<Text>();
        messageOutline = GameObject.Find("Canvas/Text").GetComponent<Outline>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!VD.isActive)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
            //float mouseX = 0f;
            //float mouseY = 0f;
            //if (Input.GetKey(KeyCode.UpArrow))
            //{
            //    mouseY = 100f;
            //}
            //if (Input.GetKey(KeyCode.DownArrow))
            //{
            //    mouseY = -100f;
            //}
            //if (Input.GetKey(KeyCode.LeftArrow))
            //{
            //    mouseX = -100f;
            //}
            //if (Input.GetKey(KeyCode.RightArrow))
            //{
            //    mouseX = 100f;
            //}

            xRotation -= mouseY * Time.deltaTime;
			xRotation = Mathf.Clamp(xRotation, -90f, 90f);

			transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
			playerBody.Rotate(Vector3.up * mouseX * Time.deltaTime);
		}
		
		float distance = 15f;
		RaycastHit hit;
        messageText.text = "";

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, distance))
        {
            if (hit.transform.CompareTag("NPC") && !VD.isActive)
            {
                messageText.text = "Press F to talk with " + hit.transform.name;
                messageOutline.effectColor = new Color32(0, 0, 0, 255);
                switch (hit.transform.name)
                {
                    case "Poseidon":
                        messageText.color = new Color32(0, 63, 255, 255);
                        break;
                    case "Demeter":
                        messageText.color = new Color32(45, 204, 90, 255);
                        break;
                    case "Zeus":
                        messageText.color = new Color32(0, 255, 255, 255);
                        break;
                    case "Hera":
                        messageText.color = new Color32(152, 74, 200, 255);
                        break;
                    case "Hades":
                        messageText.color = new Color32(142, 72, 44, 255);
                        break;
                    case "Dionysus":
                        messageText.color = new Color32(92, 58, 44, 255);
                        break;
                    case "Ares":
                        messageText.color = new Color32(0, 0, 0, 255);
                        messageOutline.effectColor = new Color32(255, 255, 255, 255);
                        break;
                    case "Hephaestus":
                        messageText.color = new Color32(241, 176, 62, 255);
                        break;
                    case "Athena":
                        messageText.color = new Color32(217, 102, 89, 255);
                        break;
                    case "Aphrodite":
                        messageText.color = new Color32(255, 0, 175, 255);
                        break;
                    case "Hermes":
                        messageText.color = new Color32(109, 105, 245, 255);
                        break;
                    case "Apollo":
                        messageText.color = new Color32(192, 147, 3, 255);
                        break;
                    case "Artemis":
                        messageText.color = new Color32(148, 236, 74, 255);
                        break;
                    default:
                        messageText.color = new Color32(255, 255, 255, 255);
                        break;
                }
            }
            if (hit.transform.CompareTag("Object") && !VD.isActive)
            {
                messageText.text = "Press F to interact";
                messageText.color = new Color32(255, 255, 255, 255);
            }
        }
    }
}
