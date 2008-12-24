<?php
class commentDTO
{		
	private  $MaComment;
	private  $MaTaiKhoan;
	private  $MaBaiHat;
	private  $NgayDang;
	private  $NoiDung;

	public function getMaComment() {
		return $this->MaComment;
	}
	
	public function setMaComment($MaComment) {
		$this->MaComment = $MaComment;
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
	public function getNgayDang() {
		return $this->NgayDang;
	}
	
	public function setNgayDang($NgayDang) {
		$this->NgayDang = $NgayDang;
	}
	public function getNoiDung() {
		return $this->NoiDung;
	}
	
	public function setNoiDung($NoiDung) {
		$this->NoiDung = $NoiDung;
	}
}
?>