using MySql.Data.MySqlClient;
using System;

namespace TitoRestobar.ConectionDB
{
    public interface IConexionDB
    {
        MySqlConnection Conectar();
    }
}
