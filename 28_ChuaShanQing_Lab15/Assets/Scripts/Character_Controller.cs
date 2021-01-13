using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character_Controller : MonoBehaviour
{
    public GameObject JumpText;
    public int JumpCount;

    private AudioSource audioSource;
    public AudioClip[] AudioClipArr;

    bool isOnFloor;

    float jumpForce = 10.0f;

    Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerJump();

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isOnFloor = true;
        }
    }

    //This allows it to jump onces
    private void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnFloor)
        {
            JumpCount++;
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnFloor = false;
            JumpText.GetComponent<Text>().text = "Jump: " + JumpCount;

            //To play a random audio clip
            int rand = Random.Range(0, AudioClipArr.Length);
            audioSource.PlayOneShot(AudioClipArr[rand]);
        }
    }
}
