using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace test3
{
    public partial class WebForm1 : Page
    {
        // Metoda wywoływana przy ładowaniu strony
        protected void Page_Load(object sender, EventArgs e)
        {
            // Kod ładowania strony, jeśli jest potrzebny
        }

        // Obsługa kliknięcia przycisku 'Oblicz'
        protected void btnOblicz_Click(object sender, EventArgs e)
        {
            lblWynik.Visible = true;

            try
            {
                ValidujDaneWejsciowe();
                ObliczISetCena();
            }
            catch (FormatException)
            {
                lblWynik.Text = "Błąd: Niepoprawny format danych.";
            }
            catch (ArgumentException ex)
            {
                lblWynik.Text = "Błąd: " + ex.Message;
            }
            catch (Exception ex)
            {
                lblWynik.Text = "Błąd: Wystąpił nieoczekiwany błąd. " + ex.Message;
            }
        }

        // Walidacja danych wejściowych
        private void ValidujDaneWejsciowe()
        {
            if (string.IsNullOrWhiteSpace(txtDataRozpoczecia.Text) ||
                string.IsNullOrWhiteSpace(txtDataZakonczenia.Text) ||
                string.IsNullOrWhiteSpace(txtIloscPokoi.Text))
            {
                throw new ArgumentException("Wszystkie pola muszą być wypełnione.");
            }
        }

        // Obliczanie ceny i wyświetlanie wyniku
        private void ObliczISetCena()
        {
            DateTime dataRozpoczecia = Convert.ToDateTime(txtDataRozpoczecia.Text);
            DateTime dataZakonczenia = Convert.ToDateTime(txtDataZakonczenia.Text);
            int iloscPokoi = Convert.ToInt32(txtIloscPokoi.Text);
            string rodzajPokoju = ddlRodzajPokoju.SelectedValue;

            double cena = ObliczCenePobytu(dataRozpoczecia, dataZakonczenia, rodzajPokoju, iloscPokoi);
            lblWynik.Text = "Szacowany koszt pobytu wynosi: " + cena.ToString("C2");
        }

        // Obliczanie ceny pobytu na podstawie podanych danych
        private double ObliczCenePobytu(DateTime start, DateTime end, string roomType, int rooms)
        {
            SprawdzPoprawnoscDat(start, end);
            SprawdzPoprawnoscIlosciPokoi(rooms);

            double pricePerNight = PobierzCeneZaNoc(roomType);

            int totalNights = (end - start).Days;
            return pricePerNight * totalNights * rooms;
        }

        // Sprawdzenie poprawności zakresu dat
        private void SprawdzPoprawnoscDat(DateTime start, DateTime end)
        {
            if (end <= start)
            {
                throw new ArgumentException("Data zakończenia musi być późniejsza niż data rozpoczęcia.");
            }
        }

        // Sprawdzenie poprawności ilości pokoi
        private void SprawdzPoprawnoscIlosciPokoi(int rooms)
        {
            if (rooms <= 0)
            {
                throw new ArgumentException("Ilość pokoi musi być większa od zera.");
            }
        }

        // Pobieranie ceny za noc w zależności od rodzaju pokoju
        
        private double PobierzCeneZaNoc(string roomType)
        {
            var cenyPokoi = new Dictionary<string, double>
            {
            {"Jednoosobowy", 300},
            {"Dwuosobowy", 500},
            {"Rodzinny", 700},
            {"Dwupietrowy", 2000},
            {"VIP", 3500}
            };

            if (cenyPokoi.TryGetValue(roomType, out double cena))
            {
                return cena;
            }
            else
            {
                throw new ArgumentException("Nieznany rodzaj pokoju.");
            }
        }
    }
}


