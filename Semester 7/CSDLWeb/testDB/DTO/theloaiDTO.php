<?php
class theloaiDTO
{		
	private  $MaTheLoai;
	private  $TenTheLoai;

	public function getMaTheLoai() {
		return $this->MaTheLoai;
	}
	
	public function setMaTheLoai($MaTheLoai) {
		$this->MaTheLoai = $MaTheLoai;
	}
	public function getTenTheLoai() {
		return $this->TenTheLoai;
	}
	
	public function setTenTheLoai($TenTheLoai) {
		$this->TenTheLoai = $TenTheLoai;
	}
}
?>