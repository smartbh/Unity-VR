using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class head : MonoBehaviour
{
    public playerSeo SEO;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        /*
        if ((other.gameObject.CompareTag("DMG1") || other.gameObject.CompareTag("DMG2") || other.gameObject.CompareTag("DMG3") || other.gameObject.CompareTag("DMG4"))
            && SEO.hitcheck == false)
        {
            Debug.Log("Hit is Active!!!!");
            SEO.PHit(10);
            other.gameObject.SetActive(false);
        }
        */

        /*
        if (other.gameObject.CompareTag("DMG1") && SEO.hitcheck == false)
        {
            SEO.PHit(2);
        }
        if (other.gameObject.CompareTag("DMG2") && SEO.hitcheck == false)
        {
            SEO.PHit(2);
        }
        if (other.gameObject.CompareTag("DMG3") && SEO.hitcheck == false)
        {
            SEO.PHit(2);
        }
        if (other.gameObject.CompareTag("DMG4") && SEO.hitcheck == false)
        {
            SEO.PHit(2);
        }
        if (other.gameObject.CompareTag("DMG5") && SEO.hitcheck == false)
        {
            SEO.PHit(2);
        }
        */

        /*
        if ((other.gameObject.CompareTag("DMG2-1") || other.gameObject.CompareTag("DMG3-1") || other.gameObject.CompareTag("DMG4-1"))
            && SEO.hitcheck == false) //  && manager.pointer == true
        {
            // 이건 맞으면 한방에 죽음
            Debug.Log("PHit(100) is Active!!!!");
            SEO.PHit(100);
            other.gameObject.SetActive(false);
        }
        
        
        if (other.gameObject.CompareTag("DMG2-1") && SEO.hitcheck == false) //  && manager.pointer == true
        {
            Debug.Log("PHit(100) is Active!!!!");
            SEO.PHit(100);
        }
        if (other.gameObject.CompareTag("DMG3-1") && SEO.hitcheck == false) //  && manager.pointer == true
        {
            Debug.Log("PHit(100) is Active!!!!");
            SEO.PHit(100);
        }
        if (other.gameObject.CompareTag("DMG4-1") && SEO.hitcheck == false) //  && manager.pointer == true
        {
            Debug.Log("PHit(100) is Active!!!!");
            SEO.PHit(100);
        }
        if (other.gameObject.CompareTag("DMG5-1") && SEO.hitcheck == false) //  && manager.pointer == true
        {
            Debug.Log("PHit(100) is Active!!!!");
            SEO.PHit(100);
        }
        */

        
        if (SEO.hitcheck == false)
        {
            switch (other.gameObject.tag)
            {
                case "DMG1":
                    SEO.PHit(25);
                    other.gameObject.SetActive(false);
                    break;
                case "DMG2":
                    SEO.PHit(25);
                    other.gameObject.SetActive(false);
                    break;
                case "DMG3":
                    SEO.PHit(25);
                    other.gameObject.SetActive(false);
                    break;
                case "DMG4":
                    SEO.PHit(25);
                    other.gameObject.SetActive(false);
                    break;
                case "DMG5":
                    SEO.PHit(25);
                    other.gameObject.SetActive(false);
                    break;
                case "DMG2-1":
                    SEO.PHit(100);
                    break;
                case "DMG3-1":
                    SEO.PHit(100);
                    break;
                case "DMG4-1":
                    SEO.PHit(100);
                    break;
                case "DMG5-1":
                    SEO.PHit(100);
                    break;
                default:
                    break;
            }
        }
        

    }
}

