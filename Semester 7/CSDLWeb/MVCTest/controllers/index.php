<?php

class index Extends ControllerBase {

	/**
	 * Enter description here...
	 *
	 * @param unknown_type $params
	 * @return index
	 */
	 function _index(){
	 	$view = new View();
	 	$view->masterpage = 'test/template';
	 	$view->show('default');
	 }
}

?>
