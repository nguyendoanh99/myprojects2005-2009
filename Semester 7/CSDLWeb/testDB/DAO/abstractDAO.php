<?php

class AbstractDAO {
	protected $dbh;	
	private $user = 'root'; 
	private $pass = '';
	private $connectString = 'mysql:host=localhost;dbname=himusic';
	private $stmt;
	function __construct() {
		try {
			$this->dbh = new PDO($this->connectString, $this->user, $this->pass);	
			$this->dbh->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
		}catch (PDOException $e) {
 			print "Error!: " . $e->getMessage() . "<br/>";
 			die();
		}
	}
	
	function __destruct() {
		$this->dbh = NULL;
	}
	
	private function createStatement($sql, $arrParam)
	{
		$stmt = $this->dbh->prepare($sql);

		for ($i = 0; $i < count($arrParam); ++$i)
		{
			$stmt->bindParam(($i + 1), $arrParam[$i]);
		}
		return $stmt;
	}
	protected function query($sql, $arrParam, $className)
	{		
		$this->stmt = $this->createStatement($sql, $arrParam);
		$this->stmt->execute();	
		
		$this->stmt->setFetchMode(PDO::FETCH_CLASS, $className, NULL);
		$result = $this->stmt->fetchAll();	
		
		return $result;
	}
	protected function queryID($sql, $arrParam, $className)
	{
		$result = $this->query($sql, $arrParam, $className);
		if (count($result) != 0)
			return $result[0];
		return NULL;
	}
	protected  function executeScalar($sql, $arrParam)
	{
		$this->stmt = $this->createStatement($sql, $arrParam);	
		$this->stmt->execute();		
		
		$result = $this->stmt->fetch(PDO::FETCH_NUM);
		
		return $result[0];
	}
	protected function executeNonQuery($sql, $arrParam)
	{	
		$this->stmt = $this->createStatement($sql, $arrParam);			
		$result = $this->stmt->execute();
		if ($result == true)
			$result = $this->stmt->rowCount();
		else 
			$result = -1;
			
		return $result;		
	}
}

?>