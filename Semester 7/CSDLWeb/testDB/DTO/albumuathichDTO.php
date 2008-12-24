<?php
class albumuathichDTO
{		
	private  $MaAlbumUaThich;
	private  $TenAlbumUaThich;
	private  $MaTaiKhoan;

	public function getMaAlbumUaThich() {
		return $this->MaAlbumUaThich;
	}
	
	public function setMaAlbumUaThich($MaAlbumUaThich) {
		$this->MaAlbumUaThich = $MaAlbumUaThich;
	}
	public function getTenAlbumUaThich() {
		return $this->TenAlbumUaThich;
	}
	
	public function setTenAlbumUaThich($TenAlbumUaThich) {
		$this->TenAlbumUaThich = $TenAlbumUaThich;
	}
	public function getMaTaiKhoan() {
		return $this->MaTaiKhoan;
	}
	
	public function setMaTaiKhoan($MaTaiKhoan) {
		$this->MaTaiKhoan = $MaTaiKhoan;
	}
}
?>