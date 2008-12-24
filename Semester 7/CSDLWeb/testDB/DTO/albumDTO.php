<?php
class albumDTO
{		
	private  $MaAlbum;
	private  $TenAlbum;
	private  $NgayPhatHanh;
	private  $MaCaSi;

	public function getMaAlbum() {
		return $this->MaAlbum;
	}
	
	public function setMaAlbum($MaAlbum) {
		$this->MaAlbum = $MaAlbum;
	}
	public function getTenAlbum() {
		return $this->TenAlbum;
	}
	
	public function setTenAlbum($TenAlbum) {
		$this->TenAlbum = $TenAlbum;
	}
	public function getNgayPhatHanh() {
		return $this->NgayPhatHanh;
	}
	
	public function setNgayPhatHanh($NgayPhatHanh) {
		$this->NgayPhatHanh = $NgayPhatHanh;
	}
	public function getMaCaSi() {
		return $this->MaCaSi;
	}
	
	public function setMaCaSi($MaCaSi) {
		$this->MaCaSi = $MaCaSi;
	}
}
?>