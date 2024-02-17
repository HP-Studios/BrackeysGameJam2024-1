using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GunShoot : MonoBehaviour
{
    [SerializeField] Enemy enemyScript;

    //Gun stats
    public int damage;
    public float timeBetweenShooting, spread, range, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;
    int bulletsLeft, bulletsShot;

    //bools 
    bool shooting, readyToShoot, reloading;

    [SerializeField] float bulletSpeed = 10f;
    [SerializeField] float shellSpeed = 1f;

    //Reference
    [SerializeField] Transform attackPoint;


    [SerializeField] GameObject shellPrefab, bulletPrefab;
    [SerializeField] TextMeshProUGUI text;

    [SerializeField] GameObject player;

    private void Awake()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }
    private void Update()
    {
        MyInput();

        text.SetText(bulletsLeft + " / " + magazineSize);
    }
    private void MyInput()
    {
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);


        //Shoot
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = bulletsPerTap;
            Shoot();
        }
    }

    // Reference to the bullet prefab
    private void Shoot()
    {
        readyToShoot = false;

        //Spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //Calculate Direction with Spread
        Vector3 directionSpread = player.transform.forward + new Vector3(x, y, 0);
        Vector3 direction = player.transform.forward;

        // Instantiate bullet
        GameObject bullet = Instantiate(bulletPrefab, attackPoint.position, Quaternion.identity);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

        // Apply force to the bullet
        if (bulletRb != null)
        {
            bulletRb.AddForce(direction.normalized * bulletSpeed, ForceMode.Impulse);
        }

        // Instantiate shell
        GameObject shell = Instantiate(shellPrefab, attackPoint.position, Quaternion.identity);
        Rigidbody shellRb = shell.GetComponent<Rigidbody>();

        // Apply force to the shell
        if (shellRb != null)
        {
            Vector3 shellDirection = transform.right; // Change this to control the direction of the shell
            shellRb.AddForce(directionSpread * shellSpeed, ForceMode.Impulse);
        }

        bulletsLeft--;
        bulletsShot--;

        Invoke("ResetShot", timeBetweenShooting);

        if (bulletsShot > 0 && bulletsLeft > 0)
            Invoke("Shoot", timeBetweenShots);
    }

    private void ResetShot()
    {
        readyToShoot = true;
    }
}
