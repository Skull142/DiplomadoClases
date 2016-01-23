using UnityEngine;
using System;
using System.Collections;
using System.IO;

[Serializable]
public struct PlayerData
{
	public int item;
	public string name;
	public DateTime lastPlayDate;
}

public class DataManager : MonoBehaviour 
{
	public PlayerData playerData;
	public bool dbFile = true;
	private string[] tmpData;

	void Start()
	{
		if (!this.dbFile) 
		{
			if (!PlayerPrefs.HasKey ("NAME")) 
			{
				this.playerData = new PlayerData ();
				this.playerData.name = "XYZ";
				this.playerData.item = 0;
				this.playerData.lastPlayDate = DateTime.Now;
				this.Save ();
			} else
				this.Load();
		} else
			this.Load ();
	}


	public void SavePlayerData(PlayerData data )
	{
		PlayerPrefs.SetInt ( "ITEM", data.item );
		PlayerPrefs.SetString ( "NAME", data.name );
		PlayerPrefs.SetString ( "LASTPLAYDATE", data.lastPlayDate.ToString() );
		PlayerPrefs.Save ();
	}
	//
	public void Save()
	{
		if (this.dbFile)
			this.Save2File ();
		else 
		{
			this.playerData.name = "JOAQUIN";
			this.playerData.item++;
			this.playerData.lastPlayDate = DateTime.Now;
			this.SavePlayerData (this.playerData);
		}
		Debug.Log ("SAVED: " + this.playerData.name + "; " + this.playerData.item + "; " + this.playerData.lastPlayDate);
	}
	//
	public void Save2File()
	{
		this.playerData.name = "JOAQUIN";
		this.playerData.item++;
		this.playerData.lastPlayDate = DateTime.Now;
		this.SavePlayerData ( this.playerData );
		Debug.Log ( "SAVED: "+this.playerData.name+"; "+this.playerData.item+"; "+this.playerData.lastPlayDate );

		try
		{
			using(StreamWriter sw = new StreamWriter(Application.persistentDataPath+"/playerData.data"))
			{
				string line = this.playerData.name+"|"+this.playerData.item.ToString()+"|"+this.playerData.lastPlayDate.ToString();
				sw.WriteLine(line);
				sw.Close();
			}
		}
		catch(Exception e)
		{
			Debug.Log ("¡NO se puede guardar el archivo! :"+e.Message);
		}
	}
	//
	public void Load()
	{
		if (this.dbFile)
			this.ReadDBFile ();
		else 
		{
			this.playerData = new PlayerData ();
			this.playerData.name = PlayerPrefs.GetString ("NAME");
			this.playerData.item = PlayerPrefs.GetInt ("ITEM");
			this.playerData.lastPlayDate = DateTime.Parse (PlayerPrefs.GetString ("LASTPLAYDATE"));
		}
		Debug.Log ("LOADED: " + this.playerData.name + "; " + this.playerData.item + "; " + this.playerData.lastPlayDate);
	}

	public void ReadDBFile()
	{
		PlayerData data = new PlayerData ();
		try
		{
			using( StreamReader sr = new StreamReader(Application.persistentDataPath+"/playerData.data") )
			{
				string line;
				while( (line = sr.ReadLine()) != null)
				{
					this.tmpData = line.Split('|');
					data.name = tmpData[0];
					data.item = int.Parse( tmpData[1] );
					data.lastPlayDate = DateTime.Parse( tmpData[2] );
				}
			}
			this.playerData = data;
		}
		catch(Exception e)
		{
			Debug.Log ("¡El archivo no puede ser leido!: "+e.Message);
			this.playerData.name = "XYZ";
			this.playerData.item = 0;
			this.playerData.lastPlayDate = DateTime.Now;
		}
	}
}
