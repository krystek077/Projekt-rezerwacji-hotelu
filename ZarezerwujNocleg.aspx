<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ZarezerwujNocleg.aspx.cs" Inherits="test3.ZarezerwujNocleg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
    <div class="container vh-100">
        <div class="row justify-content-center h-100 d-flex align-items-center">
            <div class="col-md-6 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <h2 class="card-title text-center">Formularz rezerwacji</h2>
                            <div class="form-group">
                                <label for="datarozpoczecia">Data rozpoczęcia:</label>
                                <asp:TextBox ID="datarozpoczecia" CssClass="form-control" runat="server" type="date"></asp:TextBox>
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
                            <asp:Button ID="Button1" CssClass="btn btn-primary mt-2" runat="server" Text="Zarezerwuj" OnClick="Button1_Click"/><br /><br />
                        <asp:Label ID="lblWynik" runat="server" CssClass="alert alert-info mt-3" Visible="false"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>
 </section>
</asp:Content>
