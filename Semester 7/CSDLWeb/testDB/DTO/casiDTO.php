<?php
class casiDTO
{		
	private  $MaCaSi;
	private  $TenCaSi;
	private  $QuocGia;

	public function getMaCaSi() {
		return $this->MaCaSi;
	}
	
	public function setMaCaSi($MaCaSi) {
		$this->MaCaSi = $MaCaSi;
	}
	public function getTenCaSi() {
		return $this->TenCaSi;
	}
	
	public function setTenCaSi($TenCaSi) {
		$this->TenCaSi = $TenCaSi;
	}
	public function getQuocGia() {
		return $this->QuocGia;
	}
	
	public function setQuocGia($QuocGia) {
		$this->QuocGia = $QuocGia;
	}
}
?>