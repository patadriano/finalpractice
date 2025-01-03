<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SimpleCRUD._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">ASP.NET</h1>
            <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
            <p><a href="http://www.asp.net" class="btn btn-primary btn-md">Learn more &raquo;</a></p>
        </section>

        <div class="row">

            <asp:UpdatePanel runat="server" ID="UpdatePanel1"  UpdateMode="Conditional" ChildrenAsTriggers="true" >
                <ContentTemplate>
                    <br>
                    <asp:Label ID="DeptName" Text="Department Name" runat="server" />
                    <br>
                    <asp:TextBox runat="server" ID="txtDeptName" />
                     <br>
                    <asp:Button ID="AddDept" Text="Add Dept" runat="server" OnClick="btnDept_Click" />
       
                </ContentTemplate>
            </asp:UpdatePanel>

             <asp:UpdatePanel runat="server" ID="UpdatePanel2"  UpdateMode="Conditional" ChildrenAsTriggers="true" >
                 <ContentTemplate>
                     <asp:DropDownList runat="server" ID="ddlDept"></asp:DropDownList>
                     <br>
                     <asp:Label ID="TeamName" Text="Team Name" runat="server" />
                     <br>
                     <asp:TextBox runat="server" ID="txtTeamName" />
                      <br>
                     <asp:Button ID="AddTeam" Text="Add Team" runat="server" OnClick="btnTeam_Click" />
                    
                 </ContentTemplate>
             </asp:UpdatePanel>

            <asp:UpdatePanel runat="server" ID="UpdatePanel3"  UpdateMode="Conditional" ChildrenAsTriggers="true" >
                <ContentTemplate>
                    <asp:DropDownList runat="server" ID="ddlTeam"></asp:DropDownList>
                    <br>
                    <asp:Label ID="PersonName" Text="Person Name" runat="server" />
                    <br>
                    <asp:TextBox runat="server" ID="txtPersonName" />
                     <br>
                    <asp:Button ID="AddPerson" Text="Add Person" runat="server" OnClick="btnPerson_Click" />
                  
                </ContentTemplate>
            </asp:UpdatePanel>


            <asp:UpdatePanel runat="server" ID="UpdatePanel4"  UpdateMode="Conditional" ChildrenAsTriggers="true" >
                 <ContentTemplate>
                     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="true" OnPageIndexChanging="OnPageIndexChanging" PageSize="10">
                         <Columns>
                         <asp:BoundField DataField="Name" HeaderText="Name" />
                         <asp:BoundField DataField="Age" HeaderText="Age" />
                        </Columns>
                    </asp:GridView>
                 </ContentTemplate>
                </asp:UpdatePanel>
             <asp:Button ID="ReaderButton" Text="Read" runat="server" OnClick="btnReader" />

        </div>
    </main>

</asp:Content>
