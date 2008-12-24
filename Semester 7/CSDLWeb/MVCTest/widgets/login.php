<?php
$user = Application::getUser();

if (!isset($user) || $user === null)
{ ?>
<div class="field_label">Username:</div>
<div class="field_input"><input type="text" name="username" id="username" value="" /></div>
<div class="field_label">Password:</div>
<div class="field_input"><input type="password" name="password" id="password" value="" /></div>
<div class="field_input"><input type="button" name="login" id="login" value="Login" onClick="javascript:doSubmit('<?php echo SiteUrl ?>/members/Member/login')" /></div>
<?php
}else{ 
	include_once('usermenus.php');
}
?>