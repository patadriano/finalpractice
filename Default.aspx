<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CRUD._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
      

        <div class="row">
            
              <%--  <asp:UpdatePanel runat="server" ID="UpdatePanel1"  UpdateMode="Conditional" ChildrenAsTriggers="true" >
                 <ContentTemplate>
                     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="true"  PageSize="10">
                         <Columns>
                         <asp:BoundField DataField="Id" HeaderText="Id" />
                         <asp:BoundField DataField="Name" HeaderText="Name" />
                             <asp:TemplateField>
                                <ItemTemplate>
                                    <!-- Edit Button -->
                                    <asp:Button ID="EditButton" runat="server" 
                                                Text="Edit" 
                                                CommandName="Edit"
                                                OnClick="EditButton_Click" />
                                    <!-- Delete Button -->
                                    <asp:Button ID="DeleteButton" runat="server" 
                                                Text="Delete" 
                                                CommandName="Delete"
                                                OnClick="DeleteButton_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                 </ContentTemplate>
                </asp:UpdatePanel>--%>
             <%--<asp:Button ID="ReaderButton" Text="Read" runat="server" OnClick="btnReader" />--%>
            
   <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
    <ContentTemplate>
        <div id="appear" runat="server" visible="false" style="margin: 20px; padding: 10px; border: 1px solid #ccc; width: 300px;">
            <asp:TextBox ID="TextBox1" runat="server" placeholder="Enter Name" style="display: block; margin-bottom: 10px;" />
            <asp:TextBox ID="TextBox2" runat="server" placeholder="Enter Age" style="display: block; margin-bottom: 10px;" />
            <asp:TextBox ID="TextBox3" runat="server" placeholder="Enter Address" style="display: block; margin-bottom: 10px;" />
            <asp:TextBox ID="TextBox4" runat="server" placeholder="Enter Email" style="display: block; margin-bottom: 10px;" />
            <asp:Button ID="Button1" Text="Save" runat="server" OnClick="ButtonOne" style="display: block;" />
        </div>
    </ContentTemplate>
</asp:UpdatePanel>


            <asp:UpdatePanel runat="server" ID="UpdatePanel1"  UpdateMode="Conditional" ChildrenAsTriggers="true" >
                 <ContentTemplate>
                      <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" 
                      OnRowEditing="GridView1_RowEditing"
                      OnRowUpdating="GridView1_RowUpdating"
                      OnRowCancelingEdit="GridView1_RowCancelingEdit"
                      OnRowDeleting="GridView1_RowDeleting"
                                
                                AllowPaging="true"
                                PageSize="2"
                                OnPageIndexChanging="GridView1_PageIndexChanging">
                                
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" />
               
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                    
                        <asp:Label ID="LabelName" runat="server" Text='<%# Eval("Name") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                      
                        <asp:TextBox ID="TextBoxName" runat="server" Text='<%# Eval("Name") %>' />
                    </EditItemTemplate>
                </asp:TemplateField>

               
                <asp:TemplateField HeaderText="Age">
                    <ItemTemplate>
                        <asp:Label ID="LabelAge" runat="server" Text='<%# Eval("Age") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBoxAge" runat="server" Text='<%# Eval("Age") %>' />
                    </EditItemTemplate>
                </asp:TemplateField>

    
                <asp:TemplateField HeaderText="Address">
                    <ItemTemplate>
                        <asp:Label ID="LabelAddress" runat="server" Text='<%# Eval("Address") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBoxAddress" runat="server" Text='<%# Eval("Address") %>' />
                    </EditItemTemplate>
                </asp:TemplateField>

    
                <asp:TemplateField HeaderText="Email">
                    <ItemTemplate>
                        <asp:Label ID="LabelEmail" runat="server" Text='<%# Eval("Email") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBoxEmail" runat="server" Text='<%# Eval("Email") %>' />
                    </EditItemTemplate>
                </asp:TemplateField>


                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
                     <asp:Button runat="server" ID="btnExport" Text="Export to Text File" OnClick="ExportData_Click" />
                     <asp:Button runat="server" ID="Button2" Text="add" OnClick="add_Click" />
             </ContentTemplate>
</asp:UpdatePanel>
           
        </div>
    </main>

</asp:Content>
