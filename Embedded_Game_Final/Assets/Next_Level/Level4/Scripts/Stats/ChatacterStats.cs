
using System;
using UnityEngine;

using UnityEngine.UI;

public class ChatacterStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth { get; private set; }

    public Stat armor;
    public Stat damage;
    public AudioClip deathsound;
    public AudioClip Hurtsound;
    AudioSource audio;
    public GameObject[]  damageUI;

    private void Awake()
    {
        currentHealth = maxHealth;
        audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            takedamage(10);
        }
    }

    public void takedamage(int damage)

    {
           
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0,int.MaxValue);
        Animator anim = GetComponentInChildren<Animator>();
        anim.SetBool("GetHurt",true);
        audio.PlayOneShot(Hurtsound);
        
        Invoke("ResetGetHurt", 2f);
        currentHealth -= damage;
        

        if(damageUI.Length!=0)
        {
            Debug.Log(transform.name + " take " + damage + " damage");
            int randomindex = UnityEngine.Random.Range(0, damageUI.Length);
            damageUI[randomindex].GetComponent<Text>().text = "-"+damage.ToString() + "hp";
           damageUI[randomindex].GetComponent<Animator>().SetTrigger("showScore");


        }

        if (currentHealth<=0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Debug.Log(transform.name + " is die");
        audio.PlayOneShot(deathsound);
    }

    void ResetGetHurt()
    {
        Animator anim = GetComponentInChildren<Animator>();
        anim.SetBool("GetHurt",false);
    }
}
