using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Data;
using Mono.Data.Sqlite;
/**
 * Menu principal con sus respectivas funcionalidades con los diferentes botones
 * @author Ismael Paloma Narváez
 */
public class MainMenu : MonoBehaviour
{
    public string startScene;
    
    //empezamos de cero por lo que llamamos a las funciones de restablecimiento de valores de la base de datos
    public void StartGame()
    {
        ResetDoble();
        ResetMago();
        ResetSamu();
        SceneManager.LoadScene(startScene);
    }
    //continuamos la partida
    public void ContinueGame()
    {
        
        SceneManager.LoadScene(startScene);
    }
    //salimos del juego
    public void QuitGame()
    {
        Application.Quit();
    }
    //reseteamos en base de datos la aparición del mago
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
    //reseteamos en base de datos la aparición del samurai
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
    //reseteamos en base de datos la adquisición del doble salto
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
