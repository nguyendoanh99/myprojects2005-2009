<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
	
	<link rel="stylesheet" type="text/css" href="<?php echo SiteUrl ?>/themes/default/standard.css" />
	<title>default</title>
</head>
<body>
<div class="header">
<h1><a href="<?php echo SiteUrl ?>">I-blog!</a></h1>
<h2>Another little space in phpvn.org</h2>
<div class="mainmenu">
Main menu
</div>
</div>

<div class="shim column"></div>
<form id="form1" name="form" method="post" action="index.php">

	<div class="page" id="home">
		<div id="sidebar">
 <?php //$this->loadWidgets($widgets, "<hr />"); ?>
			
			
		</div>
		<div id="content">
			<?php include_once($path); ?>
			
		</div>	
	</div>
</form>
<div class="footerbg">
	<div class="footer">
		<br />
		A simple MVC framework - by Hung5s (c) 1/2008<br />
		<a href="http://artemis.com.vn">Artemis Software LLC.</a>
	</div>
</div>

</body>
</html>