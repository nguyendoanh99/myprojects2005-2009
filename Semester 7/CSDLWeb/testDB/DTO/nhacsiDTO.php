<?php
class nhacsiDTO
{		
	private  $MaNhacSi;
	private  $TenNhacSi;

	public function getMaNhacSi() {
		return $this->MaNhacSi;
	}
	
	public function setMaNhacSi($MaNhacSi) {
		$this->MaNhacSi = $MaNhacSi;
	}
	public function getTenNhacSi() {
		return $this->TenNhacSi;
	}
	
	public function setTenNhacSi($TenNhacSi) {
		$this->TenNhacSi = $TenNhacSi;
	}
}
?>