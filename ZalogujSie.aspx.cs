using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace test3
{
    public partial class ZalogujSie : Page
    {
        // String do połączenia z bazą danych
        private readonly string _strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(_strcon))
            {
                try
                {
                    con.Open();

                    // Zapytanie do bazy danych sprawdzające poprawność loginu i hasła
                    string query = "SELECT * FROM Konto WHERE Login = @Login AND Haslo = @Haslo";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Login", login.Text.Trim());
                    cmd.Parameters.AddWithValue("@Haslo", haslo.Text.Trim());

                    // Wykonanie zapytania i sprawdzenie wyników
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                // Ustawianie sesji po poprawnym zalogowaniu
                                Session["Login"] = dr["Login"].ToString();
                                Session["ImieNazwisko"] = dr["ImieNazwisko"].ToString();
                                Session["role"] = "user";
                            }
                        }
                        else
                        {
                            // Informacja o niepoprawnych danych logowania
                            Response.Write("<script>alert('Invalid credentials');</script>");
                            return;
                        }
                    }

                    // Aktualizacja statusu użytkownika na 'zalogowany'
                    string updateStatusQuery = "UPDATE Konto SET Status = 'zalogowany' WHERE Login = @Login";
                    SqlCommand updateStatusCmd = new SqlCommand(updateStatusQuery, con);
                    updateStatusCmd.Parameters.AddWithValue("@Login", login.Text.Trim());
                    updateStatusCmd.ExecuteNonQuery();

                    // Przekierowanie do strony głównej po poprawnym zalogowaniu
                    Response.Write("<script>alert('Successful login');</script>");
                    Response.Redirect("StronaGłówna.aspx");
                }
                catch (Exception ex)
                {
                    // Obsługa wyjątków
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
        }
    }
}
