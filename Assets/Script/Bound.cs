using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Bound : MonoBehaviour
{
    private Rigidbody2D rigid;
    [SerializeField]
    private GameObject gum;
    private float power = 2.7f;
    [SerializeField]
    private GumAnimation gumAnimation;
    [SerializeField]
    private GameObject eyes;
    private float animx = 0;
    private float animy = 0;
    private int coins = 0;
    [SerializeField]
    private Text coinText = null;
    [SerializeField]
    private AudioClip audioClip;
    private AudioSource audioSource;

    void Awake()
    {
        ResetPosition();
        coinText.text = string.Format("{0}", PlayerPrefs.GetInt("coins"));
        rigid = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;
    }
    private void FixedUpdate()
    {
        if(Input.GetMouseButton(0))
        {
            Vector2 mousePosition = Input.mousePosition;
            if (Screen.width * 0.5f < mousePosition.x)
            {
                Rightmove();
            }
            else
            {
                Leftmove();
            }
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            Rightmove();
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            Leftmove();
        }
        else
        {
            animx = 0;
        }
        float distance = Vector2.Distance(transform.position, gum.transform.position);
        //float disf = gum.transform.position.y > transform.position.y ? 30;
        if (distance > 30)
        {
            
            Vector3 dist = (gum.transform.position - transform.position).normalized;
            Mathf.Clamp(distance, 0, 15);
            if (gum.transform.position.y > transform.position.y && Mathf.Abs(gum.transform.position.y - transform.position.y) > 5)
            {
                    power = 5.3f;
                    rigid.AddForce(Vector2.up * (distance * power), ForceMode2D.Impulse);
                    //rigid.AddForce(Vector2.up * (distance * power), ForceMode2D.Impulse);
            }
            else
            {
                rigid.AddForce(dist * (distance * power), ForceMode2D.Impulse);
            }
        }
    }
    public void Update()
    {
        if (rigid.velocity.y > 0)
        {
            animy = Mathf.Lerp(animy, 0.5f, 10 * Time.deltaTime);
        }
        else
        {
            animy = Mathf.Lerp(animy, 0f, 5 * Time.deltaTime);
        }
        eyes.transform.position = new Vector2   (Mathf.Lerp(eyes.transform.position.x,transform.position.x - animx,0.1f), transform.position.y + animy );
    }
    public void Jump(float power)
    {
        rigid.velocity = new Vector2(rigid.velocity.x, 0);
        rigid.AddForce(Vector2.up * power * Time.deltaTime, ForceMode2D.Impulse);
        this.power = 2.7f;
    }
    public void GumWall(int angle)
    {
        float posx = 0, posy = 0;
        switch(angle)
        {
            case 90:
                posx = 2f;
                break;
            case -90:
                posx = -2f;
                break;
            case 180:
                posy = 2f;
                break;
        }
        gumAnimation.transform.position = gum.transform.position;
        gumAnimation.gameObject.SetActive(true);
        gum.transform.position = new Vector3(transform.position.x + posx, transform.position.y + posy, -1);
            gum.transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void Rightmove()
    {
        rigid.AddForce(Vector2.right * 0.7f, ForceMode2D.Impulse);
        animx = -0.5f;
    }
    private void Leftmove()
    {
        rigid.AddForce(Vector2.right * -0.7f, ForceMode2D.Impulse);
        animx = 0.5f;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9) // 만약 부딪친 게임 오브젝트가 벽이라면
        {
            ContactPoint2D contact = collision.contacts[0];
            gumAnimation.transform.position = gum.transform.position;
            gumAnimation.gameObject.SetActive(true);
            gum.transform.position = new Vector3(contact.point.x, contact.point.y, -1);
            gum.transform.SetParent(null);
            if (contact.point.y < transform.position.y - 1.7f) // 자신보다 판정이 낮을 때
            {
                Jump(3100);
                //Debug.Log(contact.point.y);
                audioSource.Play();
            }
        }
        if (collision.gameObject.layer == 16)
        {
            ContactPoint2D contact = collision.contacts[0];
            gumAnimation.transform.position = gum.transform.position;
            gumAnimation.gameObject.SetActive(true);
            gum.transform.position = new Vector3(contact.point.x, contact.point.y, -1);
            gum.transform.SetParent(collision.transform);
            if (contact.point.y < transform.position.y - 1.7f) // 자신보다 판정이 낮을 때
            {
                Jump(3100);
                audioSource.Play();
            }
        }
        if (collision.gameObject.layer == 10) // 만약 부딪친 게임 오브젝트가 포인트라면
        {
            ContactPoint2D contact = collision.contacts[0];
            if (contact.point.y < transform.position.y - 1.7f) // 자신보다 판정이 낮을 때
            {
                Jump(3100);
            }
            if(collision.gameObject.CompareTag("Door"))
            {
                if(collision.gameObject.GetComponent<Door>().needcoin <= coins)
                {
                    collision.gameObject.SetActive(false);
                }
            }
        }
        if (collision.gameObject.layer == 13) // 만약 부딪친 게임 오브젝트가 얼음이라면
        {
            ContactPoint2D contact = collision.contacts[0];
            if (contact.point.y < transform.position.y - 1.7f) // 자신보다 판정이 낮을 때
            {
                Jump(3100);
            }
        }
        if (collision.gameObject.layer == 14) // 만약 부딪친 게임 오브젝트가 마그마이라면
        {
            Jump(6200);
        }
        if (collision.gameObject.layer == 15) // 만약 부딪친 게임 오브젝트가 슬라이더라면
        {
            ContactPoint2D contact = collision.contacts[0];
            gumAnimation.transform.position = gum.transform.position;
            gumAnimation.gameObject.SetActive(true);
            gum.transform.position = new Vector3(contact.point.x, contact.point.y, -1);
            gum.transform.SetParent(collision.transform);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9 || collision.gameObject.layer == 16) // 만약 부딪친 게임 오브젝트가 벽이라면
        {
            try
            {
                ContactPoint2D contact = collision.contacts[1];
                if (Mathf.Abs(contact.point.x - transform.position.x) < 0.1f && contact.point.y - transform.position.y < 0.1f)
                {
                    gumAnimation.transform.position = gum.transform.position;
                    gumAnimation.gameObject.SetActive(true);
                    gum.transform.position = new Vector3(contact.point.x, contact.point.y, -1);
                    gum.transform.SetParent(collision.transform);
                    Jump(3100);
                    audioSource.Play();
                }
            }
            catch(System.IndexOutOfRangeException)
            {

            }
            
        }
        if(collision.gameObject.layer == 13)
        {
            try
            {
                ContactPoint2D contact = collision.contacts[1];
                if (Mathf.Abs(contact.point.x - transform.position.x) < 0.1f && contact.point.y - transform.position.y < 0.1f)
                {
                    Jump(3100);
                    audioSource.Play();
                }
            }
            catch (System.IndexOutOfRangeException)
            {

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Flag"))
        {
            collision.gameObject.GetComponent<SavePoint>().SaveOn();
        }
        if (collision.gameObject.CompareTag("Coin"))
        {
            coins++;
            PlayerPrefs.SetInt("coins", coins);
            coinText.text = string.Format("{0}", coins);
            collision.gameObject.GetComponent<Coin>().Eat();
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Portal"))
        {
            collision.GetComponent<Portal>().Teleport();
        }
        if (collision.gameObject.CompareTag("Gravity"))
        {
            rigid.gravityScale = -5;
        }
        if (collision.gameObject.CompareTag("MagicIce"))
        {
            SceneManager.LoadScene("Ending");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gravity"))
        {
            rigid.gravityScale = 5;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Air"))
        {
            rigid.AddForce(Vector2.up * 20 * Time.deltaTime,ForceMode2D.Impulse);
        }
        if (collision.gameObject.CompareTag("AirDown"))
        {
            rigid.AddForce(Vector2.down * 20 * Time.deltaTime, ForceMode2D.Impulse);
        }
    }
    public void ResetPosition()
    {
        transform.position = new Vector2(PlayerPrefs.GetFloat("boundx"), PlayerPrefs.GetFloat("boundy"));
        gum.transform.position = new Vector3(transform.position.x,transform.position.y - 6.5f, -1);
    }
}
