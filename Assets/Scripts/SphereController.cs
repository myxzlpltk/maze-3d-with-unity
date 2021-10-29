using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SphereController : MonoBehaviour
{
    private Rigidbody rg;
    public float speed = LevelManager.speed;
    public AudioSource moveAudio;
    public AudioSource portalAudio;
    public AudioSource hitAudio;

    public AnimationCurve volumeCurve;
    public AnimationCurve pitchCurve;
    private bool moveable = true;

    public GameObject pausedObject;
    public GameObject gameWinObject;
    public Text levelTextObject;
    public Button nextLevelButton;


    // Start is called before the first frame update
    void Start()
    {
        levelTextObject.text = "Level " + LevelManager.name;
        rg = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moveable && Input.GetKey("w"))
        {
            Vector3 maju = new Vector3(0, 0, 1);
            rg.AddForce(maju * speed);
        }

        if (moveable && Input.GetKey("a"))
        {
            Vector3 kiri = new Vector3(-1, 0, 0);
            rg.AddForce(kiri * speed);
        }

        if (moveable && Input.GetKey("s"))
        {
            Vector3 mundur = new Vector3(0, 0, -1);
            rg.AddForce(mundur * speed);
        }

        if (moveable && Input.GetKey("d"))
        {
            Vector3 kanan = new Vector3(1, 0, 0);
            rg.AddForce(kanan * speed);
        }
    }

    public void Pause()
    {
        moveable = false;
        pausedObject.SetActive(true);
    }

    public void Resume()
    {
        moveable = true;
        pausedObject.SetActive(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit() => Application.Quit();

    public void NextLevel() => LevelManager.NextLevel();

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "YouAreWin")
        {
            moveable = false;

            moveAudio.Stop();
            portalAudio.Play();

            gameObject.SetActive(false);

            Debug.Log(LevelManager.IsLastLevel);
            if(LevelManager.IsLastLevel)
                nextLevelButton.interactable = false;

            gameWinObject.SetActive(true);
        }
        else if(collision.gameObject.tag == "Wall")
        {
            hitAudio.Play();
        }
    }

    private void FixedUpdate()
    {
        var currentSpeed = rg.velocity.magnitude;

        // normalize speed into 0-1
        var scaledVelocity = Remap(Mathf.Clamp(currentSpeed, 0, speed), 0, speed, 0, 1);

        // set volume based on volume curve
        moveAudio.volume = volumeCurve.Evaluate(scaledVelocity);

        // set pitch based on pitch curve
        moveAudio.pitch = pitchCurve.Evaluate(scaledVelocity);
    }

    public float Remap(float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }
}
