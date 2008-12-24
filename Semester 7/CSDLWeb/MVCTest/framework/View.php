<?php
/**
 * Template class
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
Class View {
	private $vars = array();
	public $masterpage = '';
	public $CurrentURL = '';
	function __construct() {
	}

	function set($varname, $value, $overwrite=false) {
		if (isset($this->vars[$varname]) == true AND $overwrite == false) {
			trigger_error ('Unable to set var `' . $varname . '`. Already set, and overwrite not allowed.', E_USER_NOTICE);
			return false;
		}

		$this->vars[$varname] = $value;
		return true;
	}

	function remove($varname) {
		unset($this->vars[$varname]);
		return true;
	}

	function show($name) {
		$path = SitePath . 'view' . DIRSEP . $name . '.php';
		$layout = SitePath . 'masterpage/' . $this->masterpage . '.php';

		if (file_exists($path) == false) {
			trigger_error ('Template `' . $name . '` does not exist.', E_USER_NOTICE);
			return false;
		}

		// Load variables
		foreach ($this->vars as $key => $value) {
			$$key = $value;
		}
		
		// Get widgets to show
		$widgets = $this->getWidgets($name);
		
		$pos = strrpos($this->masterpage, "/");
		$cur = "";
		if ($pos != false)
			$cur = substr($this->masterpage, 0, $pos + 1);
		
		$pos = strrpos($_SERVER['PHP_SELF'], "/");
		$this->CurrentURL = 'http://' . $_SERVER['SERVER_NAME'] . substr($_SERVER['PHP_SELF'], 0, $pos + 1) . 'masterpage/' . $cur;
		
		include_once($layout);
	}
	
	protected function getWidgets($page)
	{
		$widgetConfig = SitePath . 'widgets.xml';
		$pages = simplexml_load_file($widgetConfig);
		foreach($pages->page as $pageElement)
		{
			if ($pageElement['path'] == $page)
				return $pageElement->xpath('//widget');
		}
		return $pages->page[0]->xpath('//widget');
	}

	protected function loadWidgets($widgets, $separator = "\n")
	{
		if (count($widgets))
			foreach($widgets as $widget)
			{
				$widgetPath = SitePath . 'widgets' . DIRSEP . $widget['id'] . '.php';
				echo '<div class="widget">';
				include_once($widgetPath);
				echo '</div>' . $separator;
			}
	}
}

?>