<?php
/**
 * Application class, use as a static object for the whole application
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


class Application
{
//	static $Parameters;
	static $Router;
/*	
	static function loadParameters($params)
	{
		self::$Parameters = $params;
	}
	
	static function getParameter($paramName)
	{
		if (array_key_exists($paramName, self::$Parameters))
			return self::$Parameters[$paramName];
		else
			return null;
	}
*/	
	static function setRouter($router)
	{
		self::$Router = $router;
	}
	
	static function route($path)
	{
		self::$Router->delegate($path);
	}
	
	static function run()
	{		
		self::$Router->setPath (SitePath . 'controllers');
		self::$Router->delegate();
	}	
}
?>