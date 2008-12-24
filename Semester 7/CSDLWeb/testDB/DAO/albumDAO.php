<?php
//}
class AlbumDAO extends AbstractDAO {
	
	function ThongTinAlbum($MaAlbum, $TenAlbum)
	{							
		return $this->query("select * from Album where MaAlbum = ? and TenAlbum = ?",
		 array($MaAlbum, $TenAlbum), "AlbumDTO");
	}
	
	function TongSoAlbum()
	{	
		return $this->executeScalar("select * from Album", array());
	}
	
	function CapNhatAlbum($MaAlbum, $TenAlbum)
	{		  
		return $this->executeNonQuery("update Album set TenAlbum = ? where MaAlbum = ?", 
			array($MaAlbum, $TenAlbum));	
	}
}

?>