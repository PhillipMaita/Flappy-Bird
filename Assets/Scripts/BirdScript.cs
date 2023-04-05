using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class BirdScript : MonoBehaviour
{
    // these global variable will be set from the inspector.

    public Vector2 jumpForce = new Vector2(); //Represents bird jump force

    //private AudioSource audioSource;
    //public AudioClip splatSFX;

    private ParticleSystem pS;

    private bool dead = false;

    void Start()
    {
        // position the bird
        transform.position = new Vector2(-2f, 0f);
        //audioSource = GetComponent<AudioSource>();
        pS = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        // waiting for mouse input
        if (Input.GetButtonDown("Fire1") || Input.GetMouseButtonDown(0))
        {
            // setting bird's rigid body velocity to zero
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            // adding jump force to bird's rigid body
            GetComponent<Rigidbody2D>().AddForce(jumpForce);
        }

        // getting the real position, of the bird on the stage
        Vector2 stagePos = Camera.main.WorldToScreenPoint(transform.position);
        // if the bird leaves the stage...
        if ((stagePos.y > Screen.height || stagePos.y < 0) && dead == false)
        {
            // ... call die function
            StartCoroutine("Die");
            dead = true;
        }
    }

    // function to be executed once the bird enters in collision with anything
    void OnCollisionEnter2D()
    {
        // call die function
        StartCoroutine("Die");
    }

    IEnumerator Die()
    {

        //audioSource.PlayOneShot(splatSFX, 5);
        pS.Play();
        GetComponent<SpriteRenderer>().enabled = false;
        // reload the current scene - actually restart the game
        yield return new WaitForSeconds(.25f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}