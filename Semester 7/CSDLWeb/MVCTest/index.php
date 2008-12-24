<?php
/**
 * Site gateway
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
# Startup tasks
require_once 'includes/init.php';

# Load router
$router = new Router();
Application::setRouter($router);
Application::run();	
?>