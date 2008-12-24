<?php
class rankingDTO
{		
	private  $MaBaiHat;
	private  $MaTaiKhoan;
	private  $Diem;

	public function getMaBaiHat() {
		return $this->MaBaiHat;
	}
	
	public function setMaBaiHat($MaBaiHat) {
		$this->MaBaiHat = $MaBaiHat;
	}
	public function getMaTaiKhoan() {
		return $this->MaTaiKhoan;
	}
	
	public function setMaTaiKhoan($MaTaiKhoan) {
		$this->MaTaiKhoan = $MaTaiKhoan;
	}
	public function getDiem() {
		return $this->Diem;
	}
	
	public function setDiem($Diem) {
		$this->Diem = $Diem;
	}
}
?>