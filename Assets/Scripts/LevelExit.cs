using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using Mono.Data.Sqlite;

public class LevelExit : MonoBehaviour
{
    public static LevelExit instance;
    public int muerteMago = 0;//bbdd
    public int muerteSamu = 0;//bbdd
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        string url1 = "URI=file:" + Application.dataPath + "/database/2d.db";
        IDbConnection dbConn1 = new SqliteConnection(url1);
        dbConn1.Open();
        IDbCommand comando1 = dbConn1.CreateCommand();

        comando1.CommandText = "select * from mago";
        IDataReader reader1= comando1.ExecuteReader();
        

        while (reader1.Read()) 
        {
            muerteMago=(byte) reader1.GetInt32(reader1.GetOrdinal("muerteMago"));
        }





        if (muerteMago == 1) 
        {
            EnemyMago.instance.noAparezco();

        }

        


        reader1.Dispose();
        reader1 = null;
        comando1.Dispose();
        comando1 = null;

        dbConn1.Dispose();
        dbConn1 = null;




        string url = "URI=file:" + Application.dataPath + "/database/2d.db";
        IDbConnection dbConn = new SqliteConnection(url);
        dbConn.Open();
        IDbCommand comando = dbConn.CreateCommand();

        comando.CommandText = "select * from samu";
        IDataReader reader = comando.ExecuteReader();


        while (reader.Read())
        {
            muerteSamu = (byte)reader.GetInt32(reader.GetOrdinal("muerteSamu"));
        }





        if (muerteSamu == 1)
        {
            EnemigoStrong.instance.noAparezco();

        }




        reader.Dispose();
        reader = null;
        comando.Dispose();
        comando = null;

        dbConn.Dispose();
        dbConn = null;



    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") 
        {
            if (muerteMago == 1 && muerteSamu==1) 
            {
                LevelManager.instance.EndLevel();
            }
            
        }
    }

    public void MagoDerrotado()
    {
        muerteMago = 1;
        
        string url = "URI=file:" + Application.dataPath + "/database/2d.db";
        IDbConnection dbConn = new SqliteConnection(url);
        dbConn.Open();
        IDbCommand comando = dbConn.CreateCommand();

        comando.CommandText = "delete from mago";
        comando.ExecuteNonQuery();

        comando.CommandText = "insert into mago values(" + muerteMago + ")";
        comando.ExecuteNonQuery();

        comando.Dispose();
        comando = null;

        dbConn.Dispose();
        dbConn = null;

       
    }
    public void SamuDerrotado()
    {
        muerteSamu = 1;

        string url = "URI=file:" + Application.dataPath + "/database/2d.db";
        IDbConnection dbConn = new SqliteConnection(url);
        dbConn.Open();
        IDbCommand comando = dbConn.CreateCommand();

        comando.CommandText = "delete from samu";
        comando.ExecuteNonQuery();

        comando.CommandText = "insert into samu values(" + muerteSamu + ")";
        comando.ExecuteNonQuery();

        comando.Dispose();
        comando = null;

        dbConn.Dispose();
        dbConn = null;

    }

    
}
