using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC : MonoBehaviour
{
    public int Id { get; set; }
    public GameObject weaponContainer;
    public BaseWeapon currentWeapon;
    private readonly int maxHealth = 100;
    private int currentHealth;
    public int CurrentHealth { get { return currentHealth; } set { currentHealth = value; } }
    public bool IsAlive { get { return CurrentHealth > 0; } }
    public bool IsSelf { get { return currentWeapon != null && Id == currentWeapon.WielderId; } }
    public PlayerMovement GetDirection;
    public bool canAttack = false;
    public bool shootBullet = false;
    
    private void Start()
    {
        currentHealth = maxHealth;
        // Initialize with default weapon data - will be set properly when weapon is equipped
        currentWeapon = null;
    //    Debug.Log(currentWeapon.WeapName);
    }

    public void SetWeapon(BaseWeapon weap)
    {
        if (currentWeapon != null)
        {
            //empty slot
            currentWeapon = null;
        }
        currentWeapon = weap;
        if (currentWeapon != null)
        {
            currentWeapon.CoolDown = currentWeapon.MaxCoolDown;
            weap.SetWeaponlocation(weaponContainer);
            Debug.Log(currentWeapon.name + " " + transform.parent.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
         
       

      /*  if (GetDirection.isRotating)
        {
            if (canAttack)
            {
                shootBullet = true;
            }
            else shootBullet = false;

        }
        else shootBullet = false;
        WeaponCoolDown();
        */

    }
    private void FixedUpdate()
    {
      /*  if (shootBullet)
        {
            Attack();
        }
       */
    }

    private void WeaponCoolDown()
    {
        if (currentWeapon == null) return;
       
        if (currentWeapon.CoolDown < currentWeapon.MaxCoolDown)
        {
            currentWeapon.CoolDown += Time.deltaTime;
            
            return;
        }
          canAttack = true;
          

    }
  
    public void Attack()
    {
        if (currentWeapon == null) return;

        if (currentWeapon is Guns)
        {
            currentWeapon.UseWeapon(weaponContainer.transform);
            Guns gun;
            gun = (Guns)currentWeapon;
           // gun.ammo.SpawnStart = currentWeapon.transform.position;
           // float distance = Vector3.Distance(gun.ammo.SpawnStart, gun.ammo.transform.position);
           // Debug.Log(distance);
        }
        else
        {
            if (GetDirection != null)
            {
                currentWeapon.UseWeapon(GetDirection.lookAtDirection);
            }
            
        }
        Debug.Log("fired");
        currentWeapon.CoolDown = 0;
        canAttack = false;
        
      //  yield return new WaitForSeconds(currentWeapon.CoolDown);
    }
}
