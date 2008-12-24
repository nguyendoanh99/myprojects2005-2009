<?php

error_reporting (E_ALL);
if (version_compare(phpversion(), '5.1.0', '<') == true) { die ('PHP5.1 Only'); }

// Constants:
define ('DIRSEP', DIRECTORY_SEPARATOR);

// Get site path
$site_path = realpath(dirname(__FILE__) . DIRSEP . '..' . DIRSEP) . DIRSEP;
define ('SitePath', $site_path);
$path = get_include_path();
$includePath = get_include_path();
$includePath .= PATH_SEPARATOR . $path . DIRSEP . 'DTO';
$includePath .= PATH_SEPARATOR . $path . DIRSEP . 'DAO';
set_include_path($includePath);
function __autoload($class_name) {
   require_once $class_name . '.php';
}
	
	$t = new AlbumDAO();
		
	$result = $t->ThongTinAlbum(1, 'bbb');
	var_dump($result);
	$result = $t->ThongTinAlbum1(-2);
	var_dump($result);
	$result = $t->TongSoAlbum();
	var_dump($result);
	$result = $t->CapNhatAlbum(3, 'bbb');
	var_dump($result);
?>