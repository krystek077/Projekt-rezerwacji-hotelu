using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace test3
{
    public partial class Rejestracja : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Button1_Click(object sender, EventArgs e)
        {
            lblWynik.Visible = true;

            try
            {
                string ImieNazwisko = FullName.Text;
                DateTime Data = Convert.ToDateTime(DataUrodzenia.Text);
                int telefon = Convert.ToInt32(Telefon.Text);
                string email = Email.Text;
                string wojewodztwo = Województwo.Text;
                string miasto = Miasto.Text;
                string kodpocztowy = KodPocztowy.Text;
                string adres = Adres.Text;
                string login = Login.Text;
                string haslo = Hasło.Text;
                string haslo2 = Hasło2.Text;

                //Sprawdzenie poprawności formatu email
                if (!IsValidEmail(email))
                {
                    lblWynik.Text = "Niepoprawny format adresu e-mail.";
                    return;
                }
                //Sprawdzenie czy login został już użyty
                if (IsLoginExists(login))
                {
                    lblWynik.Text = "Poniższy Login został już użyty.";
                    return;
                }
                //Sprawdzenie czy hasło spełnia warunki
                if (!IsValidPassword(haslo))
                {
                    lblWynik.Text = "Hasło musi mieć co najmniej 12 znaków, zawierać duże i małe litery oraz znak specjalny.";
                    return;
                }
                //Sprawdzenie czy hasło zostało już użyte
                if (IsPasswordExists(haslo))
                {
                    lblWynik.Text = "Poniższe hasło zostało już użyte.";
                    return;
                }

                // Sprawdzenie czy oba hasła są ważne
                if (haslo != haslo2)
                {
                    lblWynik.Text = "Podane hasła muszą być identyczne.";
                    return;
                }
                

                if (!IsLoginExists(login) && !IsPasswordExists(haslo) && IsValidPassword(haslo) && haslo == haslo2)
                {
                    DodajDoBazy(ImieNazwisko, Data, telefon, email, wojewodztwo, miasto, kodpocztowy, adres, login, haslo);

                }
                


            }
            catch (Exception ex)
            {
                lblWynik.Text = "Wystąpił błąd: " + ex.Message;
            }
        }
        private bool IsValidPassword(string haslo)
        {
            //logika walidacji hasła
            if (haslo.Length < 12)
                return false;

            bool hasUpperChar = Regex.IsMatch(haslo, @"[A-Z]+");
            bool hasLowerChar = Regex.IsMatch(haslo, @"[a-z]+");
            bool hasSpecialChar = Regex.IsMatch(haslo, @"[\W]+");

            return hasUpperChar && hasLowerChar && hasSpecialChar;
        }

        private bool IsValidEmail(string email)
        {
            // Prosta walidacja formatu e-mail
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
       
        private bool IsLoginExists(string login)
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM Konto WHERE Login = @Login", con);
                cmd.Parameters.AddWithValue("@Login", login);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }
        private bool IsPasswordExists(string haslo)
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM Konto WHERE BINARY_CHECKSUM(Haslo) = BINARY_CHECKSUM(@Haslo)", con);
                cmd.Parameters.AddWithValue("@Haslo", haslo);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        //dodawanie użytkownika do bazy
        private void DodajDoBazy(string imieNazwisko, DateTime data, int telefon, string email,
                         string wojewodztwo, string miasto, string kodpocztowy, string adres,
                         string login, string haslo)
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                try
                {
                    con.Open();
                    string sql = "INSERT INTO Konto (ImieNazwisko, DataUrodzenia, Telefon, Email, Wojewodztwo, Miasto, KodPocztowy, Adres, Login, Haslo) VALUES (@ImieNazwisko, @Data, @Telefon, @Email, @Wojewodztwo, @Miasto, @KodPocztowy, @Adres, @Login, @Haslo)";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@ImieNazwisko", imieNazwisko);
                        cmd.Parameters.AddWithValue("@Data", data);
                        cmd.Parameters.AddWithValue("@Telefon", telefon);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Wojewodztwo", wojewodztwo);
                        cmd.Parameters.AddWithValue("@Miasto", miasto);
                        cmd.Parameters.AddWithValue("@KodPocztowy", kodpocztowy);
                        cmd.Parameters.AddWithValue("@Adres", adres);
                        cmd.Parameters.AddWithValue("@Login", login);
                        cmd.Parameters.AddWithValue("@Haslo", haslo); 

                        int wynik = cmd.ExecuteNonQuery();
                        if (wynik > 0)
                        {

                            lblWynik.Text = "Rejestracja przebiegła pomyślnie";
                            
                        }
                        else
                        {
                            lblWynik.Text = "Błąd podczas rejestracji.";
                        
                        }
                    }
                }
                catch (SqlException ex)
                {
                    lblWynik.Text = "Błąd bazy danych: " + ex.Message;
                }
            }
        }
    }
}