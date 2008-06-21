<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" Theme="BlackGlass" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v8.1, Version=8.1.1.0, Culture=neutral, PublicKeyToken=49d90c14d24271b5"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v8.1, Version=8.1.1.0, Culture=neutral, PublicKeyToken=49d90c14d24271b5"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>

<%@ Register Assembly="DevExpress.Web.v8.1, Version=8.1.1.0, Culture=neutral, PublicKeyToken=49d90c14d24271b5"
    Namespace="DevExpress.Web.ASPxClasses" TagPrefix="dxw" %>
<%@ Register Assembly="DevExpress.Web.v8.1, Version=8.1.1.0, Culture=neutral, PublicKeyToken=49d90c14d24271b5"
    Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dxp" %>
<%@ Register Assembly="DevExpress.Web.v8.1, Version=8.1.1.0, Culture=neutral, PublicKeyToken=49d90c14d24271b5"
    Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dxrp" %>

<%@ Register Assembly="DevExpress.XtraCharts.v8.1.Web, Version=8.1.1.0, Culture=neutral, PublicKeyToken=49d90c14d24271b5"
    Namespace="DevExpress.XtraCharts.Web" TagPrefix="dxchartsui" %>
<%@ Register Assembly="DevExpress.XtraCharts.v8.1, Version=8.1.1.0, Culture=neutral, PublicKeyToken=49d90c14d24271b5"
    Namespace="DevExpress.XtraCharts" TagPrefix="cc1" %>

<%@ Register Assembly="DevExpress.Web.v8.1, Version=8.1.1.0, Culture=neutral, PublicKeyToken=49d90c14d24271b5"
    Namespace="DevExpress.Web.ASPxMenu" TagPrefix="dxm" %>
<%@ Register Assembly="DevExpress.Web.v8.1, Version=8.1.1.0, Culture=neutral, PublicKeyToken=49d90c14d24271b5"
    Namespace="DevExpress.Web.ASPxNavBar" TagPrefix="dxnb" %>
<%@ Register Assembly="DevExpress.Web.v8.1, Version=8.1.1.0, Culture=neutral, PublicKeyToken=49d90c14d24271b5"
    Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dxtc" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>

<body>

<script language="javascript" type="text/javascript"><!--
// <!CDATA[
//function is called on changing focused row
function OnGridFocusedRowChanged() {
    // Query the server for the "EmployeeID" and "Notes" fields from the focused row 
    // The values will be returned to the OnGetRowValues() function     
    grid.GetRowValues(grid.GetFocusedRowIndex(), 'MaMonHoc;TenMonHoc;QuiDinhSoTietHocLienTiepToiThieu;QuiDinhSoTietHocLienTiepToiDa', OnGetRowValues);
}
//Value array contains "EmployeeID" and "Notes" field values returned from the server 
function OnGetRowValues(values) {
    MaMonHoc.SetValue(values[0]);
    TenMonHoc.SetValue(values[1]);
    QDSTTT.SetValue(values[2]);
    QDSTTD.SetValue(values[3]);
}
//--></script>
    <form id="form1" runat="server">
    <div>
        <dxm:ASPxMenu ID="ASPxMenu1" runat="server" OnItemClick="ASPxMenu1_ItemClick">
            <Items>
                <dxm:MenuItem Text="Hệ thống">
                    <Items>
                        <dxm:MenuItem Text="Tho&#225;t">
                        </dxm:MenuItem>
                    </Items>
                </dxm:MenuItem>
                <dxm:MenuItem Text="Quản l&#253; dữ liệu">
                    <Items>
                        <dxm:MenuItem Text="M&#244;n học">
                        </dxm:MenuItem>
                        <dxm:MenuItem Text="Lớp học">
                        </dxm:MenuItem>
                        <dxm:MenuItem Text="Gi&#225;o vi&#234;n">
                        </dxm:MenuItem>
                    </Items>
                </dxm:MenuItem>
                <dxm:MenuItem Text="Chức năng">
                    <Items>
                        <dxm:MenuItem Text="Ph&#226;n c&#244;ng giảng dạy">
                        </dxm:MenuItem>
                        <dxm:MenuItem Text="Thời kh&#243;a biểu">
                            <Items>
                                <dxm:MenuItem Text="Lớp học">
                                </dxm:MenuItem>
                                <dxm:MenuItem Text="Gi&#225;o vi&#234;n">
                                </dxm:MenuItem>
                                <dxm:MenuItem Text="Cả trường">
                                </dxm:MenuItem>
                            </Items>
                        </dxm:MenuItem>
                        <dxm:MenuItem Text="Giao diện">
                            <Items>
                                <dxm:MenuItem Name="Office2003Olive" Text="Office 2003 Olive">
                                </dxm:MenuItem>
                                <dxm:MenuItem Name="Office2003Silver" Text="Office 2003 Silver">
                                </dxm:MenuItem>
                                <dxm:MenuItem Name="Office2003Blue" Text="Office 2003 Blue">
                                </dxm:MenuItem>
                                <dxm:MenuItem Name="BlackGlass" Text="BlackGlass">
                                </dxm:MenuItem>
                                <dxm:MenuItem Name="Blue" Text="Blue">
                                </dxm:MenuItem>
                                <dxm:MenuItem Name="Glass" Text="Glass">
                                </dxm:MenuItem>
                                <dxm:MenuItem Name="PlasticBlue" Text="Plastic Blue">
                                </dxm:MenuItem>
                                <dxm:MenuItem Name="RedWine" Text="Red Wine">
                                </dxm:MenuItem>
                                <dxm:MenuItem Name="Soft Orange" Text="Soft Orange">
                                </dxm:MenuItem>
                                <dxm:MenuItem Name="Youthful" Text="Youthful">
                                </dxm:MenuItem>
                            </Items>
                        </dxm:MenuItem>
                    </Items>
                </dxm:MenuItem>
                <dxm:MenuItem Text="Trợ gi&#250;p">
                    <Items>
                        <dxm:MenuItem Text="Th&#244;ng tin">
                        </dxm:MenuItem>
                    </Items>
                </dxm:MenuItem>
            </Items>
        </dxm:ASPxMenu>
        <br />
        <table style="width: 80%; height: 100%;" cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td style="width: 144px; height: 294px" valign="top">
                    <dxnb:ASPxNavBar ID="ASPxNavBar1" runat="server">
                        <Groups>
                            <dxnb:NavBarGroup Text="Quản l&#253; dữ liệu">
                                <Items>
                                    <dxnb:NavBarItem Text="Gi&#225;o vi&#234;n" Name="QLGiaoVien">
                                        <Image Url="~/Images/user_group.ico" />
                                    </dxnb:NavBarItem>
                                    <dxnb:NavBarItem Text="Lớp học" Name="QLLopHoc">
                                        <Image Url="~/Images/Homework.ico" />
                                    </dxnb:NavBarItem>
                                    <dxnb:NavBarItem Text="M&#244;n học" Name="QLMonHoc">
                                        <Image Url="~/Images/Notepad.ico" />
                                    </dxnb:NavBarItem>
                                </Items>
                                <HeaderImage Url="~/Images/Clipboard.ico" />
                            </dxnb:NavBarGroup>
                            <dxnb:NavBarGroup Text="Xếp thời kh&#243;a biểu">
                                <Items>
                                    <dxnb:NavBarItem Text="Cả trường">
                                        <Image Url="~/Images/Home.ico" />
                                    </dxnb:NavBarItem>
                                    <dxnb:NavBarItem Text="Gi&#225;o vi&#234;n">
                                        <Image Url="~/Images/user_group.ico" />
                                    </dxnb:NavBarItem>
                                    <dxnb:NavBarItem Text="Lớp học">
                                        <Image Url="~/Images/Homework.ico" />
                                    </dxnb:NavBarItem>
                                    <dxnb:NavBarItem Text="Ph&#226;n c&#244;ng giảng dạy">
                                        <Image Url="~/Images/documents_yellow_edit.ico" />
                                    </dxnb:NavBarItem>
                                </Items>
                                <HeaderImage Url="~/Images/Recent Documents.ico" />
                            </dxnb:NavBarGroup>
                        </Groups>
                        <ClientSideEvents ItemClick="function(s, e) {
}" />
                    </dxnb:ASPxNavBar>
                </td>
                <td colspan="" rowspan="" style="width: 731px; height: 294px" valign="top">
                    <dxtc:ASPxPageControl ID="ASPxPageControl1" runat="server" ActiveTabIndex="0" Width="100%" ClientInstanceName="pagecontrol">
                        <TabPages>
                            <dxtc:TabPage Text="M&#244;n học" Name="LopHoc">
                                <ContentCollection>
                                    <dxw:contentcontrol id="CCTRL0" runat="server"><dxe:ASPxLabel ID="ASPxLabel5" runat="server" Text="Th&#244;ng tin m&#244;n học" Width="100%" BackColor="Transparent" Font-Bold="True" Font-Names="Courier New" Font-Size="XX-Large" ForeColor="RoyalBlue">
                                    </dxe:ASPxLabel>
<hr />
<table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%"><tr><td style="width: 392px; height: 17px" valign="top">
    <dxrp:ASPxRoundPanel ID="ASPxRoundPanel4" runat="server" HorizontalAlign="Left" ShowHeader="False"
        Width="100%">
        <PanelCollection>
            <dxp:PanelContent runat="server">Thông tin môn học<br /><br /><dxrp:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" HorizontalAlign="Left"
        ShowHeader="False" Width="100%" Height="100%">
<ContentPaddings padding="0px" />
<PanelCollection>
<dxp:PanelContent runat="server"><TABLE style="WIDTH: 100%" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="WIDTH: 161px; HEIGHT: 16px"><dxe:ASPxLabel runat="server" Text="M&#227; m&#244;n học" Width="100px" ID="ASPxLabel1" __designer:wfdid="w80"></dxe:ASPxLabel>


 </TD><TD style="WIDTH: 97px; HEIGHT: 16px"><dxe:ASPxTextBox runat="server" Width="175px" ID="MaMonHoc" ClientInstanceName="MaMonHoc" __designer:wfdid="w81"></dxe:ASPxTextBox>


 </TD></TR><TR><TD style="WIDTH: 161px; HEIGHT: 14px"><dxe:ASPxLabel runat="server" Text="T&#234;n m&#244;n học" Width="171px" ID="ASPxLabel2" __designer:wfdid="w82"></dxe:ASPxLabel>


 </TD><TD style="WIDTH: 97px; HEIGHT: 14px"><dxe:ASPxTextBox runat="server" Width="175px" ID="TenMonHoc" ClientInstanceName="TenMonHoc" __designer:wfdid="w83"></dxe:ASPxTextBox>


 </TD></TR><TR><TD style="WIDTH: 161px; HEIGHT: 10px"><dxe:ASPxLabel runat="server" Text="Qui định số tiết tối thiểu" Width="178px" ID="ASPxLabel3" __designer:wfdid="w84"></dxe:ASPxLabel>


 </TD><TD style="WIDTH: 97px; HEIGHT: 10px"><dxe:ASPxTextBox runat="server" Width="175px" ID="QDSTTT" ClientInstanceName="QDSTTT" __designer:wfdid="w85"></dxe:ASPxTextBox>


 </TD></TR><TR><TD style="WIDTH: 161px; HEIGHT: 9px"><dxe:ASPxLabel runat="server" Text="Qui định số tiết tối đa" Width="178px" ID="ASPxLabel4" __designer:wfdid="w86"></dxe:ASPxLabel>


 </TD><TD style="WIDTH: 97px; HEIGHT: 9px"><dxe:ASPxTextBox runat="server" Width="175px" ID="QDSTTD" ClientInstanceName="QDSTTD" __designer:wfdid="w87"></dxe:ASPxTextBox>


 </TD></TR></TBODY></TABLE></dxp:PanelContent>
</PanelCollection>
</dxrp:ASPxRoundPanel>

 <br /><dxrp:ASPxRoundPanel ID="ASPxRoundPanel2" runat="server"
        Width="100%" ShowHeader="False"><PanelCollection>
<dxp:PanelContent runat="server">&nbsp;<dxwgv:ASPxGridView runat="server" Width="100%" ID="ASPxGridView1" DataSourceID="AccessDataSource1" KeyFieldName="T&#234;n gi&#225;o vi&#234;n" AutoGenerateColumns="False" __designer:wfdid="w89">
<Settings ShowHeaderFilterButton="True" ShowFilterRow="True"></Settings>

<SettingsBehavior ColumnResizeMode="Control" AllowFocusedRow="True"></SettingsBehavior>
<Columns>
<dxwgv:GridViewDataTextColumn VisibleIndex="0" FieldName="T&#234;n gi&#225;o vi&#234;n"></dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn VisibleIndex="1" FieldName="T&#234;n tắt"></dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn VisibleIndex="2" FieldName="C&#225;c lớp học phụ tr&#225;ch"></dxwgv:GridViewDataTextColumn>
</Columns>
</dxwgv:ASPxGridView>


 </dxp:PanelContent>
</PanelCollection>
</dxrp:ASPxRoundPanel>

 </dxp:PanelContent>
        </PanelCollection>
    </dxrp:ASPxRoundPanel>
 </td><td style="height: 17px" valign="top">
     <dxrp:ASPxRoundPanel ID="ASPxRoundPanel3" runat="server" HorizontalAlign="Left" ShowHeader="False"
         Width="100%">
         <PanelCollection>
             <dxp:PanelContent runat="server">Danh sách môn học<br /><br /><dxwgv:ASPxGridView ID="ASPxGridView2" runat="server" AutoGenerateColumns="False"
        DataSourceID="AccessDataSource2" KeyFieldName="MaMonHoc" Width="100%" ClientInstanceName="grid">
<ClientSideEvents 
FocusedRowChanged="function(s, e) {
OnGridFocusedRowChanged();
}" />

<Settings ShowFilterRow="True" ShowHeaderFilterButton="True" />

<SettingsBehavior AllowFocusedRow="True" ColumnResizeMode="Control" />
<Columns>
<dxwgv:GridViewDataTextColumn FieldName="MaMonHoc" ReadOnly="True" VisibleIndex="0"></dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="TenMonHoc" VisibleIndex="1"></dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="QuiDinhSoTietHocLienTiepToiThieu" VisibleIndex="2"></dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn FieldName="QuiDinhSoTietHocLienTiepToiDa" VisibleIndex="3"></dxwgv:GridViewDataTextColumn>
</Columns>
</dxwgv:ASPxGridView>

 </dxp:PanelContent>
         </PanelCollection>
     </dxrp:ASPxRoundPanel>
 </td></tr></table></dxw:contentcontrol>
                                </ContentCollection>
                                <TabImage Url="~/Images/Notepad.ico" />
                            </dxtc:TabPage>
                            <dxtc:TabPage Text="Lớp học">
                                <ContentCollection>
                                    <dxw:contentcontrol id="CCTRL1" runat="server"></dxw:contentcontrol>
                                </ContentCollection>
                            </dxtc:TabPage>
                            <dxtc:TabPage Text="Gi&#225;o vi&#234;n" Name="GiaoVien">
                                <ContentCollection>
                                    <dxw:contentcontrol id="CCTRL2" runat="server"></dxw:contentcontrol>
                                </ContentCollection>
                            </dxtc:TabPage>
                            <dxtc:TabPage Text="Ph&#226;n c&#244;ng giảng dạy">
                                <ContentCollection>
                                    <dxw:contentcontrol id="CCTRL3" runat="server"></dxw:contentcontrol>
                                </ContentCollection>
                            </dxtc:TabPage>
                            <dxtc:TabPage Text="Thời kh&#243;a biểu lớp học">
                                <ContentCollection>
                                    <dxw:contentcontrol id="CCTRL4" runat="server"></dxw:contentcontrol>
                                </ContentCollection>
                            </dxtc:TabPage>
                            <dxtc:TabPage Text="Lịch dạy gi&#225;o vi&#234;n">
                                <ContentCollection>
                                    <dxw:contentcontrol id="CCTRL5" runat="server"></dxw:contentcontrol>
                                </ContentCollection>
                            </dxtc:TabPage>
                            <dxtc:TabPage Text="Thời kh&#243;a biểu cả trường">
                                <ContentCollection>
                                    <dxw:contentcontrol id="CCTRL6" runat="server"></dxw:contentcontrol>
                                </ContentCollection>
                            </dxtc:TabPage>
                        </TabPages>
                    </dxtc:ASPxPageControl>
                </td>
            </tr>
        </table>
    
    </div>
        &nbsp;
        <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/App_Data/PTNK.mdb"
            SelectCommand="SELECT GiaoVien.HoTenGiaoVien AS [Tên giáo viên], GiaoVien.TenTat AS [Tên tắt], LopHoc.TenLopHoc AS [Các lớp học phụ trách] FROM ((GiaoVien INNER JOIN PhanCong ON GiaoVien.MaGiaoVien = PhanCong.MaGiaoVien) INNER JOIN LopHoc ON PhanCong.MaLopHoc = LopHoc.MaLopHoc)">
        </asp:AccessDataSource>
        <asp:AccessDataSource ID="AccessDataSource2" runat="server" DataFile="~/App_Data/PTNK.mdb"
            SelectCommand="SELECT * FROM [MonHoc]"></asp:AccessDataSource>
    </form>
</body>
</html>
