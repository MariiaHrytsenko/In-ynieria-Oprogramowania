using System;
using System.Data.SqlClient;

public class UserDAO
{
    private string _connectionString;

    public UserDAO(string connectionString)
    {
        _connectionString = connectionString;
    }

    public bool loginUser(string email, string name, string surname, string password, string telnum)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string checkQuery = "SELECT COUNT(1) FROM userData WHERE emailUser = @Email OR telnumUser = @Telnum";
                using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@Email", emailUser);
                    checkCommand.Parameters.AddWithValue("@Telnum", telnumUser);

                    int existingUser = (int)checkCommand.ExecuteScalar();
                    if (existingUser > 0)
                    {
                        throw new Exception("Email or phone number already exists");
                    }
                }

                string insertQuery = "INSERT INTO userData (emailUser, nameUser, surnameUser, passwordUser, telnumUser) " +
                                     "VALUES (@Email, @Name, @Surname, @Password, @Telnum)";
                using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                {
                    insertCommand.Parameters.AddWithValue("@Email", emailUser);
                    insertCommand.Parameters.AddWithValue("@Name", nameUser);
                    insertCommand.Parameters.AddWithValue("@Surname", surnameUser);
                    insertCommand.Parameters.AddWithValue("@Password", passwordUser);
                    insertCommand.Parameters.AddWithValue("@Telnum", telnumUser);

                    insertCommand.ExecuteNonQuery();
                }
            }
            return true; 
        }

        catch (Exception)
        {
            return false;
        }
    }
}
