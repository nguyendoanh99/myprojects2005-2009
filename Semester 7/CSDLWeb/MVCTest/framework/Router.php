<?php
/**
 * Router class
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
Class Router {
	private $path;
	private $args = array();

	function setPath($path) {
		$path = trim($path, '/\\');
		$path .= DIRSEP;

		if (is_dir($path) == false) {
			throw new Exception ('Invalid controller path: `' . $path . '`');
		}

		$this->path = $path;
	}

	function getArg($key) {
		if (!isset($this->args[$key])) { return null; }
		return $this->args[$key];
	}

	function delegate($route = null) {
		// Analyze route
		$this->getController($file, $controller, $action, $args, $route);

		// File available?
		if (is_readable($file) == false) {
			$this->notFound('no-file');
		}

		// Include the file
		include_once($file);

		// Initiate the class
		$class = $controller;
		$controller = new $class();

		// Action available?
		if (is_callable(array($controller, $action)) == false) {
			$this->notFound('no-action');
		}

		// Run action
		$controller->$action($args);
	}

	private function extractArgs($args) {
		if (count($args) == 0) { return false; }
		$this->args = $args;
	}
	
	private function getController(&$file, &$controller, &$action, &$args, $route = null) {
		if ($route === null)
			$route = (empty($_GET['route'])) ? '' : $_GET['route'];

		if (empty($route)) { $route = 'index';}

		// Get separate parts
		$route = trim($route, '/\\');
		$parts = explode('/', $route);

		// Find right controller
		$cmd_path = $this->path;
		foreach ($parts as $part) {
			$fullpath = $cmd_path . $part;
			
			// Is there a dir with this path?
			if (is_dir($fullpath)) {
				$cmd_path .= $part . DIRSEP;
				array_shift($parts);
				continue;
			}

			// Find the file
			if (is_file($fullpath . '.php')) {
				$controller = $part;
				array_shift($parts);
				break;
			}
		}

		if (empty($controller)) { $controller = 'home'; };
		// Get action
		$action = array_shift($parts);
		if (empty($action)) { $action = '_index'; }

		$file = $cmd_path . $controller . '.php';
		$args = $parts;
	}


	private function notFound() {
		die("404 Not Found");
	}

}

?>