using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ControlPlayer : mCharacterController
{
    [SerializeField] private ScreenTouchController input;
    [SerializeField] private ShootControl sControl;

    private List<Transform> enemies = new List<Transform>();

    private int EnemyAmount;

    public GameObject winPanel;

    private void Start() {
        Time.timeScale=1;
        EnemyAmount = FindObjectsOfType<EnemyController>().Length;
        winPanel.SetActive(false);
    }
    private void FixedUpdate() {
        
        var directionP = new Vector3(input.direction.x,0,input.direction.y);
        Move(directionP);
    } 

    private void Update()
		{
			if (enemies.Count > 0)
				transform.LookAt(enemies[0]);
		}

    private void OnCollisionEnter(Collision other) {
        if(other.transform.CompareTag($"Enemy"))
        {
            Dead();   
        }
    }

    private void OnTriggerStay(Collider other) {
        if(other.transform.CompareTag($"Enemy"))
        {
            if(!enemies.Contains(other.transform)){
                enemies.Add(other.transform);
            }
            
            AutoShoot();

            /*var direction = other.transform.position - transform.position;
            direction.y = 0;
            direction = direction.normalized;
            
            sControl.Shoot(direction, transform.position);
            transform.LookAt(other.transform);
            */
        }

        
    }

    private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag($"Finish"))
			{
				OnReachSavePoint();
			}
		}

    private void OnTriggerExit(Collider other)
		{
			if (other.transform.CompareTag($"Enemy"))
			{
				enemies.Remove(other.transform);
			}
		}

    private bool isShooting;

    private void AutoShoot(){
        IEnumerator Do(){
            
            while(enemies.Count>0)
            {
                var enemy = enemies[0];
                var direction = enemy.transform.position - transform.position;
                direction.y = 0;
                direction = direction.normalized;
                sControl.Shoot(direction, transform.position);
                //transform.LookAt(enemy.transform);
                enemies.RemoveAt(0);
                yield return new WaitForSeconds(sControl.Delay);
            }

            isShooting= false;
        }

        if(!isShooting){
            isShooting=true;
            StartCoroutine(Do());
        }

       
    }

    private void OnReachSavePoint()
	{
		winPanel.SetActive(true);
        Time.timeScale=0;
        
        
	}

    public void Win()
	{
		Debug.Log("Win");
		Time.timeScale = 0;
        var current = FindObjectsOfType<EnemyController>().Length;
        var result = current / (float)EnemyAmount;
        var success = Mathf.Lerp(100,0, result);
    }

    private void Dead()
    {
        Time.timeScale=0;
    }
}



