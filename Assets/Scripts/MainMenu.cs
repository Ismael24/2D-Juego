using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Data;
using Mono.Data.Sqlite;

public class MainMenu : MonoBehaviour
{
    public string startScene;
    // Start is called before the first frame update
    public void StartGame()
    {
        ResetDoble();
        ResetMago();
        ResetSamu();
        SceneManager.LoadScene(startScene);
    }
    public void ContinueGame()
    {
        
        SceneManager.LoadScene(startScene);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    private void ResetMago() 
    {
        int muerteMago = 0;

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
    private void ResetSamu()
    {
        int muerteSamu = 0;

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
    private void ResetDoble()
    {
        int posDoble = 0;

        string url = "URI=file:" + Application.dataPath + "/database/2d.db";
        IDbConnection dbConn = new SqliteConnection(url);
        dbConn.Open();
        IDbCommand comando = dbConn.CreateCommand();

        comando.CommandText = "delete from saltoDoble";
        comando.ExecuteNonQuery();

        comando.CommandText = "insert into saltoDoble values(" + posDoble + ")";
        comando.ExecuteNonQuery();

        comando.Dispose();
        comando = null;

        dbConn.Dispose();
        dbConn = null;
    }


}
