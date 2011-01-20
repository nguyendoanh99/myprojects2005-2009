<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MultipleFileUpload.ascx.cs"
    Inherits="MultipleFileUpload" %>
<script language="javascript" type="text/javascript">
<!--

// -->
</script>

<asp:Panel ID="pnlParent" runat="server" Width="337px" BorderColor="Black" BorderWidth="1px"
    BorderStyle="None" Height="60px" style="left: 172px; top: 242px">
    <asp:Panel ID="pnlFiles" runat="server" Width="300px" HorizontalAlign="Left" Height="22px" style="position: absolute">
        &nbsp;
        <asp:FileUpload ID="IpFile" runat="server" style="left: 4px; position: absolute; top: 0px" Width="310px" Height="24px" />
        &nbsp;
        </asp:Panel>
    &nbsp; &nbsp;
    <asp:Panel ID="pnlButton" runat="server" Width="300px" HorizontalAlign="Right" style="position: relative; left: 3px; top: -15px;" Height="39px">
        <asp:Button ID="btnUpload" OnClientClick="javascript:return DisableTop();" runat="server"
            Text="Upload" Width="60px" OnClick="btnUpload_Click" style="left: 164px; position: absolute; top: 28px" />
            </asp:Panel>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;</asp:Panel>
