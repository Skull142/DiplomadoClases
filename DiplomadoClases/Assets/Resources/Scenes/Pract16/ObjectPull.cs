using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public struct PrefabPool
{
	public GameObject prefab;
	public int amountInBuffer;
}
//
public class ObjectPull : MonoBehaviour 
{
	public static ObjectPull objectPull;
	public PrefabPool[] prefabs;
	public List<GameObject>[] generalPool;
	private GameObject containerObject;

	void Awake()
	{
		objectPull = this;
		this.containerObject = new GameObject ("ObjectPool");
		this.generalPool = new List<GameObject>[this.prefabs.Length];
		int index = 0;
		foreach(PrefabPool oPrefab in this.prefabs)
		{
			this.generalPool[index] = new List<GameObject>();
			for(int i = 0 ; i < oPrefab.amountInBuffer ; i++ )
			{
				GameObject temp = Instantiate(oPrefab.prefab) as GameObject;
				temp.name = oPrefab.prefab.name;
				this.PoolGameObject ( temp );
			}
			index++;
		}
	}

	public void PoolGameObject( GameObject go )
	{
		for(int i = 0 ; i < this.prefabs.Length ; i++ )
		{
			if(go.name == prefabs[i].prefab.name )
			{
				go.SetActive ( false );
				go.transform.SetParent (this.containerObject.transform);
				go.transform.position = this.containerObject.transform.position;
				this.generalPool[i].Add(go);
			}
		}
	}

	public GameObject GetgameObjectOfType(string objectType, bool onlyPooled)
	{
		Profiler.BeginSample ("-------BEGIN GET OBJECT");
		for(int i = 0 ; i < this.prefabs.Length ; i++ )
		{
			GameObject prefab = this.prefabs[i].prefab;
			if( prefab.name == objectType)
			{
				if (this.generalPool [i].Count > 0) {
					GameObject pooledObj = this.generalPool [i] [0];
					pooledObj.transform.parent = null;
					this.generalPool [i].RemoveAt (0);
					pooledObj.SetActive (true);
					return pooledObj;
				} 
				else if(!onlyPooled) 
				{
					return Instantiate (this.prefabs[i].prefab) as GameObject;
				}
				break;
			}
		}
		Profiler.EndSample ();
		return null;
	}
}
