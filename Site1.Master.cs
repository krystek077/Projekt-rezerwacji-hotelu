using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace test3
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        // String połączenia z bazą danych
        private readonly string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        // Metoda wywoływana przy ładowaniu strony
        protected void Page_Load(object sender, EventArgs e)
        {
            UpdateLinkVisibility();
        }

        // Aktualizacja widoczności linków na podstawie stanu sesji
        private void UpdateLinkVisibility()
        {
            bool isLoggedIn = Session["role"] != null && Session["role"].Equals("user");

            LinkButton1.Visible = !isLoggedIn; // Zarejestruj
            LinkButton2.Visible = !isLoggedIn; // Zaloguj się

            LinkButton4.Visible = isLoggedIn; // Zarezerwuj
            LinkButton3.Visible = isLoggedIn; // Wyloguj
        }

        // Przekierowanie do strony rejestracji
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Rejestracja.aspx");
        }

        // Przekierowanie do strony logowania
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("ZalogujSie.aspx");
        }

        // Przekierowanie do strony rezerwacji noclegu
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("ZarezerwujNocleg.aspx");
        }

        // Obsługa wylogowania użytkownika
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            LogoutUser();
            Response.Redirect("StronaGłówna.aspx");
        }

        // Logika wylogowania użytkownika
        private void LogoutUser()
        {
            string login = Session["login"]?.ToString() ?? string.Empty;

            if (!string.IsNullOrEmpty(login))
            {
                UpdateUserStatusInDb(login, "niezalogowany");
            }

            ClearSession();
        }

        // Aktualizacja statusu użytkownika w bazie danych
        private void UpdateUserStatusInDb(string login, string status)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                    SqlCommand cmdUpdateStatus = new SqlCommand("UPDATE Konto SET Status = @Status WHERE Login = @Login", con);
                    cmdUpdateStatus.Parameters.AddWithValue("@Status", status);
                    cmdUpdateStatus.Parameters.AddWithValue("@Login", login);
                    cmdUpdateStatus.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Logika obsługi wyjątków
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        // Czyszczenie danych sesji
        private void ClearSession()
        {
            Session["ImieNazwisko"] = "";
            Session["Login"] = "";
            Session["role"] = "";
        }
    }
}
