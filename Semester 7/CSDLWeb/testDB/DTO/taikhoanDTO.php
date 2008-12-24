<?php
class taikhoanDTO
{		
	private  $MaTaiKhoan;
	private  $UserName;
	private  $Password;
	private  $HoTen;
	private  $NgaySinh;
	private  $NgayDangKy;
	private  $Avatar;
	private  $TinhTrang;
	private  $MaLoaiTaiKhoan;

	public function getMaTaiKhoan() {
		return $this->MaTaiKhoan;
	}
	
	public function setMaTaiKhoan($MaTaiKhoan) {
		$this->MaTaiKhoan = $MaTaiKhoan;
	}
	public function getUserName() {
		return $this->UserName;
	}
	
	public function setUserName($UserName) {
		$this->UserName = $UserName;
	}
	public function getPassword() {
		return $this->Password;
	}
	
	public function setPassword($Password) {
		$this->Password = $Password;
	}
	public function getHoTen() {
		return $this->HoTen;
	}
	
	public function setHoTen($HoTen) {
		$this->HoTen = $HoTen;
	}
	public function getNgaySinh() {
		return $this->NgaySinh;
	}
	
	public function setNgaySinh($NgaySinh) {
		$this->NgaySinh = $NgaySinh;
	}
	public function getNgayDangKy() {
		return $this->NgayDangKy;
	}
	
	public function setNgayDangKy($NgayDangKy) {
		$this->NgayDangKy = $NgayDangKy;
	}
	public function getAvatar() {
		return $this->Avatar;
	}
	
	public function setAvatar($Avatar) {
		$this->Avatar = $Avatar;
	}
	public function getTinhTrang() {
		return $this->TinhTrang;
	}
	
	public function setTinhTrang($TinhTrang) {
		$this->TinhTrang = $TinhTrang;
	}
	public function getMaLoaiTaiKhoan() {
		return $this->MaLoaiTaiKhoan;
	}
	
	public function setMaLoaiTaiKhoan($MaLoaiTaiKhoan) {
		$this->MaLoaiTaiKhoan = $MaLoaiTaiKhoan;
	}
}
?>