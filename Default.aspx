<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PatExam._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>

     
         <div class="bg-primary text-white"> I love HTML </div>
    <div class="bg-danger text-white"> I love CSS </div>
    <div class="bg-warning text-dark"> I love JavaScript </div>



	

        <div class="row">
            <%--Department--%>
            <asp:UpdatePanel runat="server" ID="UpdatePanel2"  UpdateMode="Conditional" ChildrenAsTriggers="true" >
                <ContentTemplate>
                    <br>
                    <asp:Label ID="Label2" Text="DepartmentName" runat="server" />
                    <asp:TextBox runat="server" ID="txtDeptName" />
                     
                    <asp:Label ID="Labell" Text="DepartmentHead" runat="server" />
                    <asp:TextBox runat="server" ID="txtDeptHead" />
                    
                    <asp:Button ID="Buttono" Text="Add Dept" runat="server" OnClick="btnAddDept_Click" />
                </ContentTemplate>
            </asp:UpdatePanel>

             <%--Team--%>
            <asp:UpdatePanel runat="server" ID="updTeam" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                    <asp:DropDownList runat="server" ID="ddlDept" OnSelectedIndexChanged="ddlTeamFilter_SelectedIndexChanged"></asp:DropDownList>
                    <asp:Label ID="lblTeamName" Text="TeamName" runat="server" />
                    <asp:TextBox runat="server" ID="txtTeamName" />
                    <asp:Label ID="lblTeamLead" Text="Name of Team Lead" runat="server" />
                    <asp:TextBox runat="server" ID="txtTeamLead" />
                    <asp:Label ID="lblDeptName" Text="Department Name" runat="server" />
                    <asp:TextBox runat="server" ID="txtDeptNameTeam" />
                    <asp:Button ID="btnAddTeam" Text="Add Team" runat="server" OnClick="btnAddTeam_Click" />
                </ContentTemplate>
            </asp:UpdatePanel>

             <%--Employee--%>
            <asp:UpdatePanel runat="server" ID="UpdatePanel1"  UpdateMode="Conditional" ChildrenAsTriggers="true" >
                <ContentTemplate>
                   <br>
                     <asp:DropDownList runat="server" ID="ddlTeam" OnSelectedIndexChanged="ddlTeamFilter_SelectedIndexChanged2"></asp:DropDownList>
                    <asp:Label ID="Label4" Text="Employee Name" runat="server" />
                    <asp:TextBox runat="server" ID="txtName" />
                    <asp:Button ID="Button1" Text="Add Member" runat="server" OnClick="btnAddMember_Click" />
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdatePanel runat="server" ID="UpdatePanel3"  UpdateMode="Conditional" ChildrenAsTriggers="true" >
                <ContentTemplate>
                   
                </ContentTemplate>
            </asp:UpdatePanel>

          <%--  grid--%>
            <asp:UpdatePanel runat="server" ID="UpdatePanel4"  UpdateMode="Conditional" ChildrenAsTriggers="true" AutoPostBack="true" >
                <ContentTemplate>
      
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="True" 
                CellPadding="4" ForeColor="#333333" GridLines="None">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID"  />
                    <asp:BoundField DataField="Name" HeaderText="Name"  />
     
                </Columns>
            </asp:GridView>
       
                </ContentTemplate>
            </asp:UpdatePanel>

            <%--grid--%>
            <asp:UpdatePanel runat="server" ID="UpdatePanel6"  UpdateMode="Conditional" ChildrenAsTriggers="true" AutoPostBack="true">
                <ContentTemplate>
      
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="True" 
                CellPadding="4" ForeColor="#333333" GridLines="None">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID"  />
                    <asp:BoundField DataField="Name" HeaderText="Name"  />
        
                </Columns>
            </asp:GridView>
       
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </main>

</asp:Content>
