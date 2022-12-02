using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GunSystem : MonoBehaviour
{
    public int damageAmount = 20;
    public float range = 100f;
    public float fireRate = 15;


    public GameObject fpsCam;                   //The Point Of Shooting
    public ParticleSystem muzzleFlash;          //Particle Effect For Muzzle Flash
 

                          
    public Vector3 reloading;                   //New Position For Reload
    public float reloadTime = 3;                //Time It Takes To Reload
   
    public float amount;                        //Swaying Min Amount
    public float maxAmount;                     //Swaying Max Amount
                

           

    public TextMeshProUGUI ammoText;                 //Ammo Text

    private int currentAmmo;                    //The Current Ammo In Weapon
    public int magazineSize = 10;               //How Much Ammo Is In Each Mag
    public int ammoCache = 20;                  //How Much Ammo Is In Your Cache (Storage)
    private int maxAmmo;                        //Max Ammo Is Private MaxAmmo = Mag Size
    private int ammoNeeded;                     //Ammo Counter For How Much Is Needed, You Shoot 5 Bullets, You Need 5

    public bool semi;                           //Is the Weapon Semi
                          
   

    

   

    private bool isreloading;                   //Is The Weapon Reloading
    private bool canShoot;                      //Is The Weapon Able To Be Shot

    private float nextTimeToFire = 0f;          //How Much Time Must Pass Before Shooting/Meleeing Again



    //Start Function To Ensure Theres No Bugs:

    void Start()
    {
        currentAmmo = magazineSize;
        maxAmmo = magazineSize;

        isreloading = false;
        canShoot = true;

      

    }



    void Update()
    {

        //For Semi Auto Weapons:

        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire && semi && magazineSize > 0 && canShoot)
        {
           
            nextTimeToFire = Time.time + 1f / fireRate;
           
           
            Shoot();
        }

      


      

       

        //Checks For 0 Ammo:

       

       

        

        

        //Reloading:

        if (Input.GetKeyDown(KeyCode.R) && magazineSize == 0 && ammoCache > 0)
        {
            canShoot = false;
            ammoCache -= ammoNeeded;
            magazineSize += ammoNeeded;
            ammoNeeded -= ammoNeeded;
            isreloading = true;
            StartCoroutine(ReloadTimer());

        }

        //Stops Bugs With Pressing Reload More Than Once:

        else if (isreloading)
        {

            return;

        }

        //Doesnt Reload If Cache Is 0:

        if (Input.GetKeyDown(KeyCode.R) && ammoCache == 0)
        {

            return;

        }

        //Tells Our Text Object What To Say:


        ammoText.GetComponent<TextMeshProUGUI>().text = magazineSize + " / " + ammoCache;


       
       
    }


    //If Our Weapon Is A Gun:

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) 
        {
            Debug.Log(hit.transform.name);

            magazineSize--;
            ammoNeeded++;

            muzzleFlash.Play();
           

           

            


            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damageAmount);
            }
            return;





        }
    }


   


    


   

  

    //Our Reload Timer:

    IEnumerator ReloadTimer()
    {
       
        transform.localEulerAngles += reloading;
        yield return new WaitForSeconds(reloadTime);
        isreloading = false;
        canShoot = true;
       
    }
}
