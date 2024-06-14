<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Rejestracja.aspx.cs" Inherits="test3.Rejestracja" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container vh-100">
      <div class="row h-100 justify-content-center align-items-center">
         <div class="col-md-12 mx-auto">
            <div class="card">
                <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <img width="100" src="imgs/generaluser.png"/>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>Zarejestruj się</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6">
                        <label for="FullName">Imię i Nazwisko</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="FullName" runat="server" placeholder="Imię i Nazwisko"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label for="DataUrodzenia">Data urodzenia</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="DataUrodzenia" runat="server" TextMode="Date"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6">
                        <label for="Telefon">Numer telefonu</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="Telefon" runat="server" placeholder="Numer telefonu" TextMode="Number"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label for="Email">Email</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="Email" runat="server" placeholder="example@gmail.com" TextMode="Email"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-4">
                        <label for="Województwo">Województwo</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="Województwo" runat="server" placeholder="Województwo"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label for="Miasto">Miasto</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="Miasto" runat="server" placeholder="Miasto"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label for="KodPocztowy">Kod pocztowy</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="KodPocztowy" runat="server" placeholder="Kod Pocztowy"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <label for="Adres">Pełny adres</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="Adres" runat="server" placeholder="Pełny Adres" TextMode="MultiLine" Rows="2"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-4">
                        <label for="Login">Login</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="Login" runat="server" placeholder="Login"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label for="Hasło">Hasło</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="Hasło" runat="server" placeholder="Hasło" TextMode="Password"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label for="Hasło2">Powtórz hasło</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="Hasło2" runat="server" placeholder="Hasło" TextMode="Password"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-8 mx-auto">
                        <center>
                           <div class="form-group">
                              <asp:Button class="btn btn-primary btn-block btn-lg" ID="Button1" runat="server" Text="Zarejestruj się" OnClick="Button1_Click" /> <br />
                               <asp:Label ID="lblWynik" runat="server" CssClass="alert alert-info mt-3" Visible="false"></asp:Label>
                           </div>
                        </center>
                     </div>
                  </div>
               </div>
            
        </div>
             </div>
          </div>
   </div>
               
</asp:Content>
