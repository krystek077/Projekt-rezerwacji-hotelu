<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ZalogujSie.aspx.cs" Inherits="test3.ZalogujSie" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container vh-100 overflow-hidden">
      <div class="row h-100 justify-content-center align-items-center">
         <div class="col-md-6 mx-auto">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <img width="150" src="imgs/generaluser.png"/>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <h3>Logowanie</h3>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <label for="login">Login</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="login" runat="server" placeholder="Login"></asp:TextBox>
                        </div>
                        <label for="haslo">Hasło</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="haslo" runat="server" placeholder="Hasło" TextMode="Password"></asp:TextBox>
                        </div>
                        <div class="form-group">
                           <asp:Button class="btn btn-success btn-block btn-lg" ID="Button1" runat="server" Text="Zaloguj się" OnClick="Button1_Click" />
                        </div>
                         <div class="form-group text-center">
                            <asp:LinkButton ID="lnkNiePamietamHasla" runat="server" NavigateUrl="" CssClass="btn btn-link">Nie pamiętam hasła</asp:LinkButton>
                            <asp:HyperLink ID="lnkRejestracja" runat="server" NavigateUrl="~/Rejestracja.aspx" CssClass="btn btn-link">Zarejestruj się</asp:HyperLink>
                        </div>
                     </div>
                  </div>
               </div>
            </div>
         </div>
      </div>
   </div>
</asp:Content>
