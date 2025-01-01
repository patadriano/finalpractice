<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RealCrud._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">ASP.NET</h1>
            <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
            <p><a href="http://www.asp.net" class="btn btn-primary btn-md">Learn more &raquo;</a></p>
        </section>

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
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" 
                      OnRowEditing="GridView1_RowEditing"
                      OnRowUpdating="GridView1_RowUpdating"
                      OnRowCancelingEdit="GridView1_RowCancelingEdit">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" />

               
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                    
                        <asp:Label ID="LabelName" runat="server" Text='<%# Eval("Name") %>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                      
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("Name") %>' />
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>


        </div>
    </main>

</asp:Content>
