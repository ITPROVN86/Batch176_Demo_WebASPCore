<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ExampleWAD1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>

        <div class="row">
            <section class="col-md-4" aria-labelledby="gettingStartedTitle">
                <div class="form-body">
                    <div class="row">
                        <div class="col-md-3">
                            Username:
                        </div>
                        <div class="col-md-9">
                            <asp:TextBox ID="txtUsername" runat="server" MaxLength="100" placeholder="Mời nhập tên" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            Password:
                        </div>
                        <div class="col-md-9 mt-1">
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" MaxLength="100" placeholder="Mời nhập mật khẩu" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-3 mt-1">
                            <asp:Label ID="lblfail" runat="server" CssClass="text-danger"></asp:Label>
                            <asp:Button Width="100%" ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-danger" OnClick="btnLogin_Click" />
                        </div>
                    </div>
                </div>
            </section>
            <section class="col-md-4" aria-labelledby="gettingStartedTitle">
                <div class="form-body">
                    <div class="col-md-auto">
                        Giá trị a:
                    </div>
                    <div class="col-md-6 form-group">
                        <asp:TextBox ID="txtA" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-auto">
                        Giá trị b:
                    </div>
                    <div class="col-md-6 form-group">
                        <asp:TextBox ID="txtB" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-3 form-group">
                        <asp:Label ID="lblResult" runat="server" CssClass="text-danger"></asp:Label>
                        <asp:Button Width="100%" ID="btnAdd" runat="server" Text="Cộng" CssClass="btn btn-danger" OnClick="btnAdd_Click" />
                    </div>
                </div>
            </section>
            <section class="col-md-4" aria-labelledby="gettingStartedTitle">
                <div class="form-body">
                    <asp:Label ID="lblCheckFile" runat="server" CssClass="text-danger"></asp:Label>
                    <asp:Button Width="100%" ID="btnCheckFile" runat="server" Text="Check File" CssClass="btn btn-danger" OnClick="btnCheckFile_Click" />
                </div>
            </section>
            <section class="col-md-4" aria-labelledby="gettingStartedTitle">
                <div class="form-body">
                    <ul>
                    <%
                        XElement xmlElement = XElement.Load(@"D:\AP23\Projects\WAD1808\ExampleWAD1\Employee.xml");
                        var result = from list in xmlElement.Elements("Employee")
                                     where (string)list.Element("EmpLocation") == "Quảng Nam"
                                     select list;
                        foreach (XElement i in result)
                        {
                    %><li><%= i.Element("EmpName") %></li>
                    <%  }
                    %>
                        </ul>
                </div>
            </section>
        </div>
    </main>

</asp:Content>
