<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="StronaGłówna.aspx.cs" Inherits="test3.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <section> 
        <img src="imgs/homepage.jpg" class="img-fluid"/>
    </section>
    <section>
      <div class="container">
         <div class="row">
            <div class="col-12">
               <center>
                  <h1>Nasza oferta</h1>
               </center>
            </div>
         </div>
         <div class="row">
            <div class="col-md-4">
               <center>
                  <img width="150" src="imgs/single-room.png"/>
                  <h4>Pokój jednoosobowy</h4>
                   <h5>Cena: 300 zł / Noc</h5>
                  <p class="text-justify">Pokój jednoosobowy w naszym hotelu oferuje komfortowe, pojedyncze łóżko, zapewniając idealne warunki do odpoczynku. Jest wyposażony w nowoczesne udogodnienia, takie jak bezpłatne Wi-Fi, telewizor z dostępem do kanałów satelitarnych oraz prywatną łazienkę z zestawem kosmetyków.</p>
               </center>
            </div>
            <div class="col-md-4">
               <center>
                  <img width="150" src="imgs/double-room.png"/>
                  <h4>Pokój dwuosobowy</h4>
                   <h5>Cena: 500 zł / Noc </h5>
                  <p class="text-justify">Pokój dwuosobowy w naszym hotelu zapewnia dwa przestronne i wygodne łóżka. Pokój jest wyposażony w szereg udogodnień, w tym klimatyzację, telewizor z płaskim ekranem, dostęp do szybkiego internetu oraz elegancką, prywatną łazienkę.</p>
               </center>
            </div>
            <div class="col-md-4">
               <center>
                  <img width="150" src="imgs/family-room.png"/>
                  <h4>Pokój dla rodziców z dziećmi</h4>
                   <h5>Cena: 700 zł / Noc</h5>
                  <p class="text-justify">Pokój rodzinny w naszym hotelu został zaprojektowany z myślą o komforcie rodziców podróżujących z dziećmi, oferując przestronne łóżko małżeńskie oraz dodatkowe łóżka lub sofy dla dzieci. Jest on wyposażony w udogodnienia przyjazne rodzinie, takie jak telewizor z kanałami dla dzieci, przestronna łazienka oraz opcje rozrywki dla najmłodszych, zapewniając przyjemny i bezpieczny pobyt dla całej rodziny.</p>
               </center>
            </div>
              <div class="col-md-4">
               <center>
                  <img width="150" src="imgs/apartment-room.png"/>
                  <h4>Apartament dwupiętrowy</h4>
                   <h5>Cena: 2000 zł / Noc</h5>
                  <p class="text-justify">Apartament dwupiętrowy w naszym hotelu oferuje luksusowe doświadczenie z przestronnym salonem na parterze i elegancką sypialnią na piętrze, zapewniając prywatność i komfort. Wyposażony w wysokiej klasy meble, dwie nowoczesne łazienki oraz ekskluzywne udogodnienia, takie jak jacuzzi, pełnowymiarowa kuchnia i panoramiczne widoki, ten apartament stanowi idealne połączenie luksusu i domowego ciepła.</p>
               </center>
            </div>
              <div class="col-md-4">
               <center>
                  <img width="150" src="imgs/vip-room.png"/>
                  <h4>Pokój VIP</h4>
                   <h5>Cena: 3500 zł / Noc</h5>
                  <p class="text-justify">Pokój VIP w naszym hotelu stanowi esencję luksusu i elegancji, oferując wyjątkowy komfort i wyszukaną dekorację. Jest wyposażony w ekskluzywne udogodnienia, takie jak king-size łóżko, prywatny taras z widokiem, zaawansowany system rozrywki i przestronną łazienkę z luksusowymi kosmetykami, gwarantując niezapomniane wrażenia z pobytu.</p>
               </center>
            </div>
              <div class="col-md-4">
               <center>
                  <img width="150" src="imgs/maried-room.png"/>
                  <h4>Pokój dla par</h4>
                   <h5>Cena: 500 zł / Noc</h5>
                  <p class="text-justify">Pokój dla par w naszym hotelu zapewnia romantyczną atmosferę i wyjątkowy komfort, idealny dla spędzenia wyjątkowych chwil we dwoje. Wyposażony w duże, wygodne łóżko małżeńskie, elegancką łazienkę oraz udogodnienia takie jak subtelne oświetlenie i mini-bar, stwarza idealne warunki do relaksu i intymności.</p>
               </center>
            </div>
         </div>
      </div>
   </section>
   <section>
      
    <div class="container mt-4">
        <div class="row justify-content-center">
            <div class="col-md-6">
                <div class="card">
                    <div class="card-body">
                        <h2 class="card-title text-center">Kalkulator kosztu pobytu</h2>
                        
                            <div class="form-group">
                                <label for="txtDataRozpoczecia">Data rozpoczęcia:</label>
                                <asp:TextBox ID="txtDataRozpoczecia" CssClass="form-control" runat="server" type="date"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="txtDataZakonczenia">Data zakończenia:</label>
                                <asp:TextBox ID="txtDataZakonczenia" CssClass="form-control" runat="server" type="date"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="ddlRodzajPokoju">Rodzaj pokoju</label>
                                <asp:DropDownList ID="ddlRodzajPokoju" runat="server">
                                     <asp:ListItem Text="Jednoosobowy" Value="Jednoosobowy"></asp:ListItem>
                                     <asp:ListItem Text="Dwuosobowy" Value="Dwuosobowy"></asp:ListItem>
                                     <asp:ListItem Text="Rodzinny" Value="Rodzinny"></asp:ListItem>
                                     <asp:ListItem Text="Dwupietrowy" Value="Dwupietrowy"></asp:ListItem>
                                     <asp:ListItem Text="VIP" Value="VIP"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="txtIloscPokoi">Ilość pokoi:</label>
                                <asp:TextBox ID="txtIloscPokoi" runat="server"></asp:TextBox>
                            </div>
                            <asp:Button ID="Button1" CssClass="btn btn-primary mt-2" runat="server" Text="Oblicz" OnClick="btnOblicz_Click" /><br /><br />
                        <asp:Label ID="lblWynik" runat="server" CssClass="alert alert-info mt-3" Visible="false"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>
   </section>
   
</asp:Content>
