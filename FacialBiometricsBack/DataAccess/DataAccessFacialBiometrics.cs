using FacialBiometrics.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace FacialBiometricsBack.DataAccessFacialBiometrics
{
    public class DataAccessFacialBiometrics : IDataAccessFacialBiometrics
    {
        private string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=RuralPropertiesInformations;Integrated Security=SSPI";

        public int CreateUser(UserInfo userInfo)
        {
            string query = "insert into UserInfo values (@P0, @P1, @P2, @P3, @P4); SELECT SCOPE_IDENTITY();";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("P0", userInfo.NameUser));
                    cmd.Parameters.Add(new SqlParameter("P1", userInfo.Username));
                    cmd.Parameters.Add(new SqlParameter("P2", userInfo.Password));
                    cmd.Parameters.Add(new SqlParameter("P3", userInfo.SaltPassword));
                    cmd.Parameters.Add(new SqlParameter("P4", userInfo.UserPositionInfo.IdUserPosition));

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public void CreateFacialBiometrics(UsersFacialBiometrics userImages)
        {
            string query = "insert into UsersFacialBiometrics values (@P0, @P1, @P2)";

            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("P0", userImages.ImageName));
                    cmd.Parameters.Add(new SqlParameter("P1", userImages.ImageBytes));
                    cmd.Parameters.Add(new SqlParameter("P2", userImages.User.IdUser));
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public RuralPropertiesInfo GetRuralInfo(UserInfo userInfo)
        {
            string query = "select (property_text_info, property_img_info) from RuralPropertiesInfo where id_user_position <= @P0";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("P0", userInfo.IdUser));

                    SqlDataReader reader = cmd.ExecuteReader();

                    RuralPropertiesInfo rural = new RuralPropertiesInfo();

                    if (reader.Read())
                    {
                        rural.TextInformation = Convert.ToString(reader["property_text_info"]);
                        rural.ImageInformation = Encoding.ASCII.GetString((byte[])reader["property_img_info"]);
                    }

                    return rural;
                }
            }
        }

        public int GetUserPosition(UserInfo userInfo)
        {
            string query = "select id_user_position from UserInfo where id_user = @P0";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("P0", userInfo.IdUser));

                    SqlDataReader reader = cmd.ExecuteReader();

                    var idUser = 0;

                    if (reader.Read())
                    {
                        idUser = Convert.ToInt32(reader["id_user"]);
                    }

                    return idUser;
                }
            }
        }

        public bool Login(string userName, string password)
        {
            throw new NotImplementedException();
        }
    }
}