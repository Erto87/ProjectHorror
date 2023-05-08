using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private float health;
    private float lerpTimer;
    public float maxHealth = 100;
    public float chipSpeed = 2;
    public Image frontHealthBar;
    public Image backHealthBar;

    public Image overlay;
    public float duration;
    public float fadeSpeed;
    private float durationTimer;
    public bool playerDead;
    public GameObject healthImage;
    public Animator animator;
    public Image greenhealth;
    public bool healtgain;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 0);
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
        DeadMan();
        health = Mathf.Clamp(health, 0, maxHealth);
        UpdateHealthUI();


        if (greenhealth.color.a > 0)

        {
            Debug.Log("healtgained");


            durationTimer += Time.deltaTime;
            if (durationTimer > duration)
            {
                float tempAlpha = greenhealth.color.a;
                tempAlpha -= Time.deltaTime * fadeSpeed;
                greenhealth.color = new Color(greenhealth.color.r, greenhealth.color.g, greenhealth.color.b, tempAlpha);


            }
        }

           if (overlay.color.a > 0)
        {
            if (health < 30)
                return;
            durationTimer += Time.deltaTime;
            if (durationTimer > duration)
            {
                float tempAlpha = overlay.color.a;
                tempAlpha -= Time.deltaTime * fadeSpeed;
                overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, tempAlpha);
            }
        }



    }
    public void UpdateHealthUI()
    {
        //Debug.Log(health); // Tulostaa pelaajan nykyisen healthin konsoliin
        float fillF = frontHealthBar.fillAmount; // Otetaan muuttujaan täytetyn etupalkin täyttöaste
        float fillB = backHealthBar.fillAmount; // Otetaan muuttujaan täytetyn taustapalkin täyttöaste
        float hFraction = health / maxHealth; // Lasketaan pelaajan healthin suhde maksimi healthiin.
        if (fillB > hFraction) // Jos taustapalkin täyttöaste on suurempi kuin pelaajan healthin suhde makshealthiin.
        {
            frontHealthBar.fillAmount = hFraction; // Asetetaan etupalkin täyttöaste pelaajan elämäpistemäärän suhteeksi maksimielämäpistemäärään
            backHealthBar.color = Color.red; // Asetetaan taustapalkin väri punaiseksi
            lerpTimer += Time.deltaTime; // Ajanotto käynnistyy
            float percentComplete = lerpTimer / chipSpeed; // Lasketaan kulunut aika suhteessa chipSpeed-muuttujaan
            percentComplete = percentComplete * percentComplete; // Otetaan kvadraatti prosenttimäärän laskemiseksi
            backHealthBar.fillAmount = Mathf.Lerp(fillB, hFraction, percentComplete); // Lerpataan taustapalkin täyttöastetta hFraction-muuttujan suuntaan prosenttimäärän mukaan
        }
        if (fillF < hFraction) // Jos etupalkin täyttöaste on pienempi kuin pelaajan elämäpistemäärän suhde maksimielämäpistemäärään
        {
            backHealthBar.fillAmount = hFraction; // Asetetaan taustapalkin täyttöaste pelaajan elämäpistemäärän suhteeksi maksimielämäpistemäärään
            backHealthBar.color = Color.green; // Asetetaan taustapalkin väri vihreäksi
            lerpTimer += Time.deltaTime; // Ajanotto käynnistyy
            float percentComplete = lerpTimer / chipSpeed; // Lasketaan kulunut aika suhteessa chipSpeed-muuttujaan
            percentComplete = percentComplete * percentComplete; // Otetaan kvadraatti prosenttimäärän laskemiseksi
            frontHealthBar.fillAmount = Mathf.Lerp(fillF, backHealthBar.fillAmount, percentComplete); // Lerpataan etupalkin täyttöastetta taustapalkin täyttöasteen suuntaan prosenttimäärän mukaan
        }
    }
    public void TakeDamage(float damage) //metodi vähentää pelaajan terveyttä vahingon verran
    {
        health -= damage; //vähennetään pelaajan terveyttä
        lerpTimer = 0f; //asetetaan lerpTimer nollaan
        Debug.Log("Damage otettu"); //tulostetaan "Damage otettu"
        durationTimer = 0; //asetetaan durationTimer nollaan
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 1); //asetetaan overlayn väri täydeksi punaiseksi
    }

    public void RestoreHealth(float healAmount) //metodi palauttaa pelaajan terveyttä annetun määrän
    {
        health += healAmount; //lisätään pelaajan terveyttä
        lerpTimer = 0f; //asetetaan lerpTimer nollaan
        Debug.Log("Healthia saatu"); //tulostetaan "Healthia saatu"¨
        durationTimer = 0; //asetetaan durationTimer nollaan
        healtgain = true;
        greenhealth.color = new Color(greenhealth.color.r, greenhealth.color.g, greenhealth.color.b, 1);




    }
    public void TestInterac()
    {
        Debug.Log("Interact toimii");
    }

    public void DeadMan() //metodi tarkistaa, onko pelaaja kuollut
    {
        if (health <= 0) //jos pelaajan terveys on pienempi tai yhtäsuuri kuin nolla
        {
            playerDead = true; //merkitään pelaaja kuolleeksi
        }
    }
}