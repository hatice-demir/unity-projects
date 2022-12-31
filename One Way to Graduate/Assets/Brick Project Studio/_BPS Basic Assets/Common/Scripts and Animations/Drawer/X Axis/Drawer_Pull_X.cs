using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles

{

	public class Drawer_Pull_X : MonoBehaviour
	{

		public Animator pull_01;
		public bool open;
		public Transform Player;
		public GameObject openText;
		public bool inReach;
		public GameObject drawerOB;
		public GameObject insideObject;

		void Start()
		{
			pull_01.SetBool("open", false);
			open = false;
		}

		void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.tag == "Reach")
			{
				inReach = true;
				if(open == false)
                {
					openText.SetActive(true);
				}
				

				

			}
		}

		void OnTriggerExit(Collider other)
		{
			if (other.gameObject.tag == "Reach")
			{
				inReach = false;
				openText.SetActive(false);
			}
		}


		void Update()
		{
			if (inReach && Input.GetButtonDown("Interact"))
			{
				pull_01.SetBool("open", true);
				openText.SetActive(false);
				open = true;
				
				//StartCoroutine(opening());
				
				//else
    //            {
				//	StartCoroutine(closing());
				//}

				
			}

			if (open)
			{
				drawerOB.GetComponent<BoxCollider>().enabled = false;
				drawerOB.GetComponent<Drawer_Pull_X>().enabled = false;
				insideObject.GetComponent<BoxCollider>().enabled = true;
			}


		}

		//void OnMouseOver()
		//{
		//	{
		//		if (Player)
		//		{
		//			float dist = Vector3.Distance(Player.position, transform.position);
		//			if (dist < 10)
		//			{
		//				print("object name");
		//				if (open == false)
		//				{
		//					if (Input.GetMouseButtonDown(0))
		//					{
		//						StartCoroutine(opening());
		//					}
		//				}
		//				else
		//				{
		//					if (open == true)
		//					{
		//						if (Input.GetMouseButtonDown(0))
		//						{
		//							StartCoroutine(closing());
		//						}
		//					}

		//				}

		//			}
		//		}

		//	}

		//}

		IEnumerator opening()
		{
			print("you are opening the door");
			pull_01.Play("openpull_01");
			open = true;
			yield return new WaitForSeconds(.5f);
		}

		IEnumerator closing()
		{
			print("you are closing the door");
			pull_01.Play("closepush_01");
			open = false;
			yield return new WaitForSeconds(.5f);
		}


	}
}