﻿using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Online_Store.Classes
{
    public class Config
    {
        private string ConnectionString = @"Data Source=(local);Initial Catalog=OnlineStore;Integrated Security=True";
        private SqlConnection _connection;
        private static Config _instance;
        
        private Config()
        {
            _connection = new SqlConnection(ConnectionString);
            try
            {
                _connection.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Connection failed, Please try again later.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static Config Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Config();
                return _instance;
            }
        }
        public SqlConnection Connection
        {
            get
            {
                return _connection;
            }
        }

    }
}
