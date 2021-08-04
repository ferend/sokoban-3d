using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 2f;
    [SerializeField]
    float rayLenght = 1f;

    Vector3 targetPosition;
    Vector3 startPosition;
    bool moving;

    
    public LevelGoal level;
    
    private const float TimeStep = 0.02f;
    private float timer = 0;


    public float forceApplied = 50;

    void Update()
    {

        timer += Time.deltaTime;
        if (timer >= TimeStep)
        {
            timer = 0;
            SaveSystem.SavePlayer(this);
        }

        if (moving)
        {
            if(Vector3.Distance(startPosition, transform.position)>1f)
            {
                transform.position = targetPosition;
                moving = false;
                return;
            }
            transform.position += (targetPosition - startPosition) * moveSpeed * Time.deltaTime;
            return;
        }

      

        if (Input.GetKeyDown(KeyCode.W))
        {
            if(!Physics.Raycast(transform.position, Vector3.forward, rayLenght))
            {
                targetPosition = transform.position + Vector3.forward;
                startPosition = transform.position;
                moving = true;
            }
           
        } else if (Input.GetKeyDown(KeyCode.S))
        {
            if (!Physics.Raycast(transform.position, Vector3.back, rayLenght))
            {
                targetPosition = transform.position + Vector3.back;
            startPosition = transform.position;
            moving = true;
            }

        } else if (Input.GetKeyDown(KeyCode.A))
        {
            if (!Physics.Raycast(transform.position, Vector3.left, rayLenght))
            {

                targetPosition = transform.position + Vector3.left;
                startPosition = transform.position;
                moving = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (!Physics.Raycast(transform.position, Vector3.right, rayLenght))
            {
                targetPosition = transform.position + Vector3.right;
                startPosition = transform.position;
                moving = true;
            }
        }
     
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Pit")
        {
            FindObjectOfType<GameManager>().GameOver();
        }
    }
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;

        SceneManager.LoadScene(PlayerPrefs.GetInt("SavedScene"));
    }
}
