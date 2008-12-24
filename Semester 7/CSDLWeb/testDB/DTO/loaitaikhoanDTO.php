<?php
class loaitaikhoanDTO
{		
	private  $MaLoaiTaiKhoan;
	private  $TenLoaiTaiKhoan;

	public function getMaLoaiTaiKhoan() {
		return $this->MaLoaiTaiKhoan;
	}
	
	public function setMaLoaiTaiKhoan($MaLoaiTaiKhoan) {
		$this->MaLoaiTaiKhoan = $MaLoaiTaiKhoan;
	}
	public function getTenLoaiTaiKhoan() {
		return $this->TenLoaiTaiKhoan;
	}
	
	public function setTenLoaiTaiKhoan($TenLoaiTaiKhoan) {
		$this->TenLoaiTaiKhoan = $TenLoaiTaiKhoan;
	}
}
?>