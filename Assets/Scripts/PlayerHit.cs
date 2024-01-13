using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHit : MonoBehaviour
{
    bool lose = false;
    float timer = 0;
    Animator animator;
    PlayerMovement playerMovement;
    [SerializeField] Sprite death;
    SpriteRenderer rendrer;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        rendrer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lose)
        {
            timer += Time.deltaTime;
        }
        if(timer > 2 && lose)
        {
            SceneManager.LoadScene("Lose");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "coin")
        {
            SceneManager.LoadScene("Win");
        }
        if (collision.gameObject.tag == "obs")
        {
            lose = true;
            animator.enabled = false;
            playerMovement.enabled = false;
            rendrer.sprite = death;
        }
    }
}
