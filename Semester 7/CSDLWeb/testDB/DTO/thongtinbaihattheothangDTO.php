<?php
class thongtinbaihattheothangDTO
{		
	private  $MaBaiHat;
	private  $Thang;
	private  $SoLuotNghe;
	private  $SoLuotDownload;

	public function getMaBaiHat() {
		return $this->MaBaiHat;
	}
	
	public function setMaBaiHat($MaBaiHat) {
		$this->MaBaiHat = $MaBaiHat;
	}
	public function getThang() {
		return $this->Thang;
	}
	
	public function setThang($Thang) {
		$this->Thang = $Thang;
	}
	public function getSoLuotNghe() {
		return $this->SoLuotNghe;
	}
	
	public function setSoLuotNghe($SoLuotNghe) {
		$this->SoLuotNghe = $SoLuotNghe;
	}
	public function getSoLuotDownload() {
		return $this->SoLuotDownload;
	}
	
	public function setSoLuotDownload($SoLuotDownload) {
		$this->SoLuotDownload = $SoLuotDownload;
	}
}
?>