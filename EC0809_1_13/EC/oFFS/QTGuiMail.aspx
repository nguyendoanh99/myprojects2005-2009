<%@ Page ValidateRequest="false" Language="C#" MasterPageFile="~/MPAdmin.master" AutoEventWireup="true" CodeFile="QTGuiMail.aspx.cs" Inherits="QTGuiMail" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<LINK href="css/template[1].css" type="text/css" rel="stylesheet">

<link rel="stylesheet" type="text/css" href="build/assets/skins/sam/skin.css"/>
 <!-- Utility Dependencies -->
    <script type="text/javascript" src="build/yahoo-dom-event/yahoo-dom-event.js"></script> 
    <script type="text/javascript" src="build/element/element-beta-min.js"></script> 
    <!-- Needed for Menus, Buttons and Overlays used in the Toolbar -->
    <script type="text/javascript" src="build/container/container_core-min.js"></script>
    <script type="text/javascript" src="build/menu/menu-min.js"></script>
    <script type="text/javascript" src="build/button/button-min.js"></script>
    <!-- Source file for Rich Text Editor-->
    <script type="text/javascript" src="build/editor/editor-min.js"></script>
    <script type="text/javascript" src="He Khach/XL_QTGuiMail.js"> </script>
    
        <div class="ushead" > 
	    <div class="uscontentheading"><h3>Gửi mail</h3></div> 
	    </div> 
	
	    <div class="ushead_logo"> 
		    <img src="images_layout/personal.png" /> 
	    </div> 
	    <div style="height:8px; clear:both; width:100%;"></div> 
	    <div class="usform_top"> 
	    <div class="usform_topleft"> 
	    <div class="usform_topright">&nbsp;
	    </div></div></div> 
    		
	    <div class="usform"> 
	    <div class="usform_right" style="height:67%;"> 
	    <div class="usform_left"> 
	    <form action="QTGuiMail.aspx?request=GuiMail" method="post" accept-charset=>
        <table width="100%" cellpadding="2" cellspacing="2" border="0" align="center" class="contentpaneopen" style="height: 190px"> 
          <tr> 
            <th>
                Username:</th> 
	        <td style="height: 10px" >
                <select name="Username" id="idUsername" style="width: 287px">
                </select>
                    <input id="butGui" type="submit" value="Gửi" onclick="GuiEmail()" /></td> 
          </tr> 
          <tr> 
	        <th>
                Tiêu đề:</th> 
	        <td >
                <input name="subject" id="idTieuDe" style="width: 284px" type="text"/>
                </td> 
          </tr> 
          <tr>
            <td colspan="2" class="yui-skin-sam">
                <textarea name="msgpost" id="msgpost" rows="10" style="width: 100%">
                </textarea> </td>
          </tr>       
        </table>     
        </form>
    </div></div></div>    
    <script type="text/javascript">
        Load();
    </script>
</asp:Content>

