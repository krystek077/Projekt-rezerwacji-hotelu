using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace test3
{
    public partial class ZarezerwujNocleg : Page
    {
        
        // String do połączenia z bazą danych
        private readonly string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Kod potrzebny podczas ładowania strony
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            lblWynik.Visible = true;
            // Sprawdza, czy sesja użytkownika jest aktywna
            if (Session["Login"] == null || string.IsNullOrEmpty(Session["Login"].ToString()))
            {
                Response.Write("<script>alert('Session Expired. Login Again.');</script>");
                Response.Redirect("ZalogujSie.aspx");
                return;
            }

            // Wywołuje funkcję rezerwacji noclegu
            zarezerwujnocleg();
        }

        private void zarezerwujnocleg()
        {
            try
            {
                // Sprawdza, czy wszystkie wymagane pola zostały wypełnione
                if (string.IsNullOrWhiteSpace(datarozpoczecia.Text) ||
                    string.IsNullOrWhiteSpace(txtDataZakonczenia.Text) ||
                    string.IsNullOrWhiteSpace(txtIloscPokoi.Text))
                {
                    throw new ArgumentException("Wszystkie pola muszą być wypełnione.");
                }

                // Przetwarza dane z formularza
                DateTime dataRozpoczecia = Convert.ToDateTime(datarozpoczecia.Text);
                DateTime dataZakonczenia = Convert.ToDateTime(txtDataZakonczenia.Text);
                int iloscPokoi = Convert.ToInt32(txtIloscPokoi.Text);
                string rodzajPokoju = ddlRodzajPokoju.SelectedValue;
                string login = Session["Login"].ToString();

                // Łączy się z bazą danych i wykonuje operacje
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();

                    // Pobiera ID klienta na podstawie loginu
                    SqlCommand cmdGetId = new SqlCommand("SELECT KlientID FROM Konto WHERE Login = @Login", con);
                    cmdGetId.Parameters.AddWithValue("@Login", login);
                    object result = cmdGetId.ExecuteScalar();

                    if (result == null)
                    {
                        lblWynik.Text = "Błąd: Nie znaleziono klienta.";
                        return;
                    }

                    int klientId = (int)result;

                    // Wstawia dane rezerwacji do tabeli
                    string insertQuery = "INSERT INTO Rezerwacje (DataRozpoczecia, DataZakonczenia, RodzajPokoju, IloscPokoi, StanRezerwacji, KlientId) VALUES (@DataRozpoczecia, @DataZakonczenia, @RodzajPokoju, @IloscPokoi, 'nieopłacone', @KlientId)";
                    SqlCommand cmdInsert = new SqlCommand(insertQuery, con);
                    cmdInsert.Parameters.AddWithValue("@DataRozpoczecia", dataRozpoczecia);
                    cmdInsert.Parameters.AddWithValue("@DataZakonczenia", dataZakonczenia);
                    cmdInsert.Parameters.AddWithValue("@RodzajPokoju", rodzajPokoju);
                    cmdInsert.Parameters.AddWithValue("@IloscPokoi", iloscPokoi);
                    cmdInsert.Parameters.AddWithValue("@KlientId", klientId);

                    cmdInsert.ExecuteNonQuery();
                    lblWynik.Text = "Rezerwacja została dokonana pomyślnie.";
                }
            }
            catch (FormatException)
            {
                lblWynik.Text = "Błąd: Niepoprawny format danych.";
            }
            catch (SqlException ex)
            {
                lblWynik.Text = "Błąd SQL: " + ex.Message;
            }
            catch (Exception ex)
            {
                lblWynik.Text = "Błąd: " + ex.Message;
            }
        }
    }
}
