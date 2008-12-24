<?php
class downloadDTO
{		
	private  $MaDownload;
	private  $MaTaiKhoan;
	private  $MaBaiHat;
	private  $NgayDownload;

	public function getMaDownload() {
		return $this->MaDownload;
	}
	
	public function setMaDownload($MaDownload) {
		$this->MaDownload = $MaDownload;
	}
	public function getMaTaiKhoan() {
		return $this->MaTaiKhoan;
	}
	
	public function setMaTaiKhoan($MaTaiKhoan) {
		$this->MaTaiKhoan = $MaTaiKhoan;
	}
	public function getMaBaiHat() {
		return $this->MaBaiHat;
	}
	
	public function setMaBaiHat($MaBaiHat) {
		$this->MaBaiHat = $MaBaiHat;
	}
	public function getNgayDownload() {
		return $this->NgayDownload;
	}
	
	public function setNgayDownload($NgayDownload) {
		$this->NgayDownload = $NgayDownload;
	}
}
?>