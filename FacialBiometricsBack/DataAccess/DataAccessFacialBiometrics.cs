using FacialBiometrics.Models;
using FacialBiometricsBack.Models;
using System;
using System.Collections.Generic;
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
                    cmd.Parameters.Add(new SqlParameter("P2", userImages.IdUser));
                    cmd.ExecuteNonQuery();
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

        public List<ArticleModel> GetArticles(int idUser){
            string query = @"
                SELECT * FROM ArticleChemicalProduct A 
                    where A.id_user_position <= (select U.id_user_position FROM UserInfo U WHERE U.id_user= @P0)";

            using(SqlConnection conn = new SqlConnection(connectionString)){
                conn.Open();

                using(SqlCommand cmd = new SqlCommand(query,conn)){

                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("P0",idUser));

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<ArticleModel> listArticles = new List<ArticleModel>();

                    while(reader.Read()){
                        listArticles.Add(new ArticleModel{
                            idArticle = Convert.ToInt32(reader["id_article"]),
                            title = Convert.ToString(reader["article_title"]),
                            content = Convert.ToString(reader["article_content"])
                        });
                    }

                    return listArticles;  
                }
            }
        }

        public UserInfo GetUserByUsername(string userName)
        {
            string query = "select * from UserInfo where username_user = @P0";

            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("P0", userName));

                    SqlDataReader reader = cmd.ExecuteReader();

                    var user = new UserInfo();

                    user.UserPositionInfo = new UserPosition();

                    if (reader.Read())
                    {
                        user.IdUser = Convert.ToInt32(reader["id_user"]);
                        user.NameUser = Convert.ToString(reader["name_user"]);
                        user.Username = Convert.ToString(reader["username_user"]);
                        user.Password = Convert.ToString(reader["password_user"]);
                        user.SaltPassword = Convert.ToString(reader["salt_password_user"]);
                        user.UserPositionInfo.IdUserPosition = Convert.ToInt32(reader["id_user_position"]);
                    }

                    return user;
                }
            }
        }

        public List<string> GetUserByLevel(int idPosition)
        {
            string query = @"
                SELECT name_user FROM UserInfo where id_user_position = @P0";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {

                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new SqlParameter("P0", idPosition));

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<string> listUsers = new List<string>();

                    while (reader.Read())
                    {
                        listUsers.Add(Convert.ToString(reader["name_user"]));                        
                    }

                    return listUsers;
                }
            }
        }
    }
}