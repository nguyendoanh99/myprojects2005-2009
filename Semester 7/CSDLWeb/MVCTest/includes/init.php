<?php
/**
 * Init file
 *
 *
 * LICENSE: 
 * This demo contains an MVC framework developed by Nguyen Thai Hung at artemis.com.vn
 * You are allowed using this MVC framework in study, research and developing non-commercial
 * web sites.
 * Please keep this lines intact in all projects you use the MVC framework.
 *
 * @copyright  2008 Artemis Software LLC.
 * @license    http://www.artemis.com.vn
 * @version    CVS: $Id:$
 * @since      File available since Release 0
*/ 
error_reporting (E_ALL);
if (version_compare(phpversion(), '5.1.0', '<') == true) { die ('PHP5.1 Only'); }

// Constants:
define ('DIRSEP', DIRECTORY_SEPARATOR);

// Get site path
$site_path = realpath(dirname(__FILE__) . DIRSEP . '..' . DIRSEP) . DIRSEP;
define ('SitePath', $site_path);

$path = SitePath;

$includePath = get_include_path();
$includePath .= PATH_SEPARATOR . $path . DIRSEP . 'DTO';
$includePath .= PATH_SEPARATOR . $path . DIRSEP . 'DAO';
$includePath .= PATH_SEPARATOR . $path . DIRSEP . 'controllers';
$includePath .= PATH_SEPARATOR . $path . DIRSEP . 'framework';

set_include_path($includePath);

function __autoload($class_name) {
   include_once $class_name . '.php';
}

?>